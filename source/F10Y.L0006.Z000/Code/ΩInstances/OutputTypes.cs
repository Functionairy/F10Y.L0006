using System;


namespace F10Y.L0006.Z000
{
    public class OutputTypes : IOutputTypes
    {
        #region Infrastructure

        public static IOutputTypes Instance { get; } = new OutputTypes();


        private OutputTypes()
        {
        }

        #endregion
    }
}
