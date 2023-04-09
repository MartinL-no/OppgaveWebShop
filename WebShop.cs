namespace OppgaveWebShop;

internal class WebShop
{
    public StoreInventory Inventory { get; }
    public ShoppingCart ShoppingCart { get; }
    public WebShop(StoreInventory storeInventory)
    {
        Inventory = storeInventory;
        ShoppingCart = new ShoppingCart();

        while (true)
        {
            Console.WriteLine("Welcome to the shop! ");
            Console.WriteLine("1: Show all available games");
            Console.WriteLine("2: Show only physical games");
            Console.WriteLine("3: Show only downloadable games");

            HandleCommand();
        }
    }
    private void HandleCommand() 
    { 
        // Should read in input from users here 
        // Inventory should print out information based on the choice the user made. 
        Console.WriteLine("input the ID of game you want to buy"); 
        var gameID = Console.ReadLine(); 
        var gameToBuy = Inventory.InventoryList.Find(x => x.Id == gameID); 
        ShoppingCart.Add(gameToBuy);

        if (ShoppingCart.AreShippingOptions(gameToBuy))
        {
            Console.WriteLine("choose a shipping option: ");
            Console.WriteLine("1: Download"); 
            Console.WriteLine("2: Ship"); 
            var choice = Console.ReadLine();
            if (choice == "1")
            {
                PrintDownloadMessage(gameToBuy.GameName); 
            }
            else
            {
                PrintShippingMessage(gameToBuy.GameName); 
            } 
        } 
        else if (gameToBuy is IPhysicalCopy) PrintShippingMessage(gameToBuy.GameName);

        else PrintDownloadMessage(gameToBuy.GameName);
        //Check whether the game is to be shipped or downloaded 
        //Print out with the Download or shipping method below 
    } 
    private void PrintDownloadMessage(string gameName) 
    { 
        Console.WriteLine($"Game {gameName} will now be downloaded..");            
    } 
    private void PrintShippingMessage(string gameName) 
    {
        Console.WriteLine($"Game {gameName} will be shipped shortly..");
    }
}