using System;


namespace F10Y.L0006.Z000
{
    public class XmlNamespaceNames : IXmlNamespaceNames
    {
        #region Infrastructure

        public static IXmlNamespaceNames Instance { get; } = new XmlNamespaceNames();


        private XmlNamespaceNames()
        {
        }

        #endregion
    }
}
