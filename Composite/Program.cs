using System;

using Composite;
Console.Title = "Composite";

var root = new Directory("root", 0);
var topLevelFile = new File("toplevel.txt", 100);
var topLevelDirectory1 = new Directory("topleveldirectory1.txt", 3);
var topLevelDirectory2 = new Directory("topleveldirectory2.txt", 3);

root.Add(topLevelFile);
root.Add(topLevelDirectory1);
root.Add(topLevelDirectory2);

Console.WriteLine($"Total size is {root.GetSize()}");
