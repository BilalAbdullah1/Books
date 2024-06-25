using System;
using System.Collections.Generic;

namespace newworking.Models;

public partial class Book
{
    public int Bid { get; set; }

    public string? Btitle { get; set; }

    public string? Bauthor { get; set; }

    public int? Bprice { get; set; }

    public string? Bdesc { get; set; }

    public string? Bimage { get; set; }

    public int? GenreId { get; set; }

    public virtual Genre? Genre { get; set; }
}
