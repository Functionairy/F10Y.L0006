using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface IVersionOperator :
        L0000.IVersionOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0000.IVersionOperator _L0000 => L0000.VersionOperator.Instance;
        
#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="L0000.IVersionOperator.To_String_Major_Minor_Build(Version)"/>
        public string To_String_ForProjectXml(Version version)
        {
            var output = this.To_String_Major_Minor_Build(version);
            return output;
        }
    }
}
