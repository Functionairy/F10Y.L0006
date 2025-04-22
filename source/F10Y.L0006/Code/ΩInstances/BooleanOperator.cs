using System;


namespace F10Y.L0006
{
    public class BooleanOperator : IBooleanOperator
    {
        #region Infrastructure

        public static IBooleanOperator Instance { get; } = new BooleanOperator();


        private BooleanOperator()
        {
        }

        #endregion
    }
}
