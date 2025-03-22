using DeleteContact.Domain.Entities;

namespace DeleteContact.Application.Persistence;

public interface IContactRepository
{
    Task<Contact?> GetAsync(Guid id);
}
