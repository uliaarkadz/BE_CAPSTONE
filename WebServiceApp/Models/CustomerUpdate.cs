namespace WebServiceApp.Models;
using System.ComponentModel.DataAnnotations;

public class CustomerUpdate
{
    [Required (ErrorMessage = "You should provide value.")]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [Required (ErrorMessage = "You should provide value.")]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    [MaxLength(50)]
    public string? Address1 { get; set; }
    [MaxLength(50)]
    public string? Address2 { get; set; }
    [MaxLength(20)]
    public string? City { get; set; }
    [MaxLength(2)]
    public string? State { get; set; }
    [MaxLength(5)]
    public string? Zip { get; set; }
}