using System;

using ChainOfResponsibility;

Console.Title = "Chain Of Responsibility";

var validDocument = new Document("How to Avoid Java Development",DateTimeOffset.UtcNow,true,true);
var inValidDocument = new Document("How to Avoid Java Development",DateTimeOffset.UtcNow,false,true);

var docuemntHandlerChain = new DocumentTitleHandler();
docuemntHandlerChain.SetSuccessor(new DocumentLastModifiedHandler()).SetSuccessor(new DocumentApprovedByLitigationHandler()).SetSuccessor(new DocumentApprovedByManagementHandler());


try
{
    docuemntHandlerChain.Handle(validDocument);
    Console.WriteLine("valid document is valid");
    docuemntHandlerChain.Handle(inValidDocument);
    Console.WriteLine("inValid document is valid");
}
catch(Exception e)
{
    Console.WriteLine(e);
}