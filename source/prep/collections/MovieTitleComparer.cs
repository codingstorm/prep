using System.Collections.Generic;

namespace prep.collections
{
  public class MovieTitleComparer : IComparer<Movie>
  {
    public int Compare(Movie x, Movie y)
    {
      //>0 x > y
      //<0 x < y
      //=0 x = y
      return x.title.CompareTo(y.title);
    }
  }
}