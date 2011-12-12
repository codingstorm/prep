using System;

namespace prep.collections
{
    public class Movie : IEquatable<Movie> {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        bool IEquatable<Movie>.Equals(Movie other) {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return Equals(other.title, this.title);
        }

        public override bool Equals(object other) {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            if (other.GetType() != typeof(Movie)) {
                return false;
            }
            return this.Equals((Movie)other);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode() {
            return (this.title != null ? this.title.GetHashCode() : 0);
        }

        public static bool operator ==(Movie left, Movie right) {
            return Equals(left, right);
        }

        public static bool operator !=(Movie left, Movie right) {
            return !Equals(left, right);
        }
  }
}