using System;
using System.Threading.Tasks;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface IProjectFileOperator
    {
        public Task<XElement> Load(string projectFilePath)
            => Instances.ProjectXElementOperator.Load(projectFilePath);

        public Task Save(
            string projectFilePath,
            XElement projectElement)
            => Instances.ProjectXElementOperator.Save(
                projectElement,
                projectFilePath);
    }
}
