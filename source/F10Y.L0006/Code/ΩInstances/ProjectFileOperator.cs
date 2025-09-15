using System;


namespace F10Y.L0006
{
    public class ProjectFileOperator : IProjectFileOperator
    {
        #region Infrastructure

        public static IProjectFileOperator Instance { get; } = new ProjectFileOperator();


        private ProjectFileOperator()
        {
        }

        #endregion
    }
}


namespace F10Y.L0006.Implementations
{
    public class ProjectFileOperator : IProjectFileOperator
    {
        #region Infrastructure

        public static IProjectFileOperator Instance { get; } = new ProjectFileOperator();


        private ProjectFileOperator()
        {
        }

        #endregion
    }
}
