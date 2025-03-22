namespace Tutorial3;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }

    public GasContainer(double height, double depth, double tareWeight, double maxPayload, double pressure)
        : base("G", height, depth, tareWeight, maxPayload)
    {
        Pressure = pressure;
    }
    public override void Load(double mass)
    {
        if (mass > MaxPayload)
        {
            NotifyHazard("Gas container overfilled.");
            throw new OverfillException("Max load exceeded for gas container.");
        }
        base.Load(mass);
    }
    public override void Empty()
    {
        CargoMass *= 0.05;
    }
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD] {message} (Container: {SerialNumber})");
    }}
