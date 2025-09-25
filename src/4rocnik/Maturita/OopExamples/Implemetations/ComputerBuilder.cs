using OopExamples.Interfaces.Exceptions;
using OopExamples.Interfaces;
namespace OopExamples.Implemetations;

public class ComputerBuilder : IComputerBuilder
{
    private IMotherBoard _motherBoard { get; set; }
    private ICPU _cpu { get; set; }
    private IGPU _gpu { get; set; }
    private IRAM _ram { get; set; }
    private IPowerSupply _powerSupply { get; set; }
    private ICase _case { get; set; }
    private int _partsCount = 0;
    
    public IComputer BuildFromConfiguration(IComputerConfiguration configuration)
    {
        if (configuration.MotherBoard is null || configuration.Cpu is null || configuration.Gpu is null || configuration.Ram is null || configuration.PowerSupply is null  || configuration.Case is null)
            throw new ComputerMissingComponentsException();
        
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
        _partsCount++;
        return this;
    }

    public IComputerBuilder AddCPU(ICPU cpu)
    {
        _cpu = cpu;
        _partsCount++;
        return this;
    }

    public IComputerBuilder AddGPU(IGPU gpu)
    {   
        _gpu = gpu;
        _partsCount++;
        return this;
    }

    public IComputerBuilder AddRam(IRAM ram)
    {
        _ram = ram;
        _partsCount++;
        return this;
    }

    public IComputerBuilder AddPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        _partsCount++;
        return this;
    }

    public IComputerBuilder AddCase(ICase pcCase)
    {
        _case = pcCase;
        _partsCount++;
        return this;
    }

    public IComputer Build()
    {
        if (_motherBoard is null || _cpu is null || _gpu is null || _ram is null || _powerSupply is null  || _case is null)
            throw new ComputerMissingComponentsException();
        
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