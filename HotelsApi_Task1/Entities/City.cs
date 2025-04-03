using System;
using System.Collections.Generic;

namespace hotelApi.Entities;

public partial class City
{
    public int CityId { get; set; }

    public string CityCode { get; set; } = null!;

    public string CityName { get; set; } = null!;
}
