namespace OopExamples.Implemetations;
using OopExamples.Interfaces;
using System.Data;

public class Computer : IComputer
{
    public IEntity Owner { get; set; }
    public IMotherBoard MotherBoard { get; set; }
    public ICPU Cpu { get; set; }
    public IGPU Gpu { get; set; }
    public IRAM Ram { get; set; }
    public IPowerSupply PowerSupply { get; set; }
    public ICase Case { get; set; }
    public IMonitor[] Monitors { get; set; }
    public bool IsOn { get; set; }
    public bool IsPersonalPC { get; set; }
    public bool IsCompanyPC { get; set; }

    public void PowerUp()
    {
        IsOn = true;
    }

    public void ShutDown()
    {
        IsOn = false;
    }

    public void PressPowerButton()
    {
        if (IsOn) ShutDown();
        else PowerUp();
    }

    public void Print(string text)
    {
        Console.WriteLine(text);
    }

    public float Compute(string equation)
    {
        try
        {
            var table = new DataTable();
            var result = table.Compute(equation, string.Empty);
            return (float)Convert.ToDouble(result.ToString());
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Invalid equation format.", ex);
        }
    }

    public void ChangeOwner(IEntity? newOwner)
    {
        Owner = newOwner;
    }

    public void RemoveOwner()
    {
        Owner = null;
    }

    public IComputer BuildNewComputer(IComputerConfiguration configuration)
    {
        Computer computer = new Computer(); 
        computer.MotherBoard = configuration.MotherBoard;
        computer.Cpu = configuration.Cpu;
        computer.Gpu = configuration.Gpu;
        computer.Ram = configuration.Ram;
        computer.PowerSupply = configuration.PowerSupply;
        computer.Case = configuration.Case;
        return computer;
    }
}