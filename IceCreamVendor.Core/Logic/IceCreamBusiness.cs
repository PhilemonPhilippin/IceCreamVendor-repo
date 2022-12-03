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

    public void RunBusiness()
    {
        OpenBusiness();
        SellIceCream();
        CloseBusiness();
    }
    public void OpenBusiness()
    {
        CleanWorkspace();
        OpenShutters();
    }
    public void SellIceCream()
    {
        GreetCustomer();
        SuggestFlavours();
        string choice = AskIceCreamChoice();
        ServeIceCream(choice);
    }
    public void CloseBusiness()
    {
        CleanWorkspace();
        CountMoney();
        CloseShutters();
    }

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
    public string AskIceCreamChoice()
    {
        Console.WriteLine("Which ice cream flavour do you want?");
        string customerChoice = Console.ReadLine().Trim().ToLower();
        return customerChoice.Length > 15 ? customerChoice.Substring(0, 15) : customerChoice;
    }
    public void SuggestFlavours()
    {
        Console.WriteLine("Here are the different flavours:");
        List<string> flavours = _service.GetFlavours();
        foreach (string str in flavours)
        {
            Console.WriteLine(str);
        }
    }
    public void ServeIceCream(string choice)
    {
        Console.WriteLine($"The vendor serves a {choice} flavoured ice cream to the customer");
    }
    public void CountMoney()
    {
        Console.WriteLine("*The vendor counts the money he made today*");
    }
    public void CloseShutters()
    {
        Console.WriteLine("*The vendor take his key and closes the shutters*");
    }
}
