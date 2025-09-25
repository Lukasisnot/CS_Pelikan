namespace OopExamples.Implemetations;
using OopExamples.Interfaces;

public class ComputerBuilder : IComputerBuilder
{
    private IMotherBoard _motherBoard { get; set; }
    private ICPU _cpu { get; set; }
    private IGPU _gpu { get; set; }
    private IRAM _ram { get; set; }
    private IPowerSupply _powerSupply { get; set; }
    private ICase _case { get; set; }
    
    public IComputer BuildFromConfiguration(IComputerConfiguration configuration)
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

    public IComputerBuilder AddMotherBoard(IMotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IComputerBuilder AddCPU(ICPU cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IComputerBuilder AddGPU(IGPU gpu)
    {   
        _gpu = gpu;
        return this;
    }

    public IComputerBuilder AddRam(IRAM ram)
    {
        _ram = ram;
        return this;
    }

    public IComputerBuilder AddPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IComputerBuilder AddCase(ICase pcCase)
    {
        _case = pcCase;
        return this;
    }

    public IComputer Build()
    {
        Computer computer = new Computer(); 
        computer.MotherBoard = _motherBoard;
        computer.Cpu = _cpu;
        computer.Gpu = _gpu;
        computer.Ram = _ram;
        computer.PowerSupply = _powerSupply;
        computer.Case = _case;
        return computer;
    }
}