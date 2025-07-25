using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface IAuthorsOperator :
        ISemicolonedListOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public ISemicolonedListOperator _SemicolonedListOperator => SemicolonedListOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="ITokenSeparators.For_AuthorsList"/>
        public string Get_AuthorsList_TokenSeparator()
            => Instances.TokenSeparators.For_AuthorsList;
    }
}
