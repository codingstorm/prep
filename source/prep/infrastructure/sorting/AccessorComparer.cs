using System.Collections.Generic;
using prep.infrastructure.matching;

namespace prep.infrastructure.sorting
{
  public class AccessorComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
  {
    Accessor<ItemToSort, PropertyType> accessor;
    IComparer<PropertyType> real_comparer;

    public AccessorComparer(Accessor<ItemToSort, PropertyType> accessor, IComparer<PropertyType> real_comparer)
    {
      this.accessor = accessor;
      this.real_comparer = real_comparer;
    }

    public int Compare(ItemToSort x, ItemToSort y)
    {
      return real_comparer.Compare(accessor(x), accessor(y));
    }
  }
}