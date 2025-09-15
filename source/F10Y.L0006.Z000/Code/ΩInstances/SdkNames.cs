using System;


namespace F10Y.L0006.Z000
{
    public class SdkNames : ISdkNames
    {
        #region Infrastructure

        public static ISdkNames Instance { get; } = new SdkNames();


        private SdkNames()
        {
        }

        #endregion
    }
}


namespace F10Y.L0006.Z000.Raw
{
    public class SdkNames : ISdkNames
    {
        #region Infrastructure

        public static ISdkNames Instance { get; } = new SdkNames();


        private SdkNames()
        {
        }

        #endregion
    }
}
