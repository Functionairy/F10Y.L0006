using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0006.Implementations
{
    [FunctionsMarker]
    public partial interface IProjectFileOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        private static L0006.IProjectFileOperator _ProjectFileOperator => L0006.ProjectFileOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="L0006.IProjectFileOperator.Load(IEnumerable{string})" path="/summary"/>
        /// <remarks>
        /// 5251, in 21.934 seconds
        /// </remarks>
        async Task<Dictionary<string, XElement>> Load_OneByOne(IEnumerable<string> projectFilePaths)
        {
            var output = Instances.DictionaryOperator.New<string, XElement>();

            foreach (var projectFilePath in projectFilePaths)
            {
                var alreadyLoaded = output.ContainsKey(projectFilePath);
                if (!alreadyLoaded)
                {
                    var projectElement = await _ProjectFileOperator.Load(projectFilePath);

                    output.Add(projectFilePath, projectElement);
                }
            }

            return output;
        }

        /// <inheritdoc cref="L0006.IProjectFileOperator.Load(IEnumerable{string})" path="/summary"/>
        /// <remarks>
        /// 5251, in 4.017 seconds
        /// </remarks>
        async Task<Dictionary<string, XElement>> Load_InParallel_AsTasks(IEnumerable<string> projectFilePaths)
        {
            var tasks_ByProjectFilePath = Instances.DictionaryOperator.New<string, Task<XElement>>();

            foreach (var projectFilePath in projectFilePaths)
            {
                var alreadyLoaded = tasks_ByProjectFilePath.ContainsKey(projectFilePath);
                if (!alreadyLoaded)
                {
                    var getting_ProjectElement = _ProjectFileOperator.Load(projectFilePath);

                    tasks_ByProjectFilePath.Add(projectFilePath, getting_ProjectElement);
                }
            }

            var tasks = tasks_ByProjectFilePath.Values;

            await Task.WhenAll(tasks);

            var output = tasks_ByProjectFilePath
                .ToDictionary(
                    x => x.Key,
                    x => x.Value.Result);

            return output;
        }
    }
}
