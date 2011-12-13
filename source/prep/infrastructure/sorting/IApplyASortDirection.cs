using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
  public interface IApplyASortDirection
  {
    IComparer<T> apply_to<T>(IComparer<T> comparer);
  }

  public class SortOrder
  {
    public static readonly IApplyASortDirection ascending = new AscendingSortDirection();
    public static readonly IApplyASortDirection descending = new DescendingSortDirection();

    class AscendingSortDirection : IApplyASortDirection
    {
      public IComparer<T> apply_to<T>(IComparer<T> comparer)
      {
        return comparer;
      }
    }

    class DescendingSortDirection : IApplyASortDirection
    {
      public IComparer<T> apply_to<T>(IComparer<T> comparer)
      {
        return new ReverseComparer<T>(comparer);
      }
    }
  }
}