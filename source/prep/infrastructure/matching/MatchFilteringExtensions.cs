﻿using System;
using prep.infrastructure.ranges;

namespace prep.infrastructure.matching
{
  public static class MatchFilteringExtensions
  {
    public static IMatchA<ItemToMatch> equal_to<ItemToMatch,PropertyType>(this MatchFilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType value)
    {
        return equal_to_any(extension_point, value);
    }

    public static IMatchA<ItemToMatch> create_from<ItemToMatch,PropertyType>(this MatchFilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,IMatchA<PropertyType> value_criteria)
    {
        return new PropertyMatch<ItemToMatch, PropertyType>(extension_point.accessor, extension_point.negate ? new NegatingMatch<PropertyType>(value_criteria) : value_criteria);
    }

    public static IMatchA<ItemToMatch> equal_to_any<ItemToMatch,PropertyType>(this MatchFilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,params PropertyType[] values)
    {
      return create_from(extension_point,new IsEqualToAny<PropertyType>(values));
    }

    public static IMatchA<ItemToMatch> greater_than<ItemToMatch,PropertyType>(this MatchFilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
    {
      return create_from(extension_point,new FallsInRange<PropertyType>(new GreaterThanValueRange<PropertyType>(value)));
    }

    public static IMatchA<ItemToMatch> between<ItemToMatch,PropertyType>(this MatchFilteringExtensionPoint<ItemToMatch,PropertyType> extension_point,PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
    {
      return create_from(extension_point,new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));

    }
  }
}
