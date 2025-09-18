namespace OopExamples.Implemetations;
using OopExamples.Interfaces;
using System.Data;

public class Computer : IComputer
{
    public IEntity Owner { get; private set; }
    public IMotherBoard MotherBoard { get; private set; }
    public ICPU Cpu { get; private set; }
    public IGPU Gpu { get; private set; }
    public IRAM Ram { get; private set; }
    public IPowerSupply PowerSupply { get; private set; }
    public ICase Case { get; private set; }
    public IMonitor[] Monitors { get; private set; }
    public bool IsOn { get; private set; }
    public bool IsPersonalPC { get; private set; }
    public bool IsCompanyPC { get; private set; }

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
        throw new NotImplementedException();
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