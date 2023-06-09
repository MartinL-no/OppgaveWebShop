﻿namespace OppgaveWebShop;

internal class GameItem
{
    public int Price { get; }
    public string GameName { get; }
    public string Id { get; }
    public bool AreShippingOptions => this is IPhysicalCopy && this is IDownloadableCopy;
    protected GameItem(string gameName, string id, int price)
    {
        Price = price;
        GameName = gameName;
        Id = id;
    }
    public void PrintGameNameAndPrice()
    {
        Console.WriteLine($"Item: {GameName} Price: {Price} ID: {Id}");
    }
}