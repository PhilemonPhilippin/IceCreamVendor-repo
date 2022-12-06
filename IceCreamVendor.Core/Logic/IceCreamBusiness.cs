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
        SuggestFlavours();
        while (count < _MAXCOUNT)
        {
            string choice = AskIceCreamChoice();
            if (IsValidFlavour(choice)) 
            {
                ServeIceCream(choice);
                decimal price = 2.5m;
                CreateSellRecord(choice, clientName, price);
                count++;
            } else
            {
                _logService.LogWarning(choice);
            }
        }
    }
    private void CloseBusiness()
    {
        CleanWorkspace();
        CountMoney();
        CloseShutters();
    }

    private void CleanWorkspace()
    {
        Console.WriteLine("*The vendor cleans the workspace.*");
    }
    private void OpenShutters()
    {
        Console.WriteLine("*The vendor take his key and opens the shutters*");
    }
    private string GreetCustomer()
    {
        Console.WriteLine($"Hello and welcome, what is your name?");
        string clientName = Console.ReadLine()?.Trim();
        Console.WriteLine($"Hello {clientName}, would you like a delicious icecream ?");
        return clientName.Length > 50 ? clientName.Substring(50) : clientName;
    }
    private string AskIceCreamChoice()
    {
        Console.WriteLine("Which ice cream flavour do you want?");
        string customerChoice = Console.ReadLine()?.Trim().ToLower();
        return customerChoice.Length > 15 ? customerChoice.Substring(0, 15) : customerChoice;
    }
    private void SuggestFlavours()
    {
        Console.WriteLine("Here are the different flavours:");
        List<string> flavours = _iceCreamService.GetFlavours();
        foreach (string str in flavours)
        {
            Console.WriteLine(str);
        }
    }
    private bool IsValidFlavour(string choice)
    {
        return Enum.IsDefined(typeof(Flavour), choice);
    }
    private void ServeIceCream(string choice)
    {
        Console.WriteLine($"The vendor serves a {choice} flavoured ice cream to the customer");
        _logService.LogSell(choice);
    }
    private void CountMoney()
    {
        Console.WriteLine("*The vendor counts the money he made today*");
    }
    private void CloseShutters()
    {
        Console.WriteLine("*The vendor take his key and closes the shutters*");
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
