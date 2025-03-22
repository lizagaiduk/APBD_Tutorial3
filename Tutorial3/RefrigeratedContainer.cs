namespace Tutorial3;

public class RefrigeratedContainer : Container
{
    private static readonly Dictionary<string, double> productTemperatures = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };
    public string ProductType { get; set; }
    public double Temperature { get; }

    public RefrigeratedContainer(double height, double depth, double tareWeight, double maxPayload, double temperature)
        : base("C", height, depth, tareWeight, maxPayload)
    {
        Temperature = temperature;
    }
    public void SetProduct(string product)
    {
        if (!productTemperatures.ContainsKey(product))
            throw new ArgumentException($"Unknown product: {product}");
        double requiredTemp = productTemperatures[product];
        if (Temperature < requiredTemp)
            throw new InvalidOperationException($"Temperature too low. Required: {requiredTemp}°C, actual: {Temperature}°C");
        if (ProductType != null && ProductType != product)
            throw new InvalidOperationException($"Container already set for {ProductType}. Cannot mix with {product}.");
        ProductType = product;
    }
    public override void Load(double mass)
    {
        if (mass > MaxPayload)
            throw new OverfillException("Refrigerated container overfilled.");
        if (ProductType == null)
            throw new InvalidOperationException("Product type not set.");
        base.Load(mass);
    }
}
