using System;
using System.Security.Claims;

namespace Identity.BLL.Token.Models;

public class ResolveToken
{
    public bool IsValid { get; set; }
    public string? ErrorMessage { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public IEnumerable<Claim>? Claims { get; set; }
}
