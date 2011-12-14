using System;
using System.Collections.Generic;
using prep.infrastructure.sorting;

namespace prep.infrastructure
{
  public static class ComparableEnumerableExtensions
  {
    public static SortedEnumerable<ItemToSort> order_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items,
                                                                                  Accessor<ItemToSort, PropertyType>
                                                                                    accessor,
                                                                                  params PropertyType[] fixed_order)
    {
      return new SortedEnumerable<ItemToSort>(items,Sort<ItemToSort>.by(accessor,fixed_order));
    }

    public static SortedEnumerable<ItemToSort> order_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items,
                                                                                  Accessor<ItemToSort, PropertyType>
                                                                                    accessor) where PropertyType : IComparable<PropertyType>
    {
      return new SortedEnumerable<ItemToSort>(items,Sort<ItemToSort>.by(accessor));
    }

    public static SortedEnumerable<ItemToSort> order_by_descending<ItemToSort, PropertyType>(
      this IEnumerable<ItemToSort> items, Accessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new SortedEnumerable<ItemToSort>(items,Sort<ItemToSort>.by_descending(accessor));
    }
  }
}