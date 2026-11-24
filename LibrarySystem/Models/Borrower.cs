namespace LibrarySystem.Models;

public class Borrower
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime MembershipDate { get; set; }

    // Many-to-Many with Book through Loan
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}