using System.Collections.Immutable;
using Bogus;
using LinkerBoard.API.Domain;

namespace LinkerBoard.API.Data;

internal sealed class DatabaseSeeder
{
    public ICollection<User> Users { get; } = [];

    public DatabaseSeeder()
    {
        Users = GenerateUsers();
    }
    
    private ICollection<User> GenerateUsers(int generateCount = 100)
    {
        Faker<User> usersFaker = new Faker<User>()
            .RuleFor(x => x.Id, _ => Guid.NewGuid())
            .RuleFor(x => x.Username, y => y.Person.UserName)
            .RuleFor(x => x.Email, y => y.Person.Email)
            .RuleFor(x => x.CreatedAt, y => y.Date.PastDateOnly())
            .RuleFor(x => x.UpdatedAt, y => y.Date.PastDateOnly().OrNull(y, 0.7f));
        
        ImmutableList<User> users = Enumerable.Range(1, generateCount)
            .Select(i => SeedRow(usersFaker, i))
            .ToImmutableList();
        
        return users;
    }
    
    private static T SeedRow<T>(Faker<T> faker, int rowId)
        where T : class
    {
        T recordRow = faker.UseSeed(rowId).Generate();
        return recordRow;
    }
}