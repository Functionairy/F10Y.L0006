using System;


namespace F10Y.L0006
{
    public static class Instances
    {
        public static IBooleanOperator BooleanOperator => L0006.BooleanOperator.Instance;
        public static IPathOperator PathOperator => L0006.PathOperator.Instance;
        public static Z000.IProjectAttributeNames ProjectAttributeNames => Z000.ProjectAttributeNames.Instance;
        public static Z000.IProjectElementNames ProjectElementNames => Z000.ProjectElementNames.Instance;
        public static Z000.IProjectNodeNames ProjectNodeNames => Z000.ProjectNodeNames.Instance;
        public static IProjectXElementOperator ProjectXElementOperator => L0006.ProjectXElementOperator.Instance;
        public static IProjectXElementsOperator ProjectXElementsOperator => L0006.ProjectXElementsOperator.Instance;
        public static L0000.IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static L0000.IStrings Strings => L0000.Strings.Instance;
        public static ITokenSeparators TokenSeparators => L0006.TokenSeparators.Instance;
        public static IValues Values => L0006.Values.Instance;
        public static L0000.IXAttributeOperator XAttributeOperator => L0000.XAttributeOperator.Instance;
        public static L0000.IXElementOperator XElementOperator => L0000.XElementOperator.Instance;
    }
}