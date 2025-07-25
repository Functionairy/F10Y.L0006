using System;


namespace F10Y.L0006
{
    public class ProjectXElementsOperations : IProjectXElementsOperations
    {
        #region Infrastructure

        public static IProjectXElementsOperations Instance { get; } = new ProjectXElementsOperations();


        private ProjectXElementsOperations()
        {
        }

        #endregion
    }
}
