using IceCreamVendor.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Logic;

public class IceCreamBusiness
{
    private readonly IIceCreamService _service;

    public IceCreamBusiness(IIceCreamService service)
    {
        _service = service;
    }

    public void OpenBusiness()
    {
        _service.CleanWorkspace();
        _service.OpenShutters();
        _service.GreetCustomer();
    }
    
}
