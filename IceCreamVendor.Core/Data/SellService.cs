using IceCreamVendor.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Data;

public class SellService : ISellService
{
    private readonly IceCreamContext _context;

    public SellService(IceCreamContext context)
    {
        _context = context;
    }
    public int GetLastId()
    {
        int lastId = _context.Sells.Select(s => s.Id).OrderByDescending(id => id).FirstOrDefault();
        return lastId;
    }
    public bool CreateSell(Sell sell)
    {
        try
        {
            _context.Sells.Add(sell);
            _context.SaveChanges();
            return true;
        } 
        catch (Exception ex)
        {
            Console.WriteLine("Error while creating new sell : ");
            return false;
        }

    }
}
