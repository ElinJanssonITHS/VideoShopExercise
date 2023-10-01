using VideoShop.Common.Records;
using VideoShop.Common.Enums;
using System.Collections.Generic;

namespace VideoShop.Common.Classes;

public class Shop
{
    private List<Movie> _movies = new();
    private List<Genre> _genres = new();
    public SortOrder SortOrder { get; }
    public List<Movie> Movies => 
        SortOrder.Equals(SortOrder.Ascending) 
        ? _movies.OrderBy(m => m.Title).ToList()
        : _movies.OrderByDescending(m => m.Title).ToList();
    public List<Genre> Genres =>
        SortOrder.Equals(SortOrder.Ascending)
        ? _genres.OrderBy(g => g.Name).ToList()
        : _genres.OrderByDescending(g => g.Name).ToList();
    public Shop (SortOrder sortOrder)
    {
        SortOrder = sortOrder;
        SeedData();
    }
    public Movie AddMovie(string title, int year, int genreId)
    {
        try
        {
            if (title == default || title.Length.Equals(0)) { throw new ArgumentException("A movie needs a title..."); }
            if(year < 1800) { throw new ArgumentException("No movie existed before year 1800 you dumb fuck"); }
            var genre = _genres.SingleOrDefault(g => g.Id.Equals(genreId));
            if (genre == default) { throw new ArgumentException("Could not find genre"); }
            var movie = new Movie(Movies.Count+1, title, year,genre);
            _movies.Add(movie);
            return _movies.Single(m => m.Id.Equals(movie.Id));
        }
        catch { throw; }
    }
    private void SeedData() 
    {
        _genres.AddGenre("Action").AddGenre("Fantasy").AddGenre("Crime").AddGenre("Romance").AddGenre("Drama").AddGenre("Horror").AddGenre("Adventure");

        var action = _genres.First(g => g.Name.Equals("Action"));
        var fantasy = _genres.First(g => g.Name.Equals("Fantasy"));
        var crime = _genres.First(g => g.Name.Equals("Crime"));
        var romance = _genres.First(g => g.Name.Equals("Romance"));
        var drama = _genres.First(g => g.Name.Equals("Drama"));
        var horror = _genres.First(g => g.Name.Equals("Horror"));
        var adventure = _genres.First(g => g.Name.Equals("Adventure"));

        AddMovie("The Shawshank Redemption", 1994, drama.Id);
        AddMovie("The Godfather", 1972, drama.Id).AddGenre(crime);
        AddMovie("The Dark Knight", 2008, action.Id).AddGenre(drama).AddGenre(crime);
        AddMovie("Forrest Gump", 1994, romance.Id).AddGenre(drama);
        AddMovie("LOTR: The Return of the King", 2003, fantasy.Id).AddGenre(adventure).AddGenre(drama);
        AddMovie("LOTR: The Two Towers", 2002, fantasy.Id).AddGenre(adventure).AddGenre(drama);
        AddMovie("LOTR: The Fellowship of the Ring", 2001, fantasy.Id).AddGenre(adventure).AddGenre(drama);

    }
    public void AddGenre(string name)
    {
        if(name == default || name.Length.Equals(0)) { throw new ArgumentException("You cannot add nothing idiot"); }
        _genres.AddGenre(name);
    }
    public List<Genre> GetGenresInMovie()
    {
        List<Genre> genres = new();
        try
        {
            foreach (var movie in Movies)
            {
                var joinedGenres = Genres.Join(
                    movie.Genres,
                    genre => genre.Id,
                    movieGenre => movieGenre.Id,
                    (genre, movieGenre) => genre);
                genres.AddRange(joinedGenres);
            }
        }
        catch { }
        return genres.Distinct().OrderBy(g => g.Name).ToList();
    }
    public List<Movie> GetMoviesInGenre(int genreId)
    {
        List<Movie> moviesInGenre = new();
        try
        {
            foreach(var movie in Movies)
            {
                if (movie.Genres.Any(g => g.Id.Equals(genreId)))
                {
                    moviesInGenre.Add(movie);
                }
                //movie.Genres.Where(m => m.Id.Equals(genreId)).
            }   
        }
        catch { }
        //var movies = Movies.Where(); Testar att göra ovanstående loop med ett längre LINQ-uttryck
        
        return moviesInGenre;
    }
    public int GetNumberOfMoviesInGenre(int genreId) 
    {
        //var movies = GetMoviesInGenre(genreId);
        //return movies.Count; 
        try
        {
            var genre = Genres.Single(g => g.Id.Equals(genreId));
            return Movies.Count(f => f.Genres.Contains(genre));
        }
        catch
        {
            throw;
        }
    }
    public List<Movie> FilterMoviesOnTitle(string titleSearch)
    {
        try
        {
            if (titleSearch == default || titleSearch.Length <= 1)     
            {
                return Movies;
            }
            return Movies.Where(m => m.Title.ToLower().Contains(titleSearch.ToLower())).ToList();
        }
        catch
        {
            _movies = new();
            return _movies;
        }
    }
    public List<Movie> FilterMoviesOnTitle(string titleSearch, int skip, int take)
    {
        IEnumerable<Movie> movies;
        try
        {
            movies = FilterMoviesOnTitle(titleSearch);
            if (skip >= 0 ) movies = movies.Skip(skip); 
            if (take > 0 ) movies = movies.Take(take);

        }
        catch 
        {
            movies = new List<Movie>();
        }
        
        return movies.ToList(); 
    }
    public List<Movie> UnionMovies()
    {
        IEnumerable<Movie> movies;
        try
        {
            var movies1 = Movies.Take(2);
            var movies2 = Movies.Skip(4).Take(1);
            movies = movies1.Union(movies2);
        }
        catch
        {
            movies = new List<Movie>();
        }
        return movies.ToList();
    }

}
