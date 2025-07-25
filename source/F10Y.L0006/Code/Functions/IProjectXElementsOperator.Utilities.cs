using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0006.Utilities
{
    /// <summary>
    /// Functions for working with any XML element within a .NET (Visual Studio) project file.
    /// </summary>
    [FunctionsMarker]
    public partial interface IProjectXElementsOperator
    {
        public Task<XElement> Load(string xmlFilePath)
            // All insignificant whitespace should be saved.
            => Instances.XElementOperator.Load_PreserveWhitespace(xmlFilePath);

        public XElement Parse(string xmlText)
            => Instances.XElementOperator.Parse(xmlText);

        public Task Save(
            XElement element,
            string xmlFilePath)
            // Project file should be saved without an XML declaration, and with a byte-order mark.
            => Instances.XElementOperator.Save_WithoutXmlDeclaration(
                element,
                xmlFilePath);

        public Task Save(
            IEnumerable<XElement> elements,
            string xmlFilePath)
            // Project file should be saved without an XML declaration, and with a byte-order mark.
            => Instances.XElementOperator.Save_WithoutXmlDeclaration(
                elements,
                xmlFilePath);

        public Task Save(
            XElement element,
            string xmlFilePath,
            XmlWriterSettings xmlWriterSettings)
            => Instances.XElementOperator.Save(
                element,
                xmlFilePath,
                xmlWriterSettings);

        /// <summary>
        /// A quality-of-life overload for <see cref="Save(XElement, string)"/>.
        /// </summary>
        public Task To_File(
            XElement element,
            string xmlFilePath)
            => this.Save(
                element,
                xmlFilePath);

        /// <summary>
        /// A quality-of-life overload for <see cref="Save(XElement, string, XmlWriterSettings)"/>.
        /// </summary>
        public Task To_File(
            XElement element,
            string xmlFilePath,
            XmlWriterSettings xmlWriterSettings)
            => this.Save(
                element,
                xmlFilePath,
                xmlWriterSettings);

        public string To_Text(XElement projectElement)
            => Instances.XElementOperator.To_Text_WithoutXmlDeclaration(projectElement);
    }
}
