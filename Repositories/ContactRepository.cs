using ContactBook.Data;
using ContactBook.Models;
using ContactBook.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<Contact>> GetAllAsync(string? search, string? company, int page, int pageSize)
    {
        var query = _context.Contacts.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();
            query = query.Where(c =>
                c.FirstName.ToLower().Contains(search) ||
                c.LastName.ToLower().Contains(search) ||
                c.Email.ToLower().Contains(search) ||
                (c.Company != null && c.Company.ToLower().Contains(search)));
        }

        if (!string.IsNullOrWhiteSpace(company))
        {
            query = query.Where(c => c.Company == company);
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Contact>
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        };
    }

    public async Task<Contact?> GetByIdAsync(int id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task<Contact> CreateAsync(Contact contact)
    {
        contact.CreatedAt = DateTime.UtcNow;
        contact.UpdatedAt = DateTime.UtcNow;

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        return contact;
    }

    public async Task<Contact?> UpdateAsync(int id, Contact contact)
    {
        var existingContact = await _context.Contacts.FindAsync(id);

        if (existingContact == null)
            return null;

        existingContact.FirstName = contact.FirstName;
        existingContact.LastName = contact.LastName;
        existingContact.Email = contact.Email;
        existingContact.Phone = contact.Phone;
        existingContact.Company = contact.Company;
        existingContact.Notes = contact.Notes;
        existingContact.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return existingContact;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null)
            return false;

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();

        return true;
    }
}
