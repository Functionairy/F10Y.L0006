using System;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface IGroupElementOperator
    {
        #region Label

        public string Get_Label(XElement propertyGroupElement)
            => Instances.XElementOperator.Get_Attribute_Value(
                propertyGroupElement,
                Instances.ProjectAttributeNames.Label);

        public bool Has_Label(
            XElement propertyGroupElement,
            out string label_OrDefault)
            => Instances.XElementOperator.Has_Child_Value(
                propertyGroupElement,
                Instances.ProjectAttributeNames.Label,
                out label_OrDefault);

        public void Set_Label(
            XElement propertyGroupElement,
            string label)
            => Instances.XElementOperator.Set_Attribute_Value(
                propertyGroupElement,
                Instances.ProjectAttributeNames.Label,
                label);

        #endregion
    }
}
