

namespace VideoShop.Common.Records;

public record Genre
{
    public int Id { get; }
    public string Name { get; } = string.Empty;
    public Genre(int id, string name) => (Id, Name) = (id, name);

}
