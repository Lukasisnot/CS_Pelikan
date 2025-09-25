using OopExamples.Interfaces;

namespace OopExamples.Implemetations;

public class Monitor : IMonitor
{
    public Monitor(string name, GPUConnector connector)
    {
        Name = name;
        Connector = connector;
    }

    public string Name { get; set; }
    public GPUConnector Connector { get; }
}