using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    public class ShopScene
    {
    }

    public class Shop
    {
        public void ShopItemListWrite()
        {

        }

        public void BuyItem(ItemData item, Character user)
        {
            if (!item.isOwned)
            {
                if (user.gold >= item.itemPrice)
                {
                    user.gold -= item.itemPrice;
                }
                else
                {

                }
            }
            else
            {
                Console.WriteLine("이미 갖고있음");
            }
        }
    }
}
