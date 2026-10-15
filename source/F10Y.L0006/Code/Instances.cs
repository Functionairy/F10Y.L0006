using System;


namespace F10Y.L0006
{
#pragma warning disable IDE1006 // Naming Styles
    public interface Instances :
#pragma warning restore IDE1006 // Naming Styles
        Instances_Internal,
        L0000.Instances_Internal
    {
        public static IBooleanOperator BooleanOperator => L0006.BooleanOperator.Instance;
        public static L0003.L001.IHasOperator HasOperator => L0003.L001.HasOperator.Instance;
        public static L0003.IOverloadTokenOperator OverloadTokenOperator => L0003.OverloadTokenOperator.Instance;
        public static new IPathOperator PathOperator => L0006.PathOperator.Instance;
        public static Z000.IProjectAttributeNames ProjectAttributeNames => Z000.ProjectAttributeNames.Instance;
        public static Z000.IProjectElementNames ProjectElementNames => Z000.ProjectElementNames.Instance;
        public static Z000.IProjectNodeNames ProjectNodeNames => Z000.ProjectNodeNames.Instance;
        public static IProjectXElementOperator ProjectXElementOperator => L0006.ProjectXElementOperator.Instance;
        public static IProjectXElementsOperator ProjectXElementsOperator => L0006.ProjectXElementsOperator.Instance;
        public static L0001.L002.IResultOperator ResultOperator => L0001.L002.ResultOperator.Instance;
        public static new ITokenSeparators TokenSeparators => L0006.TokenSeparators.Instance;
        public static new IValues Values => L0006.Values.Instance;
        public static IWarningsOperator WarningsOperator => L0006.WarningsOperator.Instance;
    }


    public interface Instances_Internal
    {
        public static IPathOperator PathOperator => L0006.PathOperator.Instance;
        public static ITokenSeparators TokenSeparators => L0006.TokenSeparators.Instance;
        public static IValues Values => L0006.Values.Instance;
    }
}