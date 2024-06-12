using System.Collections.Immutable;
using Bogus;
using LinkerBoard.API.Domain;

namespace LinkerBoard.API.Data;

internal sealed class DatabaseSeeder
{
    public ICollection<User> Users { get; } = [];

    public ICollection<LinkBoard> LinkBoards { get; } = [];

    public ICollection<Link> Links { get; } = [];

    public DatabaseSeeder()
    {
        Users = GenerateUsers();
        LinkBoards = GenerateLinkBoards();
        Links = GenerateLinks();
    }

    private ICollection<User> GenerateUsers(int generateCount = 100)
    {
        Faker<User> usersFaker = new Faker<User>()
            .UseSeed(1000)
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

    private ICollection<LinkBoard> GenerateLinkBoards(int generateCount = 60)
    {
        int start = 1;
        Faker<LinkBoard> linkBoardsFaker = new Faker<LinkBoard>()
            .UseSeed(7111)
            .RuleFor(x => x.Id, _ => start++)
            .RuleFor(x => x.Title, y => y.Company.CompanyName())
            .RuleFor(x => x.CreatedAt, y => y.Date.PastDateOnly())
            .RuleFor(x => x.UpdatedAt, y => y.Date.PastDateOnly().OrNull(y, 0.7f))
            .RuleFor(x => x.UserId, y => y.PickRandom(Users).Id);

        ImmutableList<LinkBoard> linkBoards = Enumerable.Range(1, generateCount)
            .Select(i => SeedRow(linkBoardsFaker, i))
            .ToImmutableList();

        return linkBoards;
    }

    private ICollection<Link> GenerateLinks(int generateCount = 200)
    {
        long start = 1;

        Faker<Link> linksFaker = new Faker<Link>()
            .UseSeed(9999)
            .RuleFor(x => x.Id, _ => start++)
            .RuleFor(x => x.Title, y => y.Company.Bs())
            .RuleFor(x => x.Note, y => y.Name.JobDescriptor().OrNull(y, 0.8f))
            .RuleFor(x => x.Url, y => y.Internet.Url())
            .RuleFor(x => x.CreatedAt, y => y.Date.PastDateOnly())
            .RuleFor(x => x.UpdatedAt, y => y.Date.PastDateOnly().OrNull(y, 0.7f))
            .RuleFor(x => x.LinkBoardId, y => y.PickRandom(LinkBoards).Id);

        ImmutableList<Link> links = Enumerable.Range(1, generateCount)
            .Select(i => SeedRow(linksFaker, i))
            .ToImmutableList();

        return links;
    }

    private static T SeedRow<T>(Faker<T> faker, int rowId)
        where T : class
    {
        T recordRow = faker.UseSeed(rowId).Generate();
        return recordRow;
    }
}