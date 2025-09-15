using System;

using F10Y.T0003;


namespace F10Y.L0006.Z000
{
    [ValuesMarker]
    public partial interface IProjectElementNames
    {
        /// <inheritdoc cref="IProjectNodeNames.Authors"/>
        public string Authors => Instances.ProjectNodeNames.Authors;

        /// <inheritdoc cref="IProjectNodeNames.Company"/>
        public string Company => Instances.ProjectNodeNames.Company;

        /// <inheritdoc cref="IProjectNodeNames.COMReference"/>
        public string COMReference => Instances.ProjectNodeNames.COMReference;

        /// <inheritdoc cref="IProjectNodeNames.Copyright"/>
        public string Copyright => Instances.ProjectNodeNames.Copyright;

        /// <inheritdoc cref="IProjectNodeNames.Description"/>
        public string Description => Instances.ProjectNodeNames.Description;

        /// <inheritdoc cref="IProjectNodeNames.GenerateDocumentationFile"/>
        public string GenerateDocumentationFile => Instances.ProjectNodeNames.GenerateDocumentationFile;

        /// <inheritdoc cref="IProjectNodeNames.ItemGroup"/>
        public string ItemGroup => Instances.ProjectNodeNames.ItemGroup;

        /// <inheritdoc cref="IProjectNodeNames.NoWarn"/>
        public string NoWarn => Instances.ProjectNodeNames.NoWarn;

        /// <inheritdoc cref="IProjectNodeNames.OutputType"/>
        public string OutputType => Instances.ProjectNodeNames.OutputType;

        /// <inheritdoc cref="IProjectNodeNames.PackageLicenseExpression"/>
        public string PackageLicenseExpression => Instances.ProjectNodeNames.PackageLicenseExpression;

        /// <inheritdoc cref="IProjectNodeNames.PackageRequireLicenseAcceptance"/>
        public string PackageRequireLicenseAcceptance => Instances.ProjectNodeNames.PackageRequireLicenseAcceptance;

        /// <inheritdoc cref="IProjectNodeNames.Project"/>
        public string Project => Instances.ProjectNodeNames.Project;

        /// <inheritdoc cref="IProjectNodeNames.ProjectReference"/>
        public string ProjectReference => Instances.ProjectNodeNames.ProjectReference;

        /// <inheritdoc cref="IProjectNodeNames.PropertyGroup"/>
        public string PropertyGroup => Instances.ProjectNodeNames.PropertyGroup;

        /// <inheritdoc cref="IProjectNodeNames.RepositoryUrl"/>
        public string RepositoryUrl => Instances.ProjectNodeNames.RepositoryUrl;

        /// <inheritdoc cref="IProjectNodeNames.TargetFramework"/>
        public string TargetFramework => Instances.ProjectNodeNames.TargetFramework;

        /// <inheritdoc cref="IProjectNodeNames.UseWindowsForms"/>
        public string UseWindowsForms => Instances.ProjectNodeNames.UseWindowsForms;

        /// <inheritdoc cref="IProjectNodeNames.Version"/>
        public string Version => Instances.ProjectNodeNames.Version;
    }
}
