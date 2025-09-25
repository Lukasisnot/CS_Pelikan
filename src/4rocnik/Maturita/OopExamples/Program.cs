// See https://aka.ms/new-console-template for more information

using OopExamples.Implemetations;
using OopExamples.Interfaces;

Console.WriteLine("Hello");
ComputerBuilder builder = new ComputerBuilder();
IComputer pc = builder.AddCase(new Case()).Build();