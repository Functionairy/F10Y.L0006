using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface IPathOperator :
        For_Projects_dotNet.IPathOperator,
        L0000.IPathOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        For_Projects_dotNet.IPathOperator _For_Projects_dotNet => For_Projects_dotNet.PathOperator.Instance;

        [Ignore]
        L0000.IPathOperator _L0000 => L0000.PathOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
