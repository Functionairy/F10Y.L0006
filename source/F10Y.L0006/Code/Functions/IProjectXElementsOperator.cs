using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0006
{
    /// <summary>
    /// Functions for working with any XML element within a .NET (Visual Studio) project file.
    /// </summary>
    [FunctionsMarker]
    public partial interface IProjectXElementsOperator :
        Utilities.IProjectXElementsOperator,
        IGroupElementOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        IGroupElementOperator _GroupElementOperator => GroupElementOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        #region Include

        void Add_IncludeAttribute(
            XElement parent,
            string value)
        {
            var include = this.Create_IncludeAttribute(value);

            Instances.XElementOperator.Add_Attribute(
                parent,
                include);
        }

        XAttribute Create_IncludeAttribute(string value)
            => Instances.XAttributeOperator.Create(
                Instances.ProjectAttributeNames.Include,
                value);

        string Get_Include(XElement element)
            => Instances.XElementOperator.Get_Attribute_Value(
                element,
                Instances.ProjectAttributeNames.Include);

        bool Has_Include(
            XElement element,
            out XAttribute include_OrDefault)
            => Instances.XElementOperator.Has_Attribute(
                element,
                Instances.ProjectAttributeNames.Include,
                out include_OrDefault);

        bool Has_Include(
            XElement element,
            out string includeValue_OrDefault)
            => Instances.XElementOperator.Has_AttributeValue(
                element,
                Instances.ProjectAttributeNames.Include,
                out includeValue_OrDefault);

        void Set_Include(
            XElement element,
            string include)
            => Instances.XElementOperator.Set_Attribute_Value(
                element,
                Instances.ProjectAttributeNames.Include,
                include);

        #endregion


        XElement Create_FolderElement(
            string value)
        {
            var folder = Instances.XElementOperator.New(
                Instances.ProjectElementNames.Folder);

            this.Add_IncludeAttribute(
                folder,
                value);

            return folder;
        }

        XElement Create_PackageReferenceElement(
            string package_Name,
            string package_Version)
        {
            var packageReference = Instances.XElementOperator.New(
                Instances.ProjectElementNames.PackageReference);

            this.Add_IncludeAttribute(
                packageReference,
                package_Name);

            Instances.XElementOperator.Add_Attribute(
                packageReference,
                Instances.ProjectAttributeNames.Version,
                package_Version);

            return packageReference;
        }

        XElement Create_ProjectReferenceElement(string projectReference_RelativeFilePath)
        {
            var projectReference = Instances.XElementOperator.New(
                Instances.ProjectElementNames.ProjectReference);

            this.Add_IncludeAttribute(
                projectReference,
                projectReference_RelativeFilePath);

            return projectReference;
        }
    }
}
