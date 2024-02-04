using System;
using System.Collections.Generic;

namespace airyan.Models;

public partial class AryanUser
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
public class ApiResponse
{
    public bool Success { get; set; }
}