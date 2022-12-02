using System;

using Observer;

TicketResellerService ticketResellerService = new();
TicketStockService ticketStockService = new();
OrderService orderService = new();

orderService.AddObserver(ticketStockService);
orderService.AddObserver(ticketResellerService);

orderService.CompleteTicketSale(1,2);
