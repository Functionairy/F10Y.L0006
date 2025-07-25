using System;


namespace F10Y.L0006
{
    public class GroupElementOperator : IGroupElementOperator
    {
        #region Infrastructure

        public static IGroupElementOperator Instance { get; } = new GroupElementOperator();


        private GroupElementOperator()
        {
        }

        #endregion
    }
}
