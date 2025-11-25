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
        Task<XElement> Load(string xmlFilePath)
            // All insignificant whitespace should be saved.
            => Instances.XElementOperator.Load_PreserveWhitespace(xmlFilePath);

        XElement Parse(string xmlText)
            => Instances.XElementOperator.Parse(xmlText);

        Task Save(
            XElement element,
            string xmlFilePath)
            // Project file should be saved without an XML declaration, and with a byte-order mark.
            => Instances.XElementOperator.Save_WithoutXmlDeclaration(
                element,
                xmlFilePath);

        /// <summary>
        /// Saves the project element with re-indenting project elements.
        /// (Any existing indentation will be preserved.)
        /// </summary>
        Task Save_WithoutReindentation(
            XElement element,
            string xmlFilePath)
            // Project file should be saved without an XML declaration, and with a byte-order mark.
            => Instances.XElementOperator.Save_WithoutXmlDeclaration(
                element,
                xmlFilePath);

        /// <summary>
        /// Saves the project element with re-indentation of project elements.
        /// (Any existing indentation will be wiped in favor of the standard indentation.)
        /// </summary>
        Task Save_WithReindentation(
            XElement element,
            string xmlFilePath)
            // Project file should be saved without an XML declaration, and with a byte-order mark.
            => Instances.XElementOperator.Save(
                element,
                xmlFilePath,
                Instances.XmlWriterSettingsSet.Indent_AndOmitXmlDeclaration);

        Task Save(
            IEnumerable<XElement> elements,
            string xmlFilePath)
            // Project file should be saved without an XML declaration, and with a byte-order mark.
            => Instances.XElementOperator.Save_WithoutXmlDeclaration(
                elements,
                xmlFilePath);

        Task Save(
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
        Task To_File(
            XElement element,
            string xmlFilePath)
            => this.Save(
                element,
                xmlFilePath);

        /// <summary>
        /// A quality-of-life overload for <see cref="Save(XElement, string, XmlWriterSettings)"/>.
        /// </summary>
        Task To_File(
            XElement element,
            string xmlFilePath,
            XmlWriterSettings xmlWriterSettings)
            => this.Save(
                element,
                xmlFilePath,
                xmlWriterSettings);

        string To_Text(XElement projectElement)
            => Instances.XElementOperator.To_Text_WithoutXmlDeclaration(projectElement);
    }
}
