

namespace VideoShop.Common.Records;

public record Genre
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public Genre(int id, string name) => (Id, Name) = (id, name);

}
