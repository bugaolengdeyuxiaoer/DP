using System;
using Decorator;

Console.Title = "Decorator";

var cloudMailService = new CloudMailService();
cloudMailService.SendMail("Hi there");

var onPremiseMailService = new OnPremiseMailService();
onPremiseMailService.SendMail("Hi there");

// add behavior
var statisticDecorator = new StatisticsDecorator(cloudMailService);
statisticDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)} wrapper");

// add behavior
var messageDataBaseDecorator = new MessageDatabaseDecorator(onPremiseMailService);
messageDataBaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper , message 1");
messageDataBaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper , message 2");

foreach(var message in messageDataBaseDecorator.SentMessage)
{
    Console.WriteLine($"Stored message: \"{message}\"");
}