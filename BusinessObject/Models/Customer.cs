using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerFullName { get; set; }

    public string? Telephone { get; set; }

    public string EmailAddress { get; set; } = null!;

    public DateTime? CustomerBirthday { get; set; }

    public byte? CustomerStatus { get; set; }

    public string? Password { get; set; }
    public int? Role { get; set; }

    [JsonIgnore]
    public virtual ICollection<BookingReservation> BookingReservations { get; set; } = new List<BookingReservation>();
}
