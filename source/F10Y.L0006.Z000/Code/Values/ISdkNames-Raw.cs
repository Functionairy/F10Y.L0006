using System;

using F10Y.T0003;


namespace F10Y.L0006.Z000.Raw
{
    [ValuesMarker]
    public partial interface ISdkNames
    {
        /// <summary>
        /// <para><value>Microsoft.NET.Sdk</value></para>
        /// </summary>
        public const string Microsoft_NET_Sdk_Constant = "Microsoft.NET.Sdk";

        /// <inheritdoc cref="Microsoft_NET_Sdk_Constant"/>
        public string Microsoft_NET_Sdk => Microsoft_NET_Sdk_Constant;

        /// <summary>
        /// <para><value>Microsoft.NET.Sdk.BlazorWebAssembly</value></para>
        /// </summary>
        public const string Microsoft_NET_Sdk_BlazorWebAssembly_Constant = "Microsoft.NET.Sdk.BlazorWebAssembly";

        /// <inheritdoc cref="Microsoft_NET_Sdk_BlazorWebAssembly_Constant"/>
        public string Microsoft_NET_Sdk_BlazorWebAssembly => Microsoft_NET_Sdk_BlazorWebAssembly_Constant;

        /// <summary>
        /// <para><value>Microsoft.NET.Sdk.Razor</value></para>
        /// </summary>
        public const string Microsoft_NET_Sdk_Razor_Constant = "Microsoft.NET.Sdk.Razor";

        /// <inheritdoc cref="Microsoft_NET_Sdk_Razor_Constant"/>
        public string Microsoft_NET_Sdk_Razor => Microsoft_NET_Sdk_Razor_Constant;

        /// <summary>
        /// <para><value>Microsoft.NET.Sdk.Web</value></para>
        /// </summary>
        public const string Microsoft_NET_Sdk_Web_Constant = "Microsoft.NET.Sdk.Web";

        /// <inheritdoc cref="Microsoft_NET_Sdk_Web_Constant"/>
        public string Microsoft_NET_Sdk_Web => Microsoft_NET_Sdk_Web_Constant;

        /// <summary>
        /// <para><value>Microsoft.NET.Sdk.WindowsDesktop</value></para>
        /// </summary>
        public const string Microsoft_NET_Sdk_WindowsDesktop_Constant = "Microsoft.NET.Sdk.WindowsDesktop";

        /// <inheritdoc cref="Microsoft_NET_Sdk_WindowsDesktop_Constant"/>
        public string Microsoft_NET_Sdk_WindowsDesktop => Microsoft_NET_Sdk_WindowsDesktop_Constant;
    }
}
