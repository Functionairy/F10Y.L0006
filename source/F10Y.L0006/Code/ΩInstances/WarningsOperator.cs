using System;


namespace F10Y.L0006
{
    public class WarningsOperator : IWarningsOperator
    {
        #region Infrastructure

        public static IWarningsOperator Instance { get; } = new WarningsOperator();


        private WarningsOperator()
        {
        }

        #endregion
    }
}
