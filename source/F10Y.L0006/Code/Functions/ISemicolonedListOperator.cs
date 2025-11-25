using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface ISemicolonedListOperator
    {
        public string Join(params string[] warnings)
            => this.Join(warnings.AsEnumerable());

        public string Join(IEnumerable<string> warnings)
            => Instances.StringOperator.Join(
                Instances.Strings.Semicolon,
                warnings);

        public string[] Split(string warnings)
            => Instances.StringOperator.Split(
                Instances.Strings.Semicolon,
                warnings);
    }
}
