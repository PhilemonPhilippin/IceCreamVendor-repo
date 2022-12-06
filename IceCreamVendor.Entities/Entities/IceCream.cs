using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Entities.Entities;

public class IceCream
{
    public int Id { get; set; }
    public string Flavour { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
