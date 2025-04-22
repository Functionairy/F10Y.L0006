using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface IBooleanOperator :
        L0000.IBooleanOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0000.IBooleanOperator _L0000 => L0000.BooleanOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string To_String_ForProjectXml(bool value)
        {
            var output = this.To_String_Lower(value);
            return output;
        }
    }
}
