using IceCreamVendor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Service;

public class IceCreamService : IIceCreamService
{
    public List<string> GetFlavours()
    {
        return Enum.GetNames(typeof(Flavour)).ToList();
    }

}
