using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public partial class Member
{
    [Key]
    public int MemberId { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [Required]
    [StringLength(15)]
    public string City { get; set; } = null!;

    [Required]
    [StringLength(15)]
    public string Country { get; set; } = null!;

    [Required]
    [StringLength(30, MinimumLength = 6)]
    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}