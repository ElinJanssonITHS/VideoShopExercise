using VideoShop.Common.Records;
using VideoShop.Common.Enums;

namespace VideoShop.Data.Interfaces;

public interface IData
{
    IEnumerable<Movie> GetMovies();
    IEnumerable<Genre> GetGenres();
}
