﻿public static class Tarifs
{ 
   // Static class and methods cause class do not have specific example
     public static double Tarif1CallCalc(char callType, int minutes)
     {
        Console.WriteLine("First Rate calc used");
        if (callType == 'Г')
            return minutes * 5;
        else
            if (callType == 'М')
            return minutes * 1;
        return 0;
     }
    public static double Tarif2CallCalc(char callType, int minutes)
    {
        Console.WriteLine("Second Rate calc used");
        if (callType == 'Г')
        {
            if (minutes > 10)
                return minutes * 2.5;
            else
                return minutes * 5;
        }
        else
            if (callType == 'М')
            return minutes * 1;
        return 0;
    }
    public static double Tarif3CallCalc(char callType, int minutes)
    {
        Console.WriteLine("Third Rate calc used");
        if (minutes < 5)
            return Tarif1CallCalc(callType,minutes)/2;
        else
            return Tarif1CallCalc(callType, minutes)*2;
    }
}
class Customer
{
    public string Name { get; set; }
    public double Balance { get; private set; }
    public string Rate { get; set; }

    public static string tar1 = "Time Rate";
    public static string tar2 = "Half money after 10min Rate";
    public static string tar3 = "Less money before 5min Rate";

    public Customer(string name, double balance = 100, int tar=1) //why cant use just int tar???
    {
        Name = name;
        Balance = balance;
        switch (tar)
        {
            case 1: Rate = tar1; break;
            case 2: Rate = tar2; break;
            case 3: Rate = tar3; break;
            default:
                {
                    Rate = tar1;
                    Console.WriteLine("Invalid rate type, switching to default"); break;
                }         
        }

    }

    public override string ToString()
    {
        return string.Format("Client: {0} with Rate {1} has credits: {2}", Name, Rate, Balance);
    }

    public void RecordPayment(double amountPaid)
    {
        if (amountPaid > 0)
            Balance += amountPaid;
    }


    public void RecordCall(char callType, int minutes)
    {
        switch (Rate)
        {
            case "Time Rate": Balance = Tarifs.Tarif1CallCalc(callType, minutes); break;
            case "Half money after 10min Rate": Balance = Tarifs.Tarif2CallCalc(callType, minutes); break;
            case "Less money before 5min Rate": Balance = Tarifs.Tarif3CallCalc(callType, minutes); break;

                //if (callType == 'Г')
                //    Balance -= minutes * 5;
                //else
                //    if (callType == 'М')
                //    Balance -= minutes * 1;
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Customer Ivan = new Customer("Ivan Petrov", 500,1);
        Customer Elena = new Customer("Elena Ivanova", 100,3);
        Ivan.RecordCall('Г', 12);
        Elena.RecordCall('М', 25);
        Console.WriteLine(Ivan);
        Console.WriteLine(Elena);

    }
}