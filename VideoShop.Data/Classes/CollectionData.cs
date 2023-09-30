

using VideoShop.Common.Records;
using VideoShop.Data.Interfaces;

namespace VideoShop.Data.Classes;

public class CollectionData : IData
{
    readonly List<Movie> _movies = new List<Movie>();
    readonly List<Genre> _genres = new List<Genre>();

    public IEnumerable<Genre> GetGenres()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Movie> GetMovies()
    {
        throw new NotImplementedException();
    }
}
