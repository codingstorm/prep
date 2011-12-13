using System;
using System.Collections.Generic;

namespace prep.infrastructure
{
  public class ComparableComparer<ItemToCompare> : IComparer<ItemToCompare> where ItemToCompare : IComparable<ItemToCompare>
  {
    public int Compare(ItemToCompare x, ItemToCompare y)
    {
      return x.CompareTo(y);
    }
  }
}