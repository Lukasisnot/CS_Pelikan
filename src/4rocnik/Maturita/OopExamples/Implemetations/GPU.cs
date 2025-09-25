namespace OopExamples.Implemetations;
using OopExamples.Interfaces;

public class GPU : IGPU
{
    public string Name { get; set; }
    public GPUConnector[] Connectors { get; init; }
    public IComputer? Computer { get; set; }
    public GPUConnector[] AvailableConnectors { get; set; }
    public IMonitor[] ConnectedMonitors { get; set; }
    public bool IsUsed { get; set; }
    public void Connect(IComputer computer)
    {
        Computer = computer;
    }

    public void Disconnect()
    {
        Computer = null;
    }

    public void ConnectMonitor(IMonitor monitor)
    {
        ConnectedMonitors.ToList().Add(monitor);
    }

    public void DisconnectMonitor(IMonitor monitor)
    {
        ConnectedMonitors.ToList().Remove(monitor);
    }
}