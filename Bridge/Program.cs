using Bridge;
using System;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneEuroCoupon = new OneEuroCoupon();

var meatMenu = new MeatMenu(noCoupon);
Console.WriteLine($"Meat menu, no coupon: {meatMenu.CalculatePrice()}");
meatMenu = new MeatMenu(oneEuroCoupon);
Console.WriteLine($"Meat menu, no coupon: {meatMenu.CalculatePrice()}");
var vegetarianMenu = new MeatMenu(noCoupon);

Console.WriteLine($"VegetarianMenu menu, no coupon: {vegetarianMenu.CalculatePrice()}");
vegetarianMenu = new MeatMenu(oneEuroCoupon);
Console.WriteLine($"VegetarianMenu menu, no coupon: {vegetarianMenu.CalculatePrice()}");