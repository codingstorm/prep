namespace prep.infrastructure
{
  public delegate PropertyType Accessor<in Item, out PropertyType>(Item item);
}