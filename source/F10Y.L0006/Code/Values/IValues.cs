using System;

using F10Y.T0003;


namespace F10Y.L0006
{
    [ValuesMarker]
    public partial interface IValues
    {
        /// <inheritdoc cref="L0000.IStrings.Semicolon"/>
        public string Authors_TokenSeparator => Instances.Strings.Semicolon;

        /// <inheritdoc cref="L0000.IStrings.Semicolon"/>
        public string Warnings_TokenSeparator => Instances.Strings.Semicolon;
    }
}
