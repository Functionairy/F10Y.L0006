using System;


namespace F10Y.L0006.Z000
{
    public class ProjectNodeNames : IProjectNodeNames
    {
        #region Infrastructure

        public static IProjectNodeNames Instance { get; } = new ProjectNodeNames();


        private ProjectNodeNames()
        {
        }

        #endregion
    }
}
