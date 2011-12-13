using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
  public class FixedComparer<ItemToSort> : IComparer<ItemToSort>
  {
    IList<ItemToSort> order;

    public FixedComparer(params ItemToSort[] fixed_order)
    {
      this.order = new List<ItemToSort>(fixed_order);

    }

    public int Compare(ItemToSort x, ItemToSort y)
    {
      return order.IndexOf(x).CompareTo(order.IndexOf(y));
    }
  }
}