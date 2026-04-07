using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface ISemicolonedListOperator
    {
        public string Join(params string[] values)
            => this.Join(values.AsEnumerable());

        public string Join(IEnumerable<string> values)
            => Instances.StringOperator.Join(
                Instances.Strings.Semicolon,
                values);

        public string[] Split(string values)
            => Instances.StringOperator.Split(
                Instances.Strings.Semicolon,
                values);
    }
}
