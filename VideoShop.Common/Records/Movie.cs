
using VideoShop.Common.Classes;

namespace VideoShop.Common.Records;

public record Movie
{
    public int Id { get; }
    public string Title { get; set; } 
    public int Year { get; set; }
    public List<Genre> Genres { get; } = new();
    public Movie(int id, string title, int year, Genre? genre = default)
    {
        Id = id;
        Title = title;
        Year = year;
        this.AddGenre(genre);
    }
}
