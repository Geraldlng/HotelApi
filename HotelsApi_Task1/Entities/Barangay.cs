using System;
using System.Collections.Generic;

namespace hotelApi.Entities;

public partial class Barangay
{
    public int BarangayId { get; set; }

    public string BarangayCode { get; set; } = null!;

    public string BarangayName { get; set; } = null!;
}
