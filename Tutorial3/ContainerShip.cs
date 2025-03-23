namespace Tutorial3;

public class ContainerShip
{
    public string Name { get; }
    public List<Container> Containers { get; } = new();
    public double MaxSpeed { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; }
    public ContainerShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight * 1000;
    }
    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers || GetTotalWeight() + container.GetTotalWeight() > MaxWeight)
            throw new OverfillException("Ship capacity exceeded! Cannot load more containers.");
        Containers.Add(container);
    }
    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var existingContainer = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (existingContainer != null)
        {
            Containers.Remove(existingContainer);
            LoadContainer(newContainer);
        }
    }
    public void TransferContainer(Container container, ContainerShip targetShip)
    {
        if (!Containers.Contains(container))
            throw new InvalidOperationException("Container not found on this ship!");
        RemoveContainer(container);
        targetShip.LoadContainer(container);
    }
    public double GetTotalWeight()
    {
        return Containers.Sum(c => c.GetTotalWeight());
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Ship: {Name}");
        Console.WriteLine($"Max Speed: {MaxSpeed} knots");
        Console.WriteLine($"Containers ({Containers.Count}):");
        foreach (var container in Containers)
        {
            Console.WriteLine($"  - {container.SerialNumber}, cargo: {container.CargoMass} kg");
        }
    }
    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

}
