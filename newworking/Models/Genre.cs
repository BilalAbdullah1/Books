using System;
using System.Collections.Generic;

namespace newworking.Models;

public partial class Genre
{
    public int GId { get; set; }

    public string? GName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
