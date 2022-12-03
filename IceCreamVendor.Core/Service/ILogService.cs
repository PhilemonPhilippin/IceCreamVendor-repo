using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Service;

public interface ILogService
{
    bool LogSell(string flavour);
}
