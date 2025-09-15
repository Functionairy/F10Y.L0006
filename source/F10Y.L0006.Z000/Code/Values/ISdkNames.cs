using System;

using F10Y.T0003;
using F10Y.T0011;


namespace F10Y.L0006.Z000
{
    [ValuesMarker]
    public partial interface ISdkNames
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Raw.ISdkNames _Raw => Raw.SdkNames.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Raw.ISdkNames.Microsoft_NET_Sdk"/>
        string Assumption_IfNone => _Raw.Microsoft_NET_Sdk;


        /// <inheritdoc cref="Raw.ISdkNames.Microsoft_NET_Sdk"/>
        string Microsoft_NET_Sdk => _Raw.Microsoft_NET_Sdk;

        /// <inheritdoc cref="Raw.ISdkNames.Microsoft_NET_Sdk_BlazorWebAssembly"/>
        string Microsoft_NET_Sdk_BlazorWebAssembly => _Raw.Microsoft_NET_Sdk_BlazorWebAssembly;

        /// <inheritdoc cref="Raw.ISdkNames.Microsoft_NET_Sdk_Razor"/>
        string Microsoft_NET_Sdk_Razor => _Raw.Microsoft_NET_Sdk_Razor;

        /// <inheritdoc cref="Raw.ISdkNames.Microsoft_NET_Sdk_Web"/>
        string Microsoft_NET_Sdk_Web => _Raw.Microsoft_NET_Sdk_Web;

        /// <inheritdoc cref="Raw.ISdkNames.Microsoft_NET_Sdk_WindowsDesktop"/>
        string Microsoft_NET_Sdk_WindowsDesktop => _Raw.Microsoft_NET_Sdk_WindowsDesktop;
    }
}
