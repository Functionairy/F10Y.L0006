using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace F10Y.L0006
{
    public partial interface IProjectXElementOperator
    {
        public XElement Acquire_ItemGroup_ForProjectReferences(XElement projectElement)
            => Instances.XElementOperator.Acquire_Child(
                projectElement,
                this.Has_ItemGroup_ForProjectReferences,
                this.Create_ItemGroup);

        public XElement Create_ItemGroup()
            => Instances.XElementOperator.Create_Element(
                Instances.ProjectElementNames.ItemGroup);

        public bool Has_ItemGroup_ForProjectReferences(
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

        public (bool, XElement) Has_ItemGroup_ForProjectReferences(XElement projectElement)
        {
            var exists = this.Has_ItemGroup_ForProjectReferences(
                projectElement,
                out var propertyGroup_Main_OrDefault);

            return (exists, propertyGroup_Main_OrDefault);
        }
    }
}
