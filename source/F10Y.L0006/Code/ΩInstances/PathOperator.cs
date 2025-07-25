using System;


namespace F10Y.L0006
{
    public class PathOperator : IPathOperator
    {
        #region Infrastructure

        public static IPathOperator Instance { get; } = new PathOperator();


        private PathOperator()
        {
        }

        #endregion
    }
}
