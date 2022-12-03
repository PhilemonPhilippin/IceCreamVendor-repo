using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Service;

public class IceCreamService : IIceCreamService
{
    public void CleanWorkspace()
    {
        Console.WriteLine("*The vendor cleans the workspace.*");
    }
    public void OpenShutters()
    {
        Console.WriteLine("*The vendor take his key and opens the shutters*");
    }
    public void GreetCustomer()
    {
        Console.WriteLine($"Hello and welcome, would you like a delicious ice cream?");
    }
}
