using System;
using System.Collections.Generic;

namespace hotelsApi.Entities;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public string HotelCode { get; set; } = null!;

    public string DateFrom { get; set; } = null!;

    public string DateTo { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string EmailAddress { get; set; } = null!;

    public virtual Hotel? Hotel { get; set; }
}
