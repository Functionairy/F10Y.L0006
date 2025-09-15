using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Xml.Linq;

using F10Y.L0000.Extensions;
using F10Y.L0003;
using F10Y.L0003.L001;
using F10Y.T0002;
using F10Y.T0011;
using F10Y.Z0002;
using For_Result_N002 = F10Y.L0001.L002.N002;


namespace F10Y.L0006
{
    /// <summary>
    /// .NET project file related functions.
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// </remarks>
    [FunctionsMarker]
    public partial interface IProjectFileOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Implementations.IProjectFileOperator _Implementations => Implementations.ProjectFileOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        async Task<(
            Dictionary<string, XElement> ProjectElements_ByProjectFilePath,
            Dictionary<string, For_Result_N002.IResult<XElement>> Failures_ByProjectFilePath)>
            Get_ProjectElements_ByProjectFilePath_Recursive(IEnumerable<string> projectFilePaths)
        {
            var (projectElementResults_ByProjectFilePath, _) = await this.Load_Projects_AndRecursiveReferences(projectFilePaths);

            var projectElements = projectElementResults_ByProjectFilePath
                .Where(pair => pair.Value.Success)
                .ToDictionary(
                    pair => pair.Key,
                    pair => pair.Value.Value);

            var failures = projectElementResults_ByProjectFilePath
                .Where(pair => !pair.Value.Success)
                .To_Dictionary();

            return (projectElements, failures);
        }

        Task<(
            Dictionary<string, XElement> ProjectElements_ByProjectFilePath,
            Dictionary<string, For_Result_N002.IResult<XElement>> Failures_ByProjectFilePath)>
            Get_ProjectElements_ByProjectFilePath_Recursive(params string[] projectFilePaths)
            => this.Get_ProjectElements_ByProjectFilePath_Recursive(projectFilePaths.AsEnumerable());

        public string Get_ProjectName(string projectFilePath)
        {
            var fileNameStem = Instances.PathOperator.Get_FileNameStem(projectFilePath);
            return fileNameStem;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<string> Get_TargetFrameworkMoniker(string projectFilePath)
        {
            var output = await this.Get_TargetFramework(projectFilePath);
            return output;
        }

        public Task<Has<string>> HasTargetFramework(string projectFilePath)
        {
            var hasTargetFramework = this.In_ProjectContext_Query(projectFilePath,
                projectElement =>
                {
                    var hasTargetFramework = Instances.ProjectXElementOperator.Has_TargetFramework(projectElement);

                    return hasTargetFramework;
                });

            return hasTargetFramework;
        }

        public async Task<string> Get_TargetFramework(string projectFilePath)
        {
            var hasTargetFramework = await this.HasTargetFramework(projectFilePath);
            if (!hasTargetFramework)
            {
                throw new Exception("No target framework element found in project.");
            }

            return hasTargetFramework;
        }

        public async Task<bool> Has_COMReferences_InAnyDependencies_Recursive(string projectFilePath)
        {
            var (projectElementResults_ByProjectFilePath, _) = await this.Get_ProjectElements_ByProjectFilePath_Recursive(projectFilePath);

            var output = projectElementResults_ByProjectFilePath
                .Where(pair => Instances.ProjectXElementOperator.Has_COMReferences_Any(pair.Value))
                .Any();

            return output;
        }

        async Task<TOut> In_ProjectAndDependenciesContext_Query<TOut>(
            string projectFilePath,
            Func<(
                string ProjectFilePath,
                XElement ProjectElement,
                Dictionary<string, XElement> DependencyProjectElements_ByProjectFilePath_Inclusive,
                Dictionary<string, string[]> Dependencies_ByProjectFilePath_Inclusive
                ), TOut> projectAndDependencies_Function)
        {
            var (projectElementResults_ByProjectFilePath, directReferences_ByProjectFilePath) = await this.Load_Projects_AndRecursiveReferences(projectFilePath);

            var failures_Any = projectElementResults_ByProjectFilePath
                .Where(pair => !pair.Value.Success)
                .Any();

            if(failures_Any)
            {
                throw Instances.ExceptionOperator.From("Project contained some invalid references.");
            }

            var dependencyProjectElements_ByProjectFilePath_Inclusive = projectElementResults_ByProjectFilePath
                .Select(pair => (pair.Key, pair.Value.Value))
                .ToDictionary(
                    tuple => tuple.Key,
                    tuple => tuple.Value);

            var projectElement = dependencyProjectElements_ByProjectFilePath_Inclusive[projectFilePath];

            var tuple = (
                projectFilePath,
                projectElement,
                dependencyProjectElements_ByProjectFilePath_Inclusive,
                directReferences_ByProjectFilePath);

            var output = projectAndDependencies_Function(tuple);
            return output;
        }

        async Task<(TOut Output, XElement ProjectElement)> In_ProjectContext_Query<TOut>(
            string projectFilePath,
            Func<XElement, TOut> projectElement_Function,
            OverloadToken_Output<XElement> output_Token)
        {
            var projectElement = await this.Load(projectFilePath);

            var output = projectElement_Function(projectElement);

            return (output, projectElement);
        }

        async Task<TOut> In_ProjectContext_Query<TOut>(
            string projectFilePath,
            Func<XElement, TOut> projectElement_Function)
        {
            var (output, _) = await this.In_ProjectContext_Query(
                projectFilePath,
                projectElement_Function,
                Instances.OverloadTokenOperator.Of_Type<XElement>().Output);

            return output;
        }

        Task<XElement> Load(string projectFilePath)
            => Instances.ProjectXElementOperator.Load(projectFilePath);

        /// <summary>
        /// Loads a set of project files.
        /// </summary>
        Task<Dictionary<string, XElement>> Load(IEnumerable<string> projectFilePaths)
            => _Implementations.Load_InParallel_AsTasks(projectFilePaths);

        /// <summary>
        /// Load the given projects and all of their recursive project references.
        /// </summary>
        /// <remarks>
        /// 1 to 160, in 0.140 seconds
        /// 5257, in 3.088 seconds
        /// </remarks>
        async Task<(
            Dictionary<string, For_Result_N002.IResult<XElement>> ProjectElementResults_ByProjectFilePath,
            Dictionary<string, string[]> DirectReferences_ByProjectFilePath)>
            Load_Projects_AndRecursiveReferences(IEnumerable<string> projectFilePaths)
        {
            var projectElements_ByProjectFilePath = Instances.DictionaryOperator.New<string, For_Result_N002.IResult<XElement>>();

            var projectFilePaths_Todo = Instances.HashSetOperator.New<string>();

            projectFilePaths_Todo.Add_Range(projectFilePaths);

            var directReferences_ByProjectFilePath = Instances.DictionaryOperator.New<string, string[]>();

            var anyInQueue = projectFilePaths_Todo.Any();
            while (anyInQueue)
            {
                var projectFilePath_Current = projectFilePaths_Todo.First();

                projectFilePaths_Todo.Remove(projectFilePath_Current);

                try
                {
                    var projectElement = await this.Load(projectFilePath_Current);

                    var load_Result = Instances.ResultOperator.Success(projectElement);

                    projectElements_ByProjectFilePath.Add(
                        projectFilePath_Current,
                        load_Result);

                    var projectReferencePaths = Instances.ProjectXElementOperator.Get_ProjectReferencePaths_Direct(
                        projectElement,
                        projectFilePath_Current);

                    directReferences_ByProjectFilePath.Add(
                        projectFilePath_Current,
                        projectReferencePaths);

                    foreach (var projectReferencePath in projectReferencePaths)
                    {
                        var alreadyDone = projectElements_ByProjectFilePath.ContainsKey(projectReferencePath);
                        if (!alreadyDone)
                        {
                            projectFilePaths_Todo.Add(projectReferencePath);
                        }
                    }
                }
                catch (Exception exception)
                {
                    var load_Result = Instances.ResultOperator.Failure<XElement>(exception);

                    projectElements_ByProjectFilePath.Add(
                        projectFilePath_Current,
                        load_Result);
                }

                anyInQueue = projectFilePaths_Todo.Any();
            }

            return (projectElements_ByProjectFilePath, directReferences_ByProjectFilePath);
        }

        Task<(
            Dictionary<string, For_Result_N002.IResult<XElement>> ProjectElementResults_ByProjectFilePath,
            Dictionary<string, string[]> DirectReferences_ByProjectFilePath)>
            Load_Projects_AndRecursiveReferences(params string[] projectFilePaths)
            => this.Load_Projects_AndRecursiveReferences(projectFilePaths.AsEnumerable());

        Task Save(
            string projectFilePath,
            XElement projectElement)
            => Instances.ProjectXElementOperator.Save(
                projectElement,
                projectFilePath);
    }
}
