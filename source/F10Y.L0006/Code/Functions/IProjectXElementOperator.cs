using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0006
{
    /// <summary>
    /// Contains funtions that work on the .NET project XElement.
    /// </summary>
    [FunctionsMarker]
    public partial interface IProjectXElementOperator
    {
        public XElement New_ProjectElement()
            => Instances.XElementOperator.New(
                Instances.ProjectNodeNames.Project);

        public Task<XElement> Load(string projectFilePath)
            // All insignificant whitespace should be saved.
            => Instances.XElementOperator.Load_PreserveWhitespace(projectFilePath);

        public XElement Parse(string xmlText)
            => Instances.XElementOperator.Parse(xmlText);

        public Task Save(
            string projectFilePath,
            XElement projectElement)
            // Project file should be saved without an XML declaration, and with a byte-order mark.
            => Instances.XElementOperator.Save_WithoutXmlDeclaration(
                projectElement,
                projectFilePath);

        public Task Save(
            string projectFilePath,
            XElement projectElement,
            XmlWriterSettings xmlWriterSettings)
            => Instances.XElementOperator.Save(
                projectElement,
                projectFilePath,
                xmlWriterSettings);

        public XAttribute Set_SDK(
            XElement projectElement,
            string sdk)
        {
            var attribute = Instances.XElementOperator.Acquire_Attribute(
                projectElement,
                Instances.ProjectAttributeNames.SDK);

            Instances.XAttributeOperator.Set_Value(
                attribute,
                sdk);

            return attribute;
        }

        /// <summary>
        /// A quality-of-life overload for <see cref="Save(string, XElement)"/>.
        /// </summary>
        public Task To_File(
            string projectFilePath,
            XElement projectElement)
            => this.Save(
                projectFilePath,
                projectElement);

        /// <summary>
        /// A quality-of-life overload for <see cref="Save(string, XElement, XmlWriterSettings)"/>.
        /// </summary>
        public Task To_File(
            string projectFilePath,
            XElement projectElement,
            XmlWriterSettings xmlWriterSettings)
            => this.Save(
                projectFilePath,
                projectElement,
                xmlWriterSettings);

        public string To_Text(XElement projectElement)
            => Instances.XElementOperator.To_Text_WithoutXmlDeclaration(projectElement);
    }
}
