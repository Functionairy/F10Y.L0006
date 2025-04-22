using System;

using F10Y.T0003;


namespace F10Y.L0006.Z000
{
    [ValuesMarker]
    public partial interface IProjectAttributeNames
    {
        /// <inheritdoc cref="IProjectNodeNames.Include"/>
        public string Include => Instances.ProjectNodeNames.Include;

        /// <inheritdoc cref="IProjectNodeNames.Label"/>
        public string Label => Instances.ProjectNodeNames.Label;

        /// <inheritdoc cref="IProjectNodeNames.SDK"/>
        public string SDK => Instances.ProjectNodeNames.SDK;
    }
}
