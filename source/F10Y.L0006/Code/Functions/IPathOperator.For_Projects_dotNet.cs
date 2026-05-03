using System;
using System.Collections.Generic;
using System.Linq;
using F10Y.T0002;


namespace F10Y.L0006.For_Projects_dotNet
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// </remarks>
    [FunctionsMarker]
    public partial interface IPathOperator
    {
        /// <summary>
        /// Gets the relative path from a source (referencing) project file to a destination (referenced) project file.
        /// (For use in project files.)
        /// </summary>
        /// <remarks>
        /// The relative path for project references in project files is <em>not</em> from the project file to the reference,
        /// but from the project file's containing <em>directory</em> to the reference.
        /// </remarks>
        string Get_ProjectReference_RelativePath(
            string source_ProjectFilePath,
            string destination_ProjectFilePath)
        {
            var projectDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(source_ProjectFilePath);

            var output = Instances.PathOperator.Get_RelativePath(
                projectDirectoryPath,
                destination_ProjectFilePath);

            return output;
        }

        string[] Get_ProjectReference_RelativePaths(
            string source_ProjectFilePath,
            params string[] destination_ProjectFilePaths)
            => destination_ProjectFilePaths
                .Select(destination_ProjectFilePath => this.Get_ProjectReference_RelativePath(
                    source_ProjectFilePath,
                    destination_ProjectFilePath)
                )
                .Now();
    }
}
