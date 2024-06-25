using System;
using System.Collections.Generic;

namespace newworking.Models;

public partial class Customer
{
    public int CtId { get; set; }

    public string? CtName { get; set; }

    public string? CtEmail { get; set; }

    public string? CtPassword { get; set; }

    public string? CtContext { get; set; }

    public string? CtAddress { get; set; }

    public string? CtGender { get; set; }
}
