using VideoShop.Common.Records;
using VideoShop.Common.Enums;
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
    public Movie AddMovie (string title, int genreId, int year)
    {
        try
        {
            if (string.IsNullOrEmpty(title)) { throw new ArgumentException("A movie needs a title..."); }
            if(year < 1800) { throw new ArgumentException("No movie existed before year 1800 you dumb fuck"); }
            var genre = _genres.SingleOrDefault(g => g.Id.Equals(genreId));
            if (genre == default) { throw new ArgumentException("Could not find genre"); }
            Movie movie = new(Movies.Count+1, title, year,genre);
            _movies.Add(movie);
            return _movies.Single(m => m.Id.Equals(movie.Id));
        }
        catch { throw; }
    }
    private void SeedData() 
    {
        _genres.AddGenre("Action").AddGenre("Fantasy").AddGenre("Crime").AddGenre("Romance").AddGenre("Drama").AddGenre("Horror").AddGenre("Adventure");

        var action = _genres.First(g => g.Equals("Action"));
        var fantasy = _genres.First(g => g.Equals("Fantasy"));
        var crime = _genres.First(g => g.Equals("Crime"));
        var romance = _genres.First(g => g.Equals("Romance"));
        var drama = _genres.First(g => g.Equals("Drama"));
        var horror = _genres.First(g => g.Equals("Horror"));
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
        if(name == default && name.Length.Equals(0)) { throw new ArgumentException("You cannot add nothing idiot"); }
        _genres.AddGenre(name);
    }
}
