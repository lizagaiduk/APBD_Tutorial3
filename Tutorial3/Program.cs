using Tutorial3;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n=== Container ship simulation ===");

        // 1. Create two ships
        var ship1 = new ContainerShip("Voyager", 20, 5, 50);
        var ship2 = new ContainerShip("Explorer", 18, 5, 50);

        Console.WriteLine("\nCreated container ships:");
        ship1.PrintInfo();
        Console.WriteLine();
        ship2.PrintInfo();

        // 2. Create containers
        var gasContainer = new GasContainer(260, 1200, 300, 1800, 10);
        var liquidContainer = new LiquidContainer(260, 1000, 300, 2000, true);
        var fridgeContainer = new RefrigeratedContainer(260, 1500, 300, 2500, 2);
        fridgeContainer.SetProduct("Fish");

        Console.WriteLine("\nCreated containers:");
        Console.WriteLine($"  - {gasContainer.SerialNumber} [Gas]");
        Console.WriteLine($"  - {liquidContainer.SerialNumber} [Liquid]");
        Console.WriteLine($"  - {fridgeContainer.SerialNumber} [Refrigerated, Product: {fridgeContainer.ProductType}]");

        // 3. Load cargo
        try
        {
            Console.WriteLine("\nLoading cargo into containers...");
            gasContainer.Load(1500);
            Console.WriteLine($"  Loaded {gasContainer.SerialNumber} | Cargo: {gasContainer.CargoMass} kg");
            liquidContainer.Load(800);
            Console.WriteLine($"  Loaded {liquidContainer.SerialNumber} | Cargo: {liquidContainer.CargoMass} kg");
            fridgeContainer.Load(1000);
            Console.WriteLine($"  Loaded {fridgeContainer.SerialNumber} | Cargo: {fridgeContainer.CargoMass} kg");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while loading cargo: {ex.Message}");
        }

        // 4. Load containers onto Ship 1
        try
        {
            Console.WriteLine("\nLoading containers onto Ship 1...");
            ship1.LoadContainer(gasContainer);
            ship1.LoadContainer(liquidContainer);
            ship1.LoadContainer(fridgeContainer);
            Console.WriteLine("All containers are loaded onto Ship 1.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while loading to ship: {ex.Message}");
        }
        // Print status
        Console.WriteLine("\n--- Ship 1 status ---");
        ship1.PrintInfo();
        Console.WriteLine("\n--- Ship 2 status ---");
        ship2.PrintInfo();
        
        // 5. Replace container on Ship 1
        try
        {
            Console.WriteLine("\nReplacing container on Ship 1...");
            var replacement = new LiquidContainer(260, 950, 300, 1900, false);
            replacement.Load(1200);
            ship1.ReplaceContainer(liquidContainer.SerialNumber, replacement);
            Console.WriteLine($"Replaced {liquidContainer.SerialNumber} with {replacement.SerialNumber}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while replacing container: {ex.Message}");
        }
        Console.WriteLine("\n--- Ship 1 status after replacement ---");
        ship1.PrintInfo();
        
        // 6. Transfer container
        Console.WriteLine("\nTransferring one container from Ship 1 to Ship 2...");
        if (ship1.Containers.Any())
        {
            var containerToTransfer = ship1.Containers.First();
            ship1.TransferContainer(containerToTransfer, ship2);
            Console.WriteLine($"Transferred {containerToTransfer.SerialNumber} to Ship 2.");
        }
        else
        {
            Console.WriteLine("No containers available for transfer.");
        }

        // 7. Final info
        Console.WriteLine("\n--- Final Ship Status ---");
        Console.WriteLine("Ship 1:");
        ship1.PrintInfo();
        Console.WriteLine("\nShip 2:");
        ship2.PrintInfo();

        Console.WriteLine("\n=== Simulation complete ===");
    }
}
