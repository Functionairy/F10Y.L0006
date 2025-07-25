using System;
using System.Xml.Linq;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0006
{
    [FunctionsMarker]
    public partial interface IPropertyGroupXElementOperator :
        Utilities.IProjectXElementsOperator,
        IGroupElementOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public IGroupElementOperator _GroupElementOperator => GroupElementOperator.Instance;

        [Ignore]
        public Utilities.IProjectXElementsOperator _ProjectXElementsOperator_Utilities => ProjectXElementsOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        #region RepositoryUrl

        public string Get_RepositoryUrl(XElement propertyGroupElement)
            => Instances.XElementOperator.Get_Child_Value(
                propertyGroupElement,
                Instances.ProjectElementNames.RepositoryUrl);

        public bool Has_RepositoryUrl(
            XElement propertyGroupElement,
            out string repositoryUrl_OrDefault)
            => Instances.XElementOperator.Has_Child_Value(
                propertyGroupElement,
                Instances.ProjectElementNames.RepositoryUrl,
                out repositoryUrl_OrDefault);

        public void Set_RepositoryUrl(
            XElement propertyGroupElement,
            string repositoryUrl)
            => Instances.XElementOperator.Set_Child_Value(
                propertyGroupElement,
                Instances.ProjectElementNames.RepositoryUrl,
                repositoryUrl);

        #endregion
    }
}
