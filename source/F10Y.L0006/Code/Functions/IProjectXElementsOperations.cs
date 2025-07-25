using System;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface IProjectXElementsOperations
    {
        public Action<XElement> Set_Include(string include)
            => element => Instances.ProjectXElementsOperator.Set_Include(
                element,
                include);
    }
}
