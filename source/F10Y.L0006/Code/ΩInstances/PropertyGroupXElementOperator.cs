using System;


namespace F10Y.L0006
{
    public class PropertyGroupXElementOperator : IPropertyGroupXElementOperator
    {
        #region Infrastructure

        public static IPropertyGroupXElementOperator Instance { get; } = new PropertyGroupXElementOperator();


        private PropertyGroupXElementOperator()
        {
        }

        #endregion
    }
}
