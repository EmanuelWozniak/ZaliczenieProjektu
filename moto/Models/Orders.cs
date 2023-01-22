using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace moto.Models
{
    public partial class Orders
    {
        public int IdOrder { get; set; }
        public int? IdMoto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? Value { get; set; }
    }
}
