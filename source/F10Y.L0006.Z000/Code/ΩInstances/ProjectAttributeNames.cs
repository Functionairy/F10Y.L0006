using System;


namespace F10Y.L0006.Z000
{
    public class ProjectAttributeNames : IProjectAttributeNames
    {
        #region Infrastructure

        public static IProjectAttributeNames Instance { get; } = new ProjectAttributeNames();


        private ProjectAttributeNames()
        {
        }

        #endregion
    }
}
