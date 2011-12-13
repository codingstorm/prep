using System.Collections.Generic;

namespace prep.infrastructure
{
  public class ReverseComparer<ItemToSort> : IComparer<ItemToSort>
  {
    IComparer<ItemToSort> to_reverse;

    public ReverseComparer(IComparer<ItemToSort> to_reverse)
    {
      this.to_reverse = to_reverse;
    }

    public int Compare(ItemToSort x, ItemToSort y)
    {
      return -to_reverse.Compare(x, y);
    }
  }
}