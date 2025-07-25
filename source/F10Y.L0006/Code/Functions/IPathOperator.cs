using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface IPathOperator :
        L0000.IPathOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0000.IPathOperator _L0000 => L0000.PathOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Gets the relative path from a source (referencing) project file to a destination (referenced) project file.
        /// (For use in project files.)
        /// </summary>
        /// <remarks>
        /// The relative path for project references in project files is <em>not</em> from the project file to the reference,
        /// but from the project file's containing <em>directory</em> to the reference.
        /// </remarks>
        public string Get_ProjectReference_RelativePath(
            string source_ProjectFilePath,
            string destination_ProjectFilePath)
        {
            var projectDirectoryPath = this.Get_ParentDirectoryPath_ForFile(source_ProjectFilePath);

            var output = this.Get_RelativePath(
                projectDirectoryPath,
                destination_ProjectFilePath);

            return output;
        }
    }
}
