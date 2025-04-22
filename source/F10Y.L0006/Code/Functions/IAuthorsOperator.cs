using System;

using F10Y.T0002;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface IAuthorsOperator
    {
        public string Join(params string[] authors)
            => Instances.StringOperator.Join(
                Instances.Values.Warnings_TokenSeparator,
                authors);
    }
}
