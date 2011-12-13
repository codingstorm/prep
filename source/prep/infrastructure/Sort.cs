using System;
using System.Collections.Generic;
using prep.infrastructure.matching;

namespace prep.infrastructure
{
    using prep.collections;

    public class Sort<ItemToSort>
  {
    public static IComparer<ItemToSort> by_descending<PropertyType>(Accessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable
    {
        return new AnonymoustOrderableSortComparer<ItemToSort>(new AnonymousSortItemComparer<ItemToSort, PropertyType>(accessor), SortOrder.Descending);
    }

    public static IComparer<ItemToSort> by<PropertyType>(Accessor<ItemToSort, PropertyType> accessor) where PropertyType : IComparable
    {
        return new AnonymousSortItemComparer<ItemToSort, PropertyType>(accessor);
    }
  }

    public enum SortOrder {
        Ascending,
        Descending
    }

    public class AnonymousSortItemComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
    where PropertyType: IComparable{

        private readonly Accessor<ItemToSort, PropertyType> accessor;

        public AnonymousSortItemComparer(Accessor<ItemToSort, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return accessor(x).CompareTo(accessor(y));
        }
    }


    public class AnonymoustOrderableSortComparer<ItemToSort> : IComparer<ItemToSort>
    {
        private readonly IComparer<ItemToSort> comparer;

        private readonly SortOrder sortOrder;

        public AnonymoustOrderableSortComparer(IComparer<ItemToSort> comparer, SortOrder sortOrder)
        {
            this.comparer = comparer;
            this.sortOrder = sortOrder;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            int result = this.comparer.Compare(x, y);

            if (this.sortOrder == SortOrder.Descending) return result * -1;

            return result;
        }
    }
}