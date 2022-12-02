 using System;

using Proxy;

Console.Title = "Proxy";

Console.WriteLine("Constructing document");
var myDocument = new Document("test.txt");
Console.WriteLine("Document constructed");
myDocument.DisplayDocument();

Console.WriteLine("Constructing document");
var myDocument2 = new DocumentProxy("test.txt");
Console.WriteLine("Document constructed");
myDocument2.DisplayDocument();
