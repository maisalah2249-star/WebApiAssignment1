using LibrarySystem;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

using var db = new AppDbContext();

if (!db.Authors.Any())
{
    var author = new Author { Name = "Naguib Mahfouz", BirthDate = new DateTime(1911, 12, 11) };

    var book1 = new Book { Title = "Palace Walk", ISBN = "978-0385264662", Author = author };
    var book2 = new Book { Title = "Sugar Street", ISBN = "978-0385264686", Author = author };

    var borrower = new Borrower { Name = "Mona", MembershipDate = DateTime.Now.AddYears(-1) };

    borrower.Loans.Add(new Loan { Book = book1, LoanDate = DateTime.Now.AddDays(-10), ReturnDate = DateTime.Now.AddDays(-3) });
    borrower.Loans.Add(new Loan { Book = book2, LoanDate = DateTime.Now });

    db.Borrowers.Add(borrower);
    db.SaveChanges();
}

var borrowers = db.Borrowers
    .Include(b => b.Loans).ThenInclude(l => l.Book).ThenInclude(bk => bk.Author)
    .ToList();

foreach (var b in borrowers)
{
    Console.WriteLine($"Borrower: {b.Name} (member since {b.MembershipDate:d})");
    foreach (var l in b.Loans)
    {
        var returned = l.ReturnDate?.ToString("d") ?? "Not returned yet";
        Console.WriteLine($"   {l.Book.Title} by {l.Book.Author.Name} | Loan: {l.LoanDate:d} | Return: {returned}");
    }
}