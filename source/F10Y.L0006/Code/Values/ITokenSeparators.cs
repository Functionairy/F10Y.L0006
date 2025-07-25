using System;

using F10Y.T0003;


namespace F10Y.L0006
{
    [ValuesMarker]
    public partial interface ITokenSeparators
    {
        /// <inheritdoc cref="L0000.IStrings.Semicolon"/>
        public string For_AuthorsList => Instances.Strings.Semicolon;

        /// <inheritdoc cref="L0000.IStrings.Semicolon"/>
        public string For_WarningsList => Instances.Strings.Semicolon;
    }
}
