using System;
using System.Collections.Generic;

namespace hotelApi.Entities;

public partial class State
{
    public int StateId { get; set; }

    public string StateCode { get; set; } = null!;

    public string StateName { get; set; } = null!;
}
