using System;
using System.Collections;
using System.Collections.Generic;
using prep.infrastructure.sorting;

namespace prep.infrastructure
{
  public class SortedEnumerable<ItemToSort> : IEnumerable<ItemToSort>
  {
    IEnumerable<ItemToSort> items;
    ComparerBuilder<ItemToSort> builder;

    public SortedEnumerable(IEnumerable<ItemToSort> items,ComparerBuilder<ItemToSort> builder)
    {
      this.items = items;
      this.builder = builder;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public SortedEnumerable<ItemToSort> then_by_descending<PropertyType>(Accessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new SortedEnumerable<ItemToSort>(items, builder.then_by_descending(accessor));
    }

    public SortedEnumerable<ItemToSort> then_by<PropertyType>(Accessor<ItemToSort, PropertyType> accessor, params PropertyType[] fixed_order)
    {
      return new SortedEnumerable<ItemToSort>(items, builder.then_by(accessor, fixed_order));
    }

    public SortedEnumerable<ItemToSort> then_by<PropertyType>(Accessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new SortedEnumerable<ItemToSort>(items, builder.then_by(accessor));
    }

    public IEnumerator<ItemToSort> GetEnumerator()
    {
      return items.sort_all_using(builder).GetEnumerator();
    }
  }
}