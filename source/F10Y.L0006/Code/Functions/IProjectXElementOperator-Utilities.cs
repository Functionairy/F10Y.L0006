using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using F10Y.T0011;


namespace F10Y.L0006
{
    public partial interface IProjectXElementOperator
    {
        public new Task<XElement> Load(string projectFilePath)
            // All insignificant whitespace should be saved.
            => _ProjectXElementsOperator_Utilities.Load(projectFilePath);

        public XElement New_ProjectElement()
            => Instances.XElementOperator.New(
                Instances.ProjectNodeNames.Project);

        public new XElement Parse(string xmlText)
            => _ProjectXElementsOperator_Utilities.Parse(xmlText);

        public new Task Save(
            XElement projectElement,
            string projectFilePath)
            // Project file should be saved without an XML declaration, and with a byte-order mark.
            => _ProjectXElementsOperator_Utilities.Save(
                projectElement,
                projectFilePath);

        public new Task Save(
            XElement projectElement,
            string projectFilePath,
            XmlWriterSettings xmlWriterSettings)
            => _ProjectXElementsOperator_Utilities.Save(
                projectElement,
                projectFilePath,
                xmlWriterSettings);

        /// <summary>
        /// A quality-of-life overload for <see cref="Save(XElement, string)"/>.
        /// </summary>
        public new Task To_File(
            XElement projectElement,
            string projectFilePath)
            => _ProjectXElementsOperator_Utilities.To_File(
                projectElement,
                projectFilePath);

        /// <summary>
        /// A quality-of-life overload for <see cref="Save(XElement, string, XmlWriterSettings)"/>.
        /// </summary>
        public new Task To_File(
            XElement projectElement,
            string projectFilePath,
            XmlWriterSettings xmlWriterSettings)
            => _ProjectXElementsOperator_Utilities.To_File(
                projectElement,
                projectFilePath,
                xmlWriterSettings);

        public new string To_Text(XElement projectElement)
            => _ProjectXElementsOperator_Utilities.To_Text(projectElement);
    }
}
