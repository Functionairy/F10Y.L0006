using System;


namespace F10Y.L0006
{
    public static class Instances
    {
        public static Z000.IProjectAttributeNames ProjectAttributeNames => Z000.ProjectAttributeNames.Instance;
        public static Z000.IProjectNodeNames ProjectNodeNames => Z000.ProjectNodeNames.Instance;
        public static L0000.IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static L0000.IStrings Strings => L0000.Strings.Instance;
        public static IValues Values => L0006.Values.Instance;
        public static L0000.IXAttributeOperator XAttributeOperator => L0000.XAttributeOperator.Instance;
        public static L0000.IXElementOperator XElementOperator => L0000.XElementOperator.Instance;
    }
}