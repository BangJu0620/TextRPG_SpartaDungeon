using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    public class InventoryScene
    {
        public void InventoryView(List<ItemData> itemList)
        {
            foreach(ItemData item in itemList)
            {
                if(item.isOwned == true)
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}");
                    }
                }
            }
        }
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
            items.Add(new ItemData("무쇠갑옷", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, false));
            items.Add(new ItemData("스파르타의 갑옷", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, false));
            items.Add(new ItemData("낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.", 600, false));
            items.Add(new ItemData("청동 도끼", 5, 0, "어디선가 사용됐던거 같은 도끼입니다.", 1500, false));
            items.Add(new ItemData("스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2300, false));
        }
    }

}
