using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string RoomTypeName { get; set; } = null!;

    public string? TypeDescription { get; set; }

    public string? TypeNote { get; set; }

    [JsonIgnore]
    public virtual ICollection<RoomInformation> RoomInformations { get; set; } = new List<RoomInformation>();
}
