using System;
using System.Collections.Generic;
using System.Xml.Linq;

using F10Y.L0000.Extensions;


namespace F10Y.L0006
{
    public partial interface IProjectXElementOperator
    {
        IEnumerable<XElement> Enumerate_ItemGroups(XElement projectElement)
            => projectElement.Enumerate_Children()
                .Where_NameIs(Instances.ProjectElementNames.ItemGroup)
                ;

        IEnumerable<XElement> Enumerate_PropertyGroupElements(XElement projectElement)
            => Instances.XElementOperator.Enumerate_Children(
                projectElement,
                Instances.ProjectElementNames.PropertyGroup);

        XElement Get_PropertyGroupElement_ChildElement_First(
            XElement projectElement,
            string childName)
        {
            var has_ChildElement = this.Has_PropertyGroupElement_ChildElement_First(
                projectElement,
                childName,
                out var child_OrDefault);

            if(!has_ChildElement)
            {
                throw new Exception($"{childName}: No property group child element found.");
            }

            return child_OrDefault;
        }

        /// <summary>
        /// Chooses <see cref="Get_PropertyGroupElement_ChildElement_First(XElement, string)"/> as the default.
        /// </summary>
        XElement Get_PropertyGroupElement_ChildElement(
            XElement projectElement,
            string childName)
            => this.Get_PropertyGroupElement_ChildElement_First(
                projectElement,
                childName);

        TValue Get_PropertyGroupElement_ChildElement_Value<TValue>(
            XElement projectElement,
            string childName,
            Func<XElement, TValue> valueSelector)
        {
            var childElement = this.Get_PropertyGroupElement_ChildElement_First(
                projectElement,
                childName);

            var output = valueSelector(childElement);
            return output;
        }

        bool Has_PropertyGroupElement_ChildElement_First(
            XElement projectElement,
            string childName,
            out XElement child_OrDefault)
        {
            var output = Instances.XElementOperator.Has_ChildOfChild_First(
                projectElement,
                Instances.ProjectElementNames.PropertyGroup,
                childName,
                out child_OrDefault);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_PropertyGroupElement_ChildElement_First(XElement, string, out XElement)"/> as the default.
        /// </summary>
        bool Has_PropertyGroupElement_ChildElement(
            XElement projectElement,
            string childName,
            out XElement child_OrDefault)
            => this.Has_PropertyGroupElement_ChildElement_First(
                projectElement,
                childName,
                out child_OrDefault);

        bool Has_PropertyGroupElement_ChildElement_Value<TValue>(
            XElement projectElement,
            string childName,
            Func<XElement, TValue> valueSelector,
            out TValue value_OrDefault)
        {
            var output = this.Has_PropertyGroupElement_ChildElement_First(
                projectElement,
                childName,
                out var child_OrDefault);

            value_OrDefault = output
                ? valueSelector(child_OrDefault)
                : default
                ;

            return output;
        }

        XElement Acquire_PropertyGroup_Main(XElement projectElement)
            => Instances.XElementOperator.Acquire_Child(
                projectElement,
                this.Has_PropertyGroup_Main,
                this.Create_PropertyGroup);

        XElement Create_PropertyGroup()
            => Instances.XElementOperator.Create_Element(
                Instances.ProjectElementNames.PropertyGroup);

        bool Has_PropertyGroup_Main(
            XElement projectElement,
            out XElement propertyGroup_Main_OrDefault)
        {
            // Is there a property group with a child named target framework?
            var has_PropertyGroup_WithChildTargetFramework = Instances.XElementOperator.Has_ChildWithChild_First(
                projectElement,
                Instances.ProjectElementNames.PropertyGroup,
                Instances.ProjectElementNames.TargetFramework,
                out propertyGroup_Main_OrDefault);

            if (has_PropertyGroup_WithChildTargetFramework)
            {
                return has_PropertyGroup_WithChildTargetFramework;
            }

            // Is there at least one property group?
            var has_PropertyGroup_First = Instances.XElementOperator.Has_Child_First(
                projectElement,
                Instances.ProjectElementNames.PropertyGroup,
                out propertyGroup_Main_OrDefault);

            return has_PropertyGroup_First;
        }

        (bool, XElement) Has_PropertyGroup_Main(XElement projectElement)
        {
            var exists = this.Has_PropertyGroup_Main(
                projectElement,
                out var propertyGroup_Main_OrDefault);

            return (exists, propertyGroup_Main_OrDefault);
        }
    }
}
