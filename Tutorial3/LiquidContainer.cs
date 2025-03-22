namespace Tutorial3;
public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }
    public LiquidContainer(double height,double depth, double tareWeight, double maxPayload, bool isHazardous)
        : base("L", height, depth,tareWeight, maxPayload)
    {
        IsHazardous = isHazardous;
    }
    public override void Load(double mass)
    {
        double allowedCapacity = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (mass > allowedCapacity)
        {
            NotifyHazard("Overload attempt on hazardous liquid container!");
            throw new OverfillException("Max load exceeded for liquid container.");
        }
        base.Load(mass);
    }
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD] {message} (Container: {SerialNumber})");
    }
}