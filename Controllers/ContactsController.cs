using ContactBook.Models;
using ContactBook.Models.DTOs;
using ContactBook.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _repository;

    public ContactsController(IContactRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<ContactDto>>> GetAll(
        [FromQuery] string? search,
        [FromQuery] string? company,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 1;
        if (pageSize > 50) pageSize = 50;

        var result = await _repository.GetAllAsync(search, company, page, pageSize);

        var dtoResult = new PagedResult<ContactDto>
        {
            Items = result.Items.Select(c => MapToDto(c)).ToList(),
            TotalCount = result.TotalCount,
            Page = result.Page,
            PageSize = result.PageSize,
            TotalPages = result.TotalPages
        };

        return Ok(dtoResult);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContactDto>> GetById(int id)
    {
        var contact = await _repository.GetByIdAsync(id);

        if (contact == null)
            return NotFound(new { message = "Contact not found" });

        return Ok(MapToDto(contact));
    }

    [HttpPost]
    public async Task<ActionResult<ContactDto>> Create(CreateContactDto dto)
    {
        var contact = new Contact
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Company = dto.Company,
            Notes = dto.Notes
        };

        var created = await _repository.CreateAsync(contact);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, MapToDto(created));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ContactDto>> Update(int id, UpdateContactDto dto)
    {
        var contact = new Contact
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Company = dto.Company,
            Notes = dto.Notes
        };

        var updated = await _repository.UpdateAsync(id, contact);

        if (updated == null)
            return NotFound(new { message = "Contact not found" });

        return Ok(MapToDto(updated));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);

        if (!deleted)
            return NotFound(new { message = "Contact not found" });

        return NoContent();
    }

    private static ContactDto MapToDto(Contact contact)
    {
        return new ContactDto
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            Phone = contact.Phone,
            Company = contact.Company,
            Notes = contact.Notes,
            CreatedAt = contact.CreatedAt,
            UpdatedAt = contact.UpdatedAt
        };
    }
}
