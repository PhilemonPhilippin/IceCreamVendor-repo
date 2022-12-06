using IceCreamVendor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Data;

public class IceCreamService : IIceCreamService
{
    private readonly IceCreamContext _context;

    public IceCreamService(IceCreamContext context)
    {
        _context = context;
    }

    public List<IceCream> GetIceCreams()
    {
        return _context.IceCreams.ToList();
    }
    public IceCream GetIceCreamWithFlavour(string flavour)
    {
        return _context.IceCreams.Where(ic => ic.Flavour == flavour).FirstOrDefault();
    }
}
