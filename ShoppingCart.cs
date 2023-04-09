using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OppgaveWebShop
{
    internal class ShoppingCart
    {
        public List<GameItem> Cart { get; }
        public ShoppingCart()
        {
            Cart = new List<GameItem>();
        }
        public void Add(GameItem gameItem)
        {
            Cart.Add(gameItem);
        }
        public bool AreShippingOptions(GameItem gameItem) {
            return gameItem is IPhysicalCopy && gameItem is IDownloadableCopy;
        }
    }
}
