using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using F10Y.T0011;


namespace F10Y.L0006
{
    public partial interface IProjectXElementOperator
    {
        new Task<XElement> Load(string projectFilePath)
            // All insignificant whitespace should be saved.
            => _ProjectXElementsOperator_Utilities.Load(projectFilePath);

        /// <summary>
        /// Gets a new element with the name "<inheritdoc cref="Z000.IProjectNodeNames.Project" path="descendant::value"/>".
        /// </summary>
        XElement New_ProjectElement()
            => Instances.XElementOperator.New(
                Instances.ProjectNodeNames.Project);

        new XElement Parse(string xmlText)
            => _ProjectXElementsOperator_Utilities.Parse(xmlText);

        new Task Save(
            XElement projectElement,
            string projectFilePath)
            // Project file should be saved without an XML declaration, and with a byte-order mark.
            => _ProjectXElementsOperator_Utilities.Save(
                projectElement,
                projectFilePath);

        new Task Save(
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
        new Task To_File(
            XElement projectElement,
            string projectFilePath)
            => _ProjectXElementsOperator_Utilities.To_File(
                projectElement,
                projectFilePath);

        /// <summary>
        /// A quality-of-life overload for <see cref="Save(XElement, string, XmlWriterSettings)"/>.
        /// </summary>
        new Task To_File(
            XElement projectElement,
            string projectFilePath,
            XmlWriterSettings xmlWriterSettings)
            => _ProjectXElementsOperator_Utilities.To_File(
                projectElement,
                projectFilePath,
                xmlWriterSettings);

        new string To_Text(XElement projectElement)
            => _ProjectXElementsOperator_Utilities.To_Text(projectElement);
    }
}
