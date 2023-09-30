using VideoShop.Common.Classes;
using VideoShop.Common.Records;

namespace VideoShop.Business.Classes;

public class MovieShopProcessor
{
    private readonly Shop _shop;
    public MovieShopProcessor(Shop shop) => _shop = shop;

    public IEnumerable<Movie> GetMovies(string title)
    {
        return _shop.FilterMoviesOnTitle(title);
    }
    public IEnumerable<Genre> GetGenres()
    {
        return _shop.Genres;
    }

    public void AddMovie(string title, int genreId, int year) 
    {
        _shop.AddMovie(title, genreId, year);
    }
    public void AddGenre(string name) 
    {
        _shop.AddGenre(name);
    }
    public void GetNumberOfMoviesInGanre(int genreId)
    {
        _shop.GetMoviesInGenre(genreId);
    }
    public void GetGenresInMovie()
    {
        _shop.GetGenresInMovie();
    }




}
