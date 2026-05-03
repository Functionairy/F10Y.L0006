using System;

using F10Y.L0026.T007;
using F10Y.T0003;
using F10Y.Z0008;


namespace F10Y.L0006.Z000
{
    [DomainSetDescriptor(
        IDomainNames.dotNET_Constant,
        IDomainNames.Project_Constant,
        IDomainNames.XML_Constant,
        IDomainNames.Element_Constant,
        IDomainNames.Names_Constant
        )]
    [ValuesMarker]
    public partial interface IProjectElementNames
    {
        /// <inheritdoc cref="IProjectNodeNames.Authors"/>
        string Authors => Instances.ProjectNodeNames.Authors;

        /// <inheritdoc cref="IProjectNodeNames.Company"/>
        string Company => Instances.ProjectNodeNames.Company;

        /// <inheritdoc cref="IProjectNodeNames.COMReference"/>
        string COMReference => Instances.ProjectNodeNames.COMReference;

        /// <inheritdoc cref="IProjectNodeNames.Copyright"/>
        string Copyright => Instances.ProjectNodeNames.Copyright;

        /// <inheritdoc cref="IProjectNodeNames.Description"/>
        string Description => Instances.ProjectNodeNames.Description;

        /// <inheritdoc cref="IProjectNodeNames.Folder"/>
        string Folder => Instances.ProjectNodeNames.Folder;

        /// <inheritdoc cref="IProjectNodeNames.GenerateDocumentationFile"/>
        string GenerateDocumentationFile => Instances.ProjectNodeNames.GenerateDocumentationFile;

        /// <inheritdoc cref="IProjectNodeNames.ItemGroup"/>
        string ItemGroup => Instances.ProjectNodeNames.ItemGroup;

        /// <inheritdoc cref="IProjectNodeNames.NoWarn"/>
        string NoWarn => Instances.ProjectNodeNames.NoWarn;

        /// <inheritdoc cref="IProjectNodeNames.OutputType"/>
        string OutputType => Instances.ProjectNodeNames.OutputType;

        /// <inheritdoc cref="IProjectNodeNames.PackageLicenseExpression"/>
        string PackageLicenseExpression => Instances.ProjectNodeNames.PackageLicenseExpression;

        /// <inheritdoc cref="IProjectNodeNames.PackageReference"/>
        string PackageReference => Instances.ProjectNodeNames.PackageReference;

        /// <inheritdoc cref="IProjectNodeNames.PackageRequireLicenseAcceptance"/>
        string PackageRequireLicenseAcceptance => Instances.ProjectNodeNames.PackageRequireLicenseAcceptance;

        /// <inheritdoc cref="IProjectNodeNames.Project"/>
        string Project => Instances.ProjectNodeNames.Project;

        /// <inheritdoc cref="IProjectNodeNames.ProjectReference"/>
        string ProjectReference => Instances.ProjectNodeNames.ProjectReference;

        /// <inheritdoc cref="IProjectNodeNames.PropertyGroup"/>
        string PropertyGroup => Instances.ProjectNodeNames.PropertyGroup;

        /// <inheritdoc cref="IProjectNodeNames.RepositoryUrl"/>
        string RepositoryUrl => Instances.ProjectNodeNames.RepositoryUrl;

        /// <inheritdoc cref="IProjectNodeNames.TargetFramework"/>
        string TargetFramework => Instances.ProjectNodeNames.TargetFramework;

        /// <inheritdoc cref="IProjectNodeNames.UseWindowsForms"/>
        string UseWindowsForms => Instances.ProjectNodeNames.UseWindowsForms;

        /// <inheritdoc cref="IProjectNodeNames.Version"/>
        string Version => Instances.ProjectNodeNames.Version;
    }
}
