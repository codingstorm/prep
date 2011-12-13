using System;
using System.Collections.Generic;
using prep.infrastructure.matching;

namespace prep.infrastructure.sorting
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

    ComparerBuilder<ItemToSort> chained_with(IComparer<ItemToSort> next)
    {
      return new ComparerBuilder<ItemToSort>(new ChainedComparer<ItemToSort>(comparer, next));
    }

    public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(Accessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return chained_with(Sort<ItemToSort>.by_descending(accessor));
    }

    public ComparerBuilder<ItemToSort> then_by<PropertyType>(Accessor<ItemToSort, PropertyType> accessor,
                                                             params PropertyType[] fixed_order)
    {
      return chained_with(Sort<ItemToSort>.by(accessor, fixed_order));
    }

    public ComparerBuilder<ItemToSort> then_by<PropertyType>(Accessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return chained_with(Sort<ItemToSort>.by(accessor));
    }
  }
}