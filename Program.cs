namespace OppgaveWebShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storeInventory = new StoreInventory();
            var webShop = new WebShop(storeInventory);
        }
    }
}