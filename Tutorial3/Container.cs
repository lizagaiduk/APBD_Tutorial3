namespace Tutorial3;
public abstract class Container
{
    private static int counter = 1;
    private static readonly HashSet<int> _usedIds = new();
    public double CargoMass { get;  set; }
    public double Height { get; }
    public double TareWeight { get; }
    public double Depth { get; }
    public string SerialNumber { get; }
    public double MaxPayload { get; }
    public Container(string type,double height, double depth, double tareWeight, double maxPayload)
    {
        SerialNumber = GenerateSerialNumber(type);
        Height = height;
        Depth = depth;
        TareWeight = tareWeight;
        MaxPayload = maxPayload;
        CargoMass = 0;
    }
    private static string GenerateSerialNumber(string type)
    {
        int uniqueNumber;
        do
        {
            uniqueNumber = counter++;
        } while (_usedIds.Contains(uniqueNumber));
        _usedIds.Add(uniqueNumber);
        return $"KON-{type}-{uniqueNumber}";
    }
    public virtual void Empty()
    {
        CargoMass = 0;  
    } 
    public virtual void Load(double mass)
    {
        if (CargoMass + mass > MaxPayload)
            throw new OverfillException($"Overload attempt! Max capacity exceeded for {SerialNumber}.");
        CargoMass += mass;
    }
    public double GetTotalWeight()
    {
        return TareWeight + CargoMass;
    }
    public override string ToString()
    { 
        return $"{SerialNumber} | Cargo: {CargoMass}/{MaxPayload} kg";
    }
}