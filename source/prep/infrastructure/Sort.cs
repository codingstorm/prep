using System;
using prep.infrastructure.matching;

namespace prep.infrastructure
{
  public class Sort<ItemToSort>
  {
    public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(Accessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return new ComparerBuilder<ItemToSort>(new ReverseComparer<ItemToSort>(by(accessor)));
    }

    public static ComparerBuilder<ItemToSort> by<PropertyType>(Accessor<ItemToSort, PropertyType> accessor,
                                                               params PropertyType[] fixed_order)
    {
      return new ComparerBuilder<ItemToSort>(new AccessorComparer<ItemToSort, PropertyType>(accessor,
                                                                                            new FixedComparer
                                                                                              <PropertyType>(fixed_order)));
    }

    public static ComparerBuilder<ItemToSort> by<PropertyType>(Accessor<ItemToSort, PropertyType> accessor)
      where PropertyType : IComparable<PropertyType>
    {
      return new ComparerBuilder<ItemToSort>(new AccessorComparer<ItemToSort, PropertyType>(accessor,
                                                                                            new ComparableComparer
                                                                                              <PropertyType>()));
    }
  }
}