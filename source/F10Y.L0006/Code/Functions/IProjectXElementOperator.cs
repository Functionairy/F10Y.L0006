using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using F10Y.L0000.Extensions;
using F10Y.T0002;
using F10Y.T0011;

using F10Y.L0006.Extensions;
using F10Y.L0003.L001;


namespace F10Y.L0006
{
    /// <summary>
    /// .NET project file processing library XElement functions.
    /// </summary>
    [FunctionsMarker]
    [DomainSetDescriptor(
        IDomainNames.dotNET_Constant,
        IDomainNames.Project_Constant,
        IDomainNames.XML_Constant
        )]
    public partial interface IProjectXElementOperator :
        Utilities.IProjectXElementsOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Utilities.IProjectXElementsOperator _ProjectXElementsOperator_Utilities => ProjectXElementsOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        bool Has_UseWindowsForms(
            XElement projectElement,
            out bool usesWindowsForms_OrDefault)
            => Instances.XElementOperator.Has_ChildOfChild_Value_First(
                projectElement,
                Instances.ProjectElementNames.UseWindowsForms,
                out usesWindowsForms_OrDefault,
                Instances.BooleanOperator.From);


        #region COM References

        bool Has_COMReferences_Any(XElement projectElement)
        {
            var output = projectElement.Enumerate_ItemGroups()
                .SelectMany(Instances.XElementOperator.Enumerate_Children)
                .Where_NameIs(Instances.ProjectElementNames.COMReference)
                .Any();

            return output;
        }

        #endregion

        #region Generate Documentation Files

        XElement Acquire_GenerateDocumentationFile(
            XElement projectElement,
            Func<XElement, XElement> acquire_PropertyGroup)
            => Instances.XElementOperator.Acquire_ChildOfChild(
                projectElement,
                acquire_PropertyGroup,
                Instances.ProjectElementNames.GenerateDocumentationFile);

        XElement Acquire_GenerateDocumentationFile(XElement projectElement)
            => this.Acquire_GenerateDocumentationFile(
                projectElement,
                this.Acquire_PropertyGroup_Main);

        bool Has_GenerateDocumentationFile(
            XElement projectElement,
            out bool generateDocumentationFile_OrDefault)
            => Instances.XElementOperator.Has_ChildOfChild_Value_First(
                projectElement,
                Instances.ProjectElementNames.GenerateDocumentationFile,
                out generateDocumentationFile_OrDefault,
                Instances.XElementOperator.Get_Value_AsBoolean);

        bool Get_GenerateDocumentationFile(XElement projectElement)
            => this.Get_PropertyGroupElement_ChildElement_Value(
                projectElement,
                Instances.ProjectElementNames.GenerateDocumentationFile,
                Instances.XElementOperator.Get_Value_AsBoolean);

        XElement Set_GenerateDocumentationFile(
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

        XElement Set_GenerateDocumentationFile(
            XElement projectElement,
            bool generateDocumentationFile)
            => this.Set_GenerateDocumentationFile(
                projectElement,
                generateDocumentationFile,
                this.Acquire_GenerateDocumentationFile);

        #endregion

        #region Item Group

        XElement Acquire_ItemGroup_ForProjectReferences(XElement projectElement)
            => Instances.XElementOperator.Acquire_Child(
                projectElement,
                this.Has_ItemGroup_ForProjectReferences,
                this.Create_ItemGroup);

        XElement Create_ItemGroup()
            => Instances.XElementOperator.Create_Element(
                Instances.ProjectElementNames.ItemGroup);

        bool Has_ItemGroup_ForProjectReferences(
            XElement projectElement,
            out XElement propertyGroup_Main_OrDefault)
        {
            // Is there an item group with a child named project reference?
            var has_ItemGroup_WithChildProjectReference = Instances.XElementOperator.Has_ChildWithChild_First(
                projectElement,
                Instances.ProjectElementNames.ItemGroup,
                Instances.ProjectElementNames.ProjectReference,
                out propertyGroup_Main_OrDefault);

            if (has_ItemGroup_WithChildProjectReference)
            {
                return has_ItemGroup_WithChildProjectReference;
            }

            // Is there at least one item group?
            var has_PropertyGroup_First = Instances.XElementOperator.Has_Child_First(
                projectElement,
                Instances.ProjectElementNames.ItemGroup,
                out propertyGroup_Main_OrDefault);

            return has_PropertyGroup_First;
        }

        (bool, XElement) Has_ItemGroup_ForProjectReferences(XElement projectElement)
        {
            var exists = this.Has_ItemGroup_ForProjectReferences(
                projectElement,
                out var propertyGroup_Main_OrDefault);

            return (exists, propertyGroup_Main_OrDefault);
        }

        #endregion

        #region Output Type

        XElement Acquire_OutputType(
            XElement projectElement,
            Func<XElement, XElement> acquire_PropertyGroup)
            => Instances.XElementOperator.Acquire_ChildOfChild(
                projectElement,
                acquire_PropertyGroup,
                Instances.ProjectElementNames.OutputType);

        XElement Acquire_OutputType(XElement projectElement)
            => this.Acquire_OutputType(
                projectElement,
                this.Acquire_PropertyGroup_Main);

        bool Has_OutputType(
            XElement projectElement,
            out string outputType_OrDefault)
            => Instances.XElementOperator.Has_ChildOfChild_Value_First(
                projectElement,
                Instances.ProjectElementNames.OutputType,
                out outputType_OrDefault);

        string Get_OutputType(XElement projectElement)
            => this.Get_PropertyGroupElement_ChildElement_Value(
                projectElement,
                Instances.ProjectElementNames.OutputType,
                Instances.XElementOperator.Get_Value_AsString);

        XElement Set_OutputType(
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

        XElement Set_OutputType(
            XElement projectElement,
            string outputType)
            => this.Set_OutputType(
                projectElement,
                outputType,
                this.Acquire_OutputType);

        #endregion

        #region Project References

        IEnumerable<XElement> Enumerate_ProjectReferenceElements(XElement projectElement)
            => Instances.XElementOperator.Enumerate_ChildrenOfChildren(
                projectElement,
                Instances.ProjectNodeNames.ItemGroup,
                Instances.ProjectNodeNames.ProjectReference);

        IEnumerable<string> Enumerate_ProjectReference_RelativePaths(XElement projectElement)
            => this.Enumerate_ProjectReferenceElements(projectElement)
                .Select(Instances.ProjectXElementsOperator.Get_Include)
                ;

        IEnumerable<string> Enumerate_ProjectReferencePaths_Unresolved(
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

        IEnumerable<string> Enumerate_ProjectReferencePaths_Resolved(
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
        IEnumerable<string> Enumerate_ProjectReferencePaths(
            XElement projectElement,
            string projectFilePath)
            => this.Enumerate_ProjectReferencePaths_Resolved(
                projectElement,
                projectFilePath);

        string[] Get_ProjectReferencePaths_Direct(
            XElement projectElement,
            string projectFilePath)
            => this.Enumerate_ProjectReferencePaths(
                projectElement,
                projectFilePath)
                .ToArray();

        /// <summary>
        /// Chooses <see cref="Get_ProjectReferencePaths_Direct(XElement, string)"/> as the default.
        /// </summary>
        string[] Get_ProjectReferencePaths(
            XElement projectElement,
            string projectFilePath)
            => this.Get_ProjectReferencePaths_Direct(
                projectElement,
                projectFilePath);

        Dictionary<string, string[]> Get_ProjectReferencePaths_ByProjectFilePath(
            IDictionary<string, XElement> projectElements_ByProjectFilePath)
        {
            var output = projectElements_ByProjectFilePath
                .ToDictionary(
                    x => x.Key,
                    x => this.Get_ProjectReferencePaths(
                        x.Value,
                        x.Key));

            return output;
        }

        bool Has_ProjectReferences(
            XElement projectElement,
            out string outputType_OrDefault)
            => Instances.XElementOperator.Has_ChildOfChild_Value_First(
                projectElement,
                Instances.ProjectElementNames.OutputType,
                out outputType_OrDefault);

        #endregion

        #region Target Framework

        XElement Acquire_TargetFramework(
            XElement projectElement,
            Func<XElement, XElement> acquire_PropertyGroup)
            => Instances.XElementOperator.Acquire_ChildOfChild(
                projectElement,
                acquire_PropertyGroup,
                Instances.ProjectElementNames.TargetFramework);

        XElement Acquire_TargetFramework(XElement projectElement)
            => this.Acquire_OutputType(
                projectElement,
                this.Acquire_PropertyGroup_Main);

        bool Has_TargetFramework(
            XElement projectElement,
            out string targetFramework_OrDefault)
            => Instances.XElementOperator.Has_ChildOfChild_Value_First(
                projectElement,
                Instances.ProjectElementNames.TargetFramework,
                out targetFramework_OrDefault);

        Has<string> Has_TargetFramework(XElement projectElement)
        {
            var has = this.Has_TargetFramework(
                projectElement,
                out var targetFramework_OrDefault);

            var output = Instances.HasOperator.From(
                targetFramework_OrDefault,
                has);

            return output;
        }

        string Get_TargetFramework(XElement projectElement)
            => this.Get_PropertyGroupElement_ChildElement_Value(
                projectElement,
                Instances.ProjectElementNames.TargetFramework,
                Instances.XElementOperator.Get_Value_AsString);

        XElement Set_TargetFramework(
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

        XElement Set_TargetFramework(
            XElement projectElement,
            string targetFramework)
            => this.Set_TargetFramework(
                projectElement,
                targetFramework,
                this.Acquire_TargetFramework);

        #endregion

        #region SDK

        string Get_SDK(XElement projectElement)
        {
            var attribute = Instances.XElementOperator.Get_Attribute(
                projectElement,
                Instances.ProjectAttributeNames.Sdk);

            var output = Instances.XAttributeOperator.Get_Value(attribute);
            return output;
        }

        /// <summary>
        /// Sets the SDK attribute on the project element.
        /// </summary>
        XAttribute Set_SDK(
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
