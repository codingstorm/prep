using System;
using System.Collections.Generic;
using prep.infrastructure.matching;

namespace prep.infrastructure
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<Item> one_at_a_time<Item>(this IEnumerable<Item> items)
    {
      foreach (var item in items) yield return item;
    }

    public static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items, IMatchA<Item> criteria)
    {
      return items.all_items_matching(criteria.matches);
    }

    public static IEnumerable<Item> sort_all_using<Item>(this IEnumerable<Item> items, IComparer<Item> comparer)
    {
      var sorted = new List<Item>(items);
      sorted.Sort(comparer);
      return sorted;
    }

    static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items, Func<Item,bool> condition)
    {
      foreach (var item in items) if (condition(item)) yield return item;
    }
  }
}