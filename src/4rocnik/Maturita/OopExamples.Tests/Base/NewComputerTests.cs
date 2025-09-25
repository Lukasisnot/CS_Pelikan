using OopExamples.Implemetations;
using OopExamples.Interfaces;

namespace OopExamples.Tests;

public class NewComputerTests
{
    protected readonly IComputerConfiguration ComputerConfiguration;
    protected readonly IComputer Computer;
    protected readonly IComputerBuilder Builder;
    protected readonly IPerson Person;
    protected readonly ICompany Company;

    public NewComputerTests()
    {
        // tests
        // Create instance of interfaces, using your implementation
        ComputerConfiguration = null;
        Builder = null;
        ComputerBuilder builder =  new ComputerBuilder();
        builder
            .AddCase(new Case())
            .AddMotherBoard(new MotherBoard())
            .AddGPU(new GPU())
            .AddCPU(new CPU())
            .AddPowerSupply(new PowerSupply())
            .AddRam(new RAM());
        Computer = builder.Build();
        Person = new Person();
        Company = new Company();
        Company.Owner = Person;
        
        // Do not touch this
        Computer = Computer ?? throw new System.NotImplementedException($"{nameof(Computer)} not implemented");
        Person = Person ?? throw new System.NotImplementedException($"{nameof(Person)} not implemented");
        Company = Company ?? throw new System.NotImplementedException($"{nameof(Company)} not implemented");
    }

    protected void IsValidComputer(IComputer computer)
    {
        Assert.NotNull(computer.MotherBoard);
        Assert.NotNull(computer.Gpu);
        Assert.NotNull(computer.Ram);
        Assert.NotNull(computer.PowerSupply);
        Assert.NotNull(computer.Case);
    }
}