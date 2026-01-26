namespace ConsoleApp.Models;

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Customer
{
    public int CustomerId {get; set;}
    public string? CustomerName {get; set;}
    public string? ContactName {get; set;}
    public string? Country {get; set;}


}
