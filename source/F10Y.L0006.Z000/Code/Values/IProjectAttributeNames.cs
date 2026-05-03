using System;

using F10Y.T0003;


namespace F10Y.L0006.Z000
{
    [ValuesMarker]
    public partial interface IProjectAttributeNames
    {
        /// <inheritdoc cref="IProjectNodeNames.DefaultTargets"/>
        string DefaultTargets => Instances.ProjectNodeNames.DefaultTargets;

        /// <inheritdoc cref="IProjectNodeNames.Include"/>
        string Include => Instances.ProjectNodeNames.Include;

        /// <inheritdoc cref="IProjectNodeNames.InitialTargets"/>
        string InitialTargets => Instances.ProjectNodeNames.InitialTargets;

        /// <inheritdoc cref="IProjectNodeNames.Label"/>
        string Label => Instances.ProjectNodeNames.Label;

        /// <inheritdoc cref="IProjectNodeNames.Sdk"/>
        string Sdk => Instances.ProjectNodeNames.Sdk;

        /// <inheritdoc cref="IProjectNodeNames.ToolsVersion"/>
        string ToolsVersion => Instances.ProjectNodeNames.ToolsVersion;

        /// <inheritdoc cref="IProjectNodeNames.TreatAsLocalProperty"/>
        string TreatAsLocalProperty => Instances.ProjectNodeNames.TreatAsLocalProperty;

        /// <inheritdoc cref="IProjectNodeNames.Version"/>
        string Version => Instances.ProjectNodeNames.Version;
    }
}
