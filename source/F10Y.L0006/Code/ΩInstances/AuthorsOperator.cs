using System;


namespace F10Y.L0006
{
    public class AuthorsOperator : IAuthorsOperator
    {
        #region Infrastructure

        public static IAuthorsOperator Instance { get; } = new AuthorsOperator();


        private AuthorsOperator()
        {
        }

        #endregion
    }
}
