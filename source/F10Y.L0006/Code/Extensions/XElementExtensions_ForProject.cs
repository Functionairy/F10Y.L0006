using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace F10Y.L0006.Extensions
{
    public static class XElementExtensions_ForProject
    {
        public static IEnumerable<XElement> Enumerate_ItemGroups(this XElement projectElement)
            => Instances.ProjectXElementOperator.Enumerate_ItemGroups(projectElement);
    }
}
