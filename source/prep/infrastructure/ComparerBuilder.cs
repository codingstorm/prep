using System;
using System.Collections.Generic;
using prep.infrastructure.matching;

namespace prep.infrastructure
{
  public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
  {
    IComparer<ItemToSort> comparer;

    public ComparerBuilder(IComparer<ItemToSort> comparer)
    {
      this.comparer = comparer;
    }

    public int Compare(ItemToSort x, ItemToSort y)
    {
      return comparer.Compare(x, y);
    }

    public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(Accessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      throw new NotImplementedException();
    }

    public ComparerBuilder<ItemToSort> then_by<PropertyType>(Accessor<ItemToSort, PropertyType> accessor,
                                                             params PropertyType[] order)
    {
      throw new NotImplementedException();
    }

    public ComparerBuilder<ItemToSort> then_by<PropertyType>(Accessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      throw new NotImplementedException();
    }
  }
}