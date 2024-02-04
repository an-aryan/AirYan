using System;
using System.Collections.Generic;


namespace airyan.Models;

public partial class AryanPassenger
{
    public int PassengerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<AryanBooking> AryanBookings { get; set; } = new List<AryanBooking>();
}
