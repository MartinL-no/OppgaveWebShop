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
        var choice = Ask("Choose an option: ");
        Inventory.PrintInventory(choice);

        var gameToBuy = ChooseGame();
        ShoppingCart.Add(gameToBuy);
        Ship(gameToBuy);
    }

    private GameItem ChooseGame()
    {
        var gameID = Ask("input the ID of game you want to buy");

        return Inventory.InventoryList.Find(x => x.Id == gameID);
    }
    private string? Ask(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine();;
    }
    private void Ship(GameItem gameToBuy)
    {
        if (gameToBuy.AreShippingOptions)
        {
            var shippingOption = Ask("choose a shipping option:\n1: Download\n2: Ship");
            if (shippingOption == "1")
                PrintDownloadMessage(gameToBuy.GameName);
            else
                PrintShippingMessage(gameToBuy.GameName);
        }
        else if (gameToBuy is IPhysicalCopy)
            PrintShippingMessage(gameToBuy.GameName);
        else
            PrintDownloadMessage(gameToBuy.GameName);
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