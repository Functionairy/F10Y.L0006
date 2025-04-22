using System;


namespace F10Y.L0006.Z000
{
    public class ProjectElementNames : IProjectElementNames
    {
        #region Infrastructure

        public static IProjectElementNames Instance { get; } = new ProjectElementNames();


        private ProjectElementNames()
        {
        }

        #endregion
    }
}
