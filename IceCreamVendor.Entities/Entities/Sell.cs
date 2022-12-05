using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Entities.Entities;

public class Sell
{
    public int Id { get; set; }
    public string IceCream { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
