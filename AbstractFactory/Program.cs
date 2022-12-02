using AbstractFactory;
using System;
using System.Collections;
using System.Collections.Generic;


Console.Title = "Abstract Factory";


var belgiumShoppingCartPurhcaseFactory = new BelgiumShoppingCartPurchaseFactory();
var shoppingCartForBelgium = new ShoppingCart(belgiumShoppingCartPurhcaseFactory);
shoppingCartForBelgium.CalculateCosts();

var franceShoppingCartPurhcaseFactory = new FranceShoppingCartPurchaseFactory();

var shoppingCartForFrance = new ShoppingCart(franceShoppingCartPurhcaseFactory);
shoppingCartForFrance.CalculateCosts();
Console.ReadKey();
