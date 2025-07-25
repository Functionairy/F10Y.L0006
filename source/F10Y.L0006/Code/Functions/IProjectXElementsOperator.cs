using System;
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
        public IGroupElementOperator _GroupElementOperator => GroupElementOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        #region Include

        public string Get_Include(XElement element)
            => Instances.XElementOperator.Get_Attribute_Value(
                element,
                Instances.ProjectAttributeNames.Include);

        public bool Has_Include(
            XElement element,
            out XAttribute include_OrDefault)
            => Instances.XElementOperator.Has_Attribute(
                element,
                Instances.ProjectAttributeNames.Include,
                out include_OrDefault);

        public bool Has_Include(
            XElement element,
            out string includeValue_OrDefault)
            => Instances.XElementOperator.Has_AttributeValue(
                element,
                Instances.ProjectAttributeNames.Include,
                out includeValue_OrDefault);

        public void Set_Include(
            XElement element,
            string include)
            => Instances.XElementOperator.Set_Attribute_Value(
                element,
                Instances.ProjectAttributeNames.Include,
                include);

        #endregion
    }
}
