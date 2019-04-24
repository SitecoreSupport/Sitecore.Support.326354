namespace Sitecore.Support.ContentSearch.FieldReaders
{
  using Sitecore.Abstractions;
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.FieldReaders;
  using Sitecore.Data.Fields;
  using Sitecore.Diagnostics;

  [UsedImplicitly]
  public class LinkFieldReader : FieldReader
  {
    public override object GetFieldValue(IIndexableDataField indexableField)
    {
      Field field = indexableField as SitecoreItemDataField;
      BaseFieldTypeManager instance = ContentSearchManager.Locator.GetInstance<BaseFieldTypeManager>();
      Assert.IsNotNull(instance, "fieldTypeManager != null");
      if (instance.GetField(field) is LinkField)
      {
        return new LinkField(field).TargetID.ToGuid();
      }

      return null;
    }
  }
}