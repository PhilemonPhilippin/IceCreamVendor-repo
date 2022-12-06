using IceCreamVendor.Core.Data;
using IceCreamVendor.Core.Service;
using IceCreamVendor.Entities.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Logic;

public class IceCreamBusiness
{
    private readonly IIceCreamService _iceCreamService;
    private readonly ILogService _logService;
    private readonly ISellService _sellService;
    private const int _MAXCOUNT = 5;
    public IceCreamBusiness(IIceCreamService iceCreamService, ILogService logService, ISellService sellService)
    {
        _iceCreamService = iceCreamService;
        _logService = logService;
        _sellService = sellService;
    }

    public void RunBusiness()
    {
        OpenBusiness();
        SellIceCream();
        CloseBusiness();
    }
    private void OpenBusiness()
    {
        CleanWorkspace();
        OpenShutters();
    }
    private void SellIceCream()
    {
        int count = 0;
        string clientName = GreetCustomer();
        List<string> flavours = _iceCreamService.GetIceCreams().Select(ic => ic.Flavour).ToList();
        while (count < _MAXCOUNT)
        {
            if (count % 2 == 0)
            {
                SuggestFlavours(flavours);
            }

            string choice = AskIceCreamChoice();
            if (IsValidFlavour(choice, flavours)) 
            {
                ServeIceCream(choice);
                decimal price = _iceCreamService.GetIceCreamWithFlavour(choice)?.Price ?? -1;
                if (price > 0)
                {
                    CreateSellRecord(choice, clientName, price);
                    count++;
                    Thread.Sleep(2000);
                }
            } else
            {
                _logService.LogWarning(choice);
            }
        }
    }
    private void CloseBusiness()
    {
        OutOfIceCreams();
        CleanWorkspace();
        CountMoney();
        CloseShutters();
    }

    private void CleanWorkspace()
    {
        Console.WriteLine("***The vendor cleans the workspace.***");
    }
    private void OpenShutters()
    {
        Console.WriteLine("***The vendor take his key and opens the shutters***");
    }
    private string GreetCustomer()
    {
        Console.WriteLine($"- Hello and welcome, what is your name?");
        string clientName = Console.ReadLine()?.Trim();
        Console.WriteLine($"- Hello {clientName}, would you like a delicious icecream ?");
        return clientName.Length > 50 ? clientName.Substring(50) : clientName;
    }
    private string AskIceCreamChoice()
    {
        Console.WriteLine("- Which ice cream flavour do you want?");
        string customerChoice = Console.ReadLine()?.Trim().ToLower();
        return customerChoice.Length > 15 ? customerChoice.Substring(0, 15) : customerChoice;
    }
    private void SuggestFlavours(List<string> flavours)
    {
        Console.WriteLine("- Here are the different flavours:");
        foreach (string str in flavours)
        {
            Console.WriteLine(str);
        }
    }
    private bool IsValidFlavour(string choice, List<string> flavours)
    {
        return flavours.Contains(choice);
    }
    private void ServeIceCream(string choice)
    {
        Console.WriteLine($"***The vendor serves a {choice} flavoured ice cream to the customer***");
        _logService.LogSell(choice);
    }
    private void OutOfIceCreams()
    {
        Console.WriteLine($"***The vendor is out of ice creams. He sold all of them ({_MAXCOUNT})");
    }
    private void CountMoney()
    {
        Console.WriteLine("***The vendor counts the money he made today***");
    }
    private void CloseShutters()
    {
        Console.WriteLine("***The vendor take his key and closes the shutters***");
    }

    private bool CreateSellRecord(string choice, string clientName, decimal price)
    {
        Sell sell = new Sell()
        {
            IceCream = choice,
            ClientName = clientName,
            Price = price
        };
        bool isAdded =_sellService.CreateSell(sell);
        return isAdded;
    }
}
