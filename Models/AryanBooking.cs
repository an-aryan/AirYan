using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace airyan.Models;

public partial class AryanBooking
{
    public int BookingId { get; set; }

    public int? FlightId { get; set; }

    public int? PassengerId { get; set; }

    public DateTime? BookingDate { get; set; }

    public virtual AryanFlight? Flight { get; set; }
    
    public virtual AryanPassenger? Passenger { get; set; }
}
