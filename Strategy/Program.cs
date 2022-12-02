using System;

using Strategy;

Console.Title = "Strategy";

var order = new Order("Marvin Software", 5, "Visual Studio License");

order.Export(new CSVEExportService());

order.Export(new JsonExportService());
