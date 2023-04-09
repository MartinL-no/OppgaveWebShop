namespace OppgaveWebShop;

internal class StoreInventory
{
    public List<GameItem> InventoryList { get; }
    public StoreInventory()
    {
        InventoryList = new List<GameItem>
        {
            new BattleField(),
            new CyberPunk(),
            new PokemonLetsGoEevee(),
            new PUBG()
        };
    }

    public List<GameItem> ListPhysicalItems()
    {
        // to find all items in InventoryList that are sold in physical format
        return InventoryList.Where(g => g is IPhysicalCopy && !g.AreShippingOptions).ToList();
    }

    public List<GameItem> ListDownLoadable()
    {
        return InventoryList.Where(g => g is IDownloadableCopy  && !g.AreShippingOptions).ToList();
    }
    public void PrintInventory(string command)
    {           
        if (command == "1")
        {
            Print(InventoryList);
        }
        else if(command == "2")
        {
            Print(ListPhysicalItems());
        }
        else
        {
            Print(ListDownLoadable());
        }
    }
    public void Print(List<GameItem> list)
    {
        foreach (var item in list)
        {
            item.PrintGameNameAndPrice();
        }
    }
}