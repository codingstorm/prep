using System;
using System.Collections.Generic;

namespace prep.infrastructure.matching
{
  public class MatchFactory<ItemToMatch, PropertyType>
  {
    Accessor<ItemToMatch, PropertyType> accessor;

    public MatchFactory(Accessor<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> equal_to(PropertyType value)
    {
      return new AnonymousMatch<ItemToMatch>(x => accessor(x).Equals(value));
    }

    public IMatchA<ItemToMatch> equal_to_any(params PropertyType[] values)
    {
      return new AnonymousMatch<ItemToMatch>(x => new List<PropertyType>(values).Contains(accessor(x)));
    }

    public IMatchA<ItemToMatch> not_equal_to(PropertyType value)
    {
      throw new NotImplementedException();
    }
  }
}