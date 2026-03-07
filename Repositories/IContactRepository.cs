using ContactBook.Models;
using ContactBook.Models.DTOs;

namespace ContactBook.Repositories;

public interface IContactRepository
{
    Task<PagedResult<Contact>> GetAllAsync(string? search, string? company, int page, int pageSize);
    Task<Contact?> GetByIdAsync(int id);
    Task<Contact> CreateAsync(Contact contact);
    Task<Contact?> UpdateAsync(int id, Contact contact);
    Task<bool> DeleteAsync(int id);
}
