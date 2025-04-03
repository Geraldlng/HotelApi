using System;
using System.Collections.Generic;

namespace hotelsApi.Entities;

public partial class Barangay
{
    public int BarangayId { get; set; }

    public string BarangayCode { get; set; } = null!;

    public string BarangayName { get; set; } = null!;

    public int? CityId { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
