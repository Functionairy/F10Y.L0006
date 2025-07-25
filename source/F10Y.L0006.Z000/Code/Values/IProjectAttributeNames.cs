using System;

using F10Y.T0003;


namespace F10Y.L0006.Z000
{
    [ValuesMarker]
    public partial interface IProjectAttributeNames
    {
        /// <inheritdoc cref="IProjectNodeNames.DefaultTargets"/>
        public string DefaultTargets => Instances.ProjectNodeNames.DefaultTargets;

        /// <inheritdoc cref="IProjectNodeNames.Include"/>
        public string Include => Instances.ProjectNodeNames.Include;

        /// <inheritdoc cref="IProjectNodeNames.InitialTargets"/>
        public string InitialTargets => Instances.ProjectNodeNames.InitialTargets;

        /// <inheritdoc cref="IProjectNodeNames.Label"/>
        public string Label => Instances.ProjectNodeNames.Label;

        /// <inheritdoc cref="IProjectNodeNames.Sdk"/>
        public string Sdk => Instances.ProjectNodeNames.Sdk;

        /// <inheritdoc cref="IProjectNodeNames.ToolsVersion"/>
        public string ToolsVersion => Instances.ProjectNodeNames.ToolsVersion;

        /// <inheritdoc cref="IProjectNodeNames.TreatAsLocalProperty"/>
        public string TreatAsLocalProperty => Instances.ProjectNodeNames.TreatAsLocalProperty;
    }
}
