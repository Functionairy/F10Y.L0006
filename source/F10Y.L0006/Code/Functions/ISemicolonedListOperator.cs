using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface ISemicolonedListOperator
    {
        string Join(params string[] values)
            => this.Join(values.AsEnumerable());

        string Join(IEnumerable<string> values)
            => Instances.StringOperator.Join(
                Instances.Strings.Semicolon,
                values);

        string[] Split(string values)
            => Instances.StringOperator.Split(
                Instances.Strings.Semicolon,
                values);
    }
}
