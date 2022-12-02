using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public interface IexportService
    {
        void Export(Order order);
    }

    public class JsonExportService : IexportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to Json.");
        }
    }
    public class XmlExportService : IexportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to XML.");
        }
    }
    public class CSVEExportService : IexportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to CSVE.");
        }
    }
    public class Order
    {
        public string Customer { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public IexportService? ExportService { get; set; }
        public void Export(IexportService iexportService)
        {
            iexportService.Export(this);
        }
        public Order(string name, int amount, string description)
        {
            Name = name;
            Amount = amount;
            Description = description;
        }
    } 
}
