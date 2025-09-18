namespace OopExamples.Implemetations;
using OopExamples.Interfaces;

public class Company : ICompany
{
    public string Name { get; set; }
    public IPerson Owner { get; set; }
}