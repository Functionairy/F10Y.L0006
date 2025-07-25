using System;


namespace F10Y.L0006
{
    public class SemicolonedListOperator : ISemicolonedListOperator
    {
        #region Infrastructure

        public static ISemicolonedListOperator Instance { get; } = new SemicolonedListOperator();


        private SemicolonedListOperator()
        {
        }

        #endregion
    }
}
