using DeleteContact.Application.Persistence;
using DeleteContact.Domain.Entities;

namespace DeleteContact.Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{

    private readonly ApplicationDbContext _dbContext;

    public ContactRepository(ApplicationDbContext dbContext) : base()
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Contact?> GetAsync(Guid id)
    {
        return await _dbContext.Contacts.FindAsync(id);
    }
}
