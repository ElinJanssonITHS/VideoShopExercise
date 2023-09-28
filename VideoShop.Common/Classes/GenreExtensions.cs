using VideoShop.Common.Records;

namespace VideoShop.Common.Classes;

public static class GenreExtensions
{
    public static Movie AddGenre (this Movie movie, Genre? genre)
    {
        
        if (genre != default) movie.Genres?.Add(genre);
        return movie;
    }
    public static List<Genre> AddGenre(this List<Genre> genres, string name)
    {
        if (name != default && name.Length > 0) genres.Add(new Genre(genres.Count+1,name));
        return genres;
    }
    
}
