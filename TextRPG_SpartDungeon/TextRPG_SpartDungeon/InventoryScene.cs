using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    internal class InventoryScene
    {

    }

    public class ItemData
    {
        public string itemName;
        public int itemAttackPoint;
        public int itemDefensePoint;
        public string itemDescription;
        public int itemPrice;
        public bool isOwned;

        public ItemData(string iName, int iAP, int iDP, string iDescription, int iPrice, bool iOwned)
        {
            itemName = iName;
            itemAttackPoint = iAP;
            itemDefensePoint = iDP;
            itemDescription = iDescription;
            itemPrice = iPrice;
            isOwned = iOwned;
        }
    }

    public class ItemList
    {
        public List<ItemData> items = new List<ItemData>();
        
        public ItemList()
        {
            items.Add(new ItemData("수련자 갑옷", 0, 5, "수련에 도움을 주는 갑옷입니다.", 1000, false));
        }
    }

}
