using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models;

public partial class BookingReservation
{
    public int BookingReservationId { get; set; }

    public DateTime? BookingDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public int CustomerId { get; set; }

    public byte? BookingStatus { get; set; }

    [JsonIgnore]
    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    [JsonIgnore]
    public virtual Customer Customer { get; set; } = null!;
}
