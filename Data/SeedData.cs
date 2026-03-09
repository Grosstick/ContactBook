using ContactBook.Models;

namespace ContactBook.Data;

public static class SeedData
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (context.Contacts.Any())
            return;

        var contacts = new List<Contact>
        {
            new Contact
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan.kowalski@example.com",
                Phone = "+48 501 234 567",
                Company = "Netwise",
                Notes = "Backend developer",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Contact
            {
                FirstName = "Anna",
                LastName = "Nowak",
                Email = "anna.nowak@example.com",
                Phone = "+48 502 345 678",
                Company = "Netwise",
                Notes = "Project manager",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Contact
            {
                FirstName = "Piotr",
                LastName = "Wisniewski",
                Email = "piotr.wisniewski@example.com",
                Phone = "+48 503 456 789",
                Company = "TechCorp",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Contact
            {
                FirstName = "Katarzyna",
                LastName = "Wojcik",
                Email = "kasia.wojcik@example.com",
                Company = "TechCorp",
                Notes = "Frontend specialist",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Contact
            {
                FirstName = "Marek",
                LastName = "Zielinski",
                Email = "marek.zielinski@example.com",
                Phone = "+48 505 678 901",
                Company = "DataSoft",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Contact
            {
                FirstName = "Magdalena",
                LastName = "Lewandowska",
                Email = "magda.lewandowska@example.com",
                Phone = "+48 506 789 012",
                Company = "DataSoft",
                Notes = "Data analyst",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Contact
            {
                FirstName = "Tomasz",
                LastName = "Kaminski",
                Email = "tomasz.kaminski@example.com",
                Company = "Netwise",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Contact
            {
                FirstName = "Aleksandra",
                LastName = "Szymanska",
                Email = "ola.szymanska@example.com",
                Phone = "+48 508 901 234",
                Company = "StartupXYZ",
                Notes = "UX designer",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Contact
            {
                FirstName = "Michal",
                LastName = "Jankowski",
                Email = "michal.jankowski@example.com",
                Phone = "+48 509 012 345",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Contact
            {
                FirstName = "Zofia",
                LastName = "Dabrowska",
                Email = "zofia.dabrowska@example.com",
                Phone = "+48 510 123 456",
                Company = "StartupXYZ",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        context.Contacts.AddRange(contacts);
        context.SaveChanges();
    }
}
