using System;


namespace F10Y.L0006
{
    public class ProjectXElementOperator : IProjectXElementOperator
    {
        #region Infrastructure

        public static IProjectXElementOperator Instance { get; } = new ProjectXElementOperator();


        private ProjectXElementOperator()
        {
        }

        #endregion
    }
}
