using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Service;

public interface IIceCreamService
{
    void OpenShutters();
    void CleanWorkspace();
    void GreetCustomer();
}
