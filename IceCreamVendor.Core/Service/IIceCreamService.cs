using IceCreamVendor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Service;

public interface IIceCreamService
{
    List<string> GetFlavours();
}
