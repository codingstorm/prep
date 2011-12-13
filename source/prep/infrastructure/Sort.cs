using System;
using System.Collections.Generic;
using prep.infrastructure.matching;

namespace prep.infrastructure
{
  public class Sort<ItemToSort>
  {
    public static IComparer<ItemToSort> by_descending<PropertyType>(Accessor<ItemToSort, PropertyType> accessor)
    {
      throw new NotImplementedException();
    }

    public static IComparer<ItemToSort> by<PropertyType>(Accessor<ItemToSort, PropertyType> accessor)
    {
      throw new NotImplementedException();
    }
  }
}