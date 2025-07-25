using System;


namespace F10Y.L0006
{
    public class ProjectXElementsOperator : IProjectXElementsOperator
    {
        #region Infrastructure

        public static IProjectXElementsOperator Instance { get; } = new ProjectXElementsOperator();


        private ProjectXElementsOperator()
        {
        }

        #endregion
    }
}
