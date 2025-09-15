using System;

using F10Y.T0003;


namespace F10Y.L0006.Z000
{
    [ValuesMarker]
    public partial interface IOutputTypes
    {
        /// <summary>
        /// Library - The assumed output type if an output type node is not present in a project element.
        /// </summary>
        public string Assumption_IfNone => this.Library;


        /// <summary>
        /// Library - The assumed output type if an output type node is not present in a project element.
        /// </summary>
        public string Default => this.Library;

        /// <summary>
        /// Exe - Creates a console application.
        /// </summary>
        public const string Exe_Constant = "Exe";

        /// <inheritdoc cref="Exe_Constant"/>
        public string Exe => Exe_Constant;

        /// <summary>
        /// Library - Creates a code library.
        /// </summary>
        public const string Library_Constant = "Library";

        /// <inheritdoc cref="Library_Constant"/>
        public string Library => Library_Constant;

        /// <summary>
        /// Module - Creates a module.
        /// <para>(Unclear what a "module" is...)</para>
        /// </summary>
        public const string Module_Constant = "Module";

        /// <inheritdoc cref="Module_Constant"/>
        public string Module => Module_Constant;

        /// <summary>
        /// WinExe - Creates a module.
        /// </summary>
        public const string WinExe_Constant = "WinExe";

        /// <inheritdoc cref="WinExe_Constant"/>
        public string WinExe => WinExe_Constant;
    }
}
