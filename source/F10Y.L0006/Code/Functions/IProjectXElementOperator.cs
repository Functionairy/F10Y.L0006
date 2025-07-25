using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

using F10Y.L0000.Extensions;
using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0006
{
    /// <summary>
    /// .NET project file processing library XElement functions.
    /// </summary>
    [FunctionsMarker]
    public partial interface IProjectXElementOperator :
        Utilities.IProjectXElementsOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Utilities.IProjectXElementsOperator _ProjectXElementsOperator_Utilities => ProjectXElementsOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        #region Generate Documentation Files

        public XElement Acquire_GenerateDocumentationFile(
            XElement projectElement,
            Func<XElement, XElement> acquire_PropertyGroup)
            => Instances.XElementOperator.Acquire_ChildOfChild(
                projectElement,
                acquire_PropertyGroup,
                Instances.ProjectElementNames.GenerateDocumentationFile);

        public XElement Acquire_GenerateDocumentationFile(XElement projectElement)
            => this.Acquire_GenerateDocumentationFile(
                projectElement,
                this.Acquire_PropertyGroup_Main);

        public bool Has_GenerateDocumentationFile(
            XElement projectElement,
            out bool generateDocumentationFile_OrDefault)
            => Instances.XElementOperator.Has_ChildOfChild_Value_First(
                projectElement,
                Instances.ProjectElementNames.GenerateDocumentationFile,
                out generateDocumentationFile_OrDefault,
                Instances.XElementOperator.Get_Value_AsBoolean);

        public bool Get_GenerateDocumentationFile(XElement projectElement)
            => this.Get_PropertyGroupElement_ChildElement_Value(
                projectElement,
                Instances.ProjectElementNames.GenerateDocumentationFile,
                Instances.XElementOperator.Get_Value_AsBoolean);

        public XElement Set_GenerateDocumentationFile(
            XElement projectElement,
            bool generateDocumentationFile,
            Func<XElement, XElement> acquire_GenerateDocumentationFile)
        {
            var output = acquire_GenerateDocumentationFile(projectElement);

            Instances.XElementOperator.Set_Value(
                output,
                generateDocumentationFile,
                Instances.BooleanOperator.To_String);

            return output;
        }

        public XElement Set_GenerateDocumentationFile(
            XElement projectElement,
            bool generateDocumentationFile)
            => this.Set_GenerateDocumentationFile(
                projectElement,
                generateDocumentationFile,
                this.Acquire_GenerateDocumentationFile);

        #endregion

        #region Output Type

        public XElement Acquire_OutputType(
            XElement projectElement,
            Func<XElement, XElement> acquire_PropertyGroup)
            => Instances.XElementOperator.Acquire_ChildOfChild(
                projectElement,
                acquire_PropertyGroup,
                Instances.ProjectElementNames.OutputType);

        public XElement Acquire_OutputType(XElement projectElement)
            => this.Acquire_OutputType(
                projectElement,
                this.Acquire_PropertyGroup_Main);

        public bool Has_OutputType(
            XElement projectElement,
            out string outputType_OrDefault)
            => Instances.XElementOperator.Has_ChildOfChild_Value_First(
                projectElement,
                Instances.ProjectElementNames.OutputType,
                out outputType_OrDefault);

        public string Get_OutputType(XElement projectElement)
            => this.Get_PropertyGroupElement_ChildElement_Value(
                projectElement,
                Instances.ProjectElementNames.OutputType,
                Instances.XElementOperator.Get_Value_AsString);

        public XElement Set_OutputType(
            XElement projectElement,
            string outputType,
            Func<XElement, XElement> acquire_OutputType)
        {
            var output = acquire_OutputType(projectElement);

            Instances.XElementOperator.Set_Value(
                output,
                outputType);

            return output;
        }

        public XElement Set_OutputType(
            XElement projectElement,
            string outputType)
            => this.Set_OutputType(
                projectElement,
                outputType,
                this.Acquire_OutputType);

        #endregion

        #region Project References

        public IEnumerable<XElement> Enumerate_ProjectReferenceElements(XElement projectElement)
            => Instances.XElementOperator.Enumerate_ChildrenOfChildren(
                projectElement,
                Instances.ProjectElementNames.ProjectReference);

        public IEnumerable<string> Enumerate_ProjectReference_RelativePaths(XElement projectElement)
            => this.Enumerate_ProjectReferenceElements(projectElement)
                .Select(Instances.ProjectXElementsOperator.Get_Include)
                ;

        public IEnumerable<string> Enumerate_ProjectReferencePaths_Unresolved(
            XElement projectElement,
            string projectFilePath)
        {
            var projectDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(projectFilePath);

            var output = this.Enumerate_ProjectReference_RelativePaths(projectElement)
                .Select(relativePath => Instances.PathOperator.Get_Path(
                    projectDirectoryPath,
                    relativePath))
                ;

            return output;
        }

        public IEnumerable<string> Enumerate_ProjectReferencePaths_Resolved(
            XElement projectElement,
            string projectFilePath)
        {
            var projectReferencePaths_Unresolved = this.Enumerate_ProjectReferencePaths_Unresolved(
                projectElement,
                projectFilePath);

            var output = projectReferencePaths_Unresolved
                .Select(Instances.PathOperator.Resolve)
                ;

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Enumerate_ProjectReferencePaths_Resolved(XElement, string)"/> as the default.
        /// </summary>
        public IEnumerable<string> Enumerate_ProjectReferencePaths(
            XElement projectElement,
            string projectFilePath)
            => this.Enumerate_ProjectReferencePaths_Resolved(
                projectElement,
                projectFilePath);

        public string[] Get_ProjectReferencePaths_Direct(
            XElement projectElement,
            string projectFilePath)
            => this.Enumerate_ProjectReferencePaths(
                projectElement,
                projectFilePath)
                .ToArray();

        /// <summary>
        /// Chooses <see cref="Get_ProjectReferencePaths_Direct(XElement, string)"/> as the default.
        /// </summary>
        public string[] Get_ProjectReferencePaths(
            XElement projectElement,
            string projectFilePath)
            => this.Get_ProjectReferencePaths_Direct(
                projectElement,
                projectFilePath);

        public Dictionary<string, string[]> Get_ProjectReferencePaths_ByProjectFilePath(
            Dictionary<string, XElement> projectElements_ByProjectFilePath)
        {
            var output = projectElements_ByProjectFilePath
                .ToDictionary(
                    x => x.Key,
                    x => this.Get_ProjectReferencePaths(
                        x.Value,
                        x.Key));

            return output;
        }

        public bool Has_ProjectReferences(
            XElement projectElement,
            out string outputType_OrDefault)
            => Instances.XElementOperator.Has_ChildOfChild_Value_First(
                projectElement,
                Instances.ProjectElementNames.OutputType,
                out outputType_OrDefault);

        #endregion

        #region Target Framework

        public XElement Acquire_TargetFramework(
            XElement projectElement,
            Func<XElement, XElement> acquire_PropertyGroup)
            => Instances.XElementOperator.Acquire_ChildOfChild(
                projectElement,
                acquire_PropertyGroup,
                Instances.ProjectElementNames.TargetFramework);

        public XElement Acquire_TargetFramework(XElement projectElement)
            => this.Acquire_OutputType(
                projectElement,
                this.Acquire_PropertyGroup_Main);

        public bool Has_TargetFramework(
            XElement projectElement,
            out string outputType_OrDefault)
            => Instances.XElementOperator.Has_ChildOfChild_Value_First(
                projectElement,
                Instances.ProjectElementNames.TargetFramework,
                out outputType_OrDefault);

        public string Get_TargetFramework(XElement projectElement)
            => this.Get_PropertyGroupElement_ChildElement_Value(
                projectElement,
                Instances.ProjectElementNames.TargetFramework,
                Instances.XElementOperator.Get_Value_AsString);

        public XElement Set_TargetFramework(
            XElement projectElement,
            string targetFramework,
            Func<XElement, XElement> acquire_TargetFramework)
        {
            var output = acquire_TargetFramework(projectElement);

            Instances.XElementOperator.Set_Value(
                output,
                targetFramework);

            return output;
        }

        public XElement Set_TargetFramework(
            XElement projectElement,
            string targetFramework)
            => this.Set_TargetFramework(
                projectElement,
                targetFramework,
                this.Acquire_TargetFramework);

        #endregion

        #region SDK

        public XAttribute Set_SDK(
            XElement projectElement,
            string sdk)
        {
            var attribute = Instances.XElementOperator.Acquire_Attribute(
                projectElement,
                Instances.ProjectAttributeNames.Sdk);

            Instances.XAttributeOperator.Set_Value(
                attribute,
                sdk);

            return attribute;
        }

        #endregion
    }
}
