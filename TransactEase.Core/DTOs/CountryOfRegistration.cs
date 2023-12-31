using System.ComponentModel.DataAnnotations;

namespace TransactEase.Core.DTOs;

public class CountryOfRegistration
{
    [StringLength(2, MinimumLength = 2, ErrorMessage = "Country code must be 2 characters long.")]
    public string CountryCode { get; set; }
    public string Country { get; set; }
}