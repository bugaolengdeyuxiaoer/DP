using Factory;
using System;
using System.Collections;
using System.Collections.Generic;


Console.Title = "Factory";

var factories = new List<DiscountFactory> {
    new CodeDiscountFactory(Guid.NewGuid().ToString()),
    new CountryDiscountFactory("BE")
};

foreach (var fact in factories)
{
    var discountService = fact.CreateDiscountService();
    Console.WriteLine($"Percentage {discountService.DiscountPercentage}" + $"coming from {discountService}");
}

Console.ReadKey();
