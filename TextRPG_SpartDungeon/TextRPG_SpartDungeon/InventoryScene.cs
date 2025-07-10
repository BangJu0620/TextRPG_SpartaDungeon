using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    public class InventoryScene
    {
        public void InventoryView(StatusScene statusScene, InventoryScene inventoryScene, ShopScene shopScene, Character player, List<ItemData> items, List<ItemData> hasItems)
        {
            Console.WriteLine("[아이템 목록]");
            foreach(ItemData item in hasItems)
            {
                if (item.isEquipped == true)
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- [E]{item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- [E]{item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}");
                    }
                }
                else
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
            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");

            string input = Console.ReadLine();
            if (input == "0")
            {
                EventManager.RunMainScene(statusScene, inventoryScene, shopScene, player, items, hasItems);
            }
            else if(input == "1")
            {
                HandleEquip(statusScene, inventoryScene, shopScene, player, items, hasItems);
            }
        }

        public void HandleEquip(StatusScene statusScene, InventoryScene inventoryScene, ShopScene shopScene, Character player, List<ItemData> items, List<ItemData> hasItems)
        {
            Console.WriteLine("[아이템 목록]");
            foreach (ItemData item in hasItems)
            {
                if (item.isEquipped == true)
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {hasItems.IndexOf(item) + 1} [E]{item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {hasItems.IndexOf(item) + 1} [E]{item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}");
                    }
                }
                else
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {hasItems.IndexOf(item) + 1} {item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {hasItems.IndexOf(item) + 1} {item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}");
                    }
                }
            }
            Console.WriteLine("\n0. 나가기");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");

            string input = Console.ReadLine();
            if (input == "0")
            {
                InventoryView(statusScene, inventoryScene, shopScene, player, items, hasItems);
            }
            else
            {
                for(int i = 1; i < hasItems.Count + 1; i++)
                {
                    if(int.Parse(input) == i)
                    {
                        if (hasItems[i - 1].isEquipped)
                        {
                            hasItems[i - 1].isEquipped = false;
                        }
                        else
                        {
                            hasItems[i - 1].isEquipped = true;
                        }
                    }
                }
                HandleEquip(statusScene, inventoryScene, shopScene, player, items, hasItems);
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
        public bool isEquipped;

        public ItemData(string iName, int iAP, int iDP, string iDescription, int iPrice, bool iOwned, bool iEquipped)
        {
            itemName = iName;
            itemAttackPoint = iAP;
            itemDefensePoint = iDP;
            itemDescription = iDescription;
            itemPrice = iPrice;
            isOwned = iOwned;
            isEquipped = iEquipped;
        }
    }

    public class ItemList
    {
        public List<ItemData> items = new List<ItemData>();
        
        public ItemList()
        {
            items.Add(new ItemData("수련자 갑옷", 0, 5, "수련에 도움을 주는 갑옷입니다.", 1000, false, false));
            items.Add(new ItemData("무쇠갑옷", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, false, false));
            items.Add(new ItemData("스파르타의 갑옷", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, false, false));
            items.Add(new ItemData("낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.", 600, false, false));
            items.Add(new ItemData("청동 도끼", 5, 0, "어디선가 사용됐던거 같은 도끼입니다.", 1500, false, false));
            items.Add(new ItemData("스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2300, false, false));
        }
    }

    public class HasItemList
    {
        public List<ItemData> hasItems = new List<ItemData>();

        public static void GetItem(List<ItemData> items, List<ItemData> hasItems)
        {
            foreach(ItemData item in items)
            {
                if (item.isOwned && !hasItems.Contains(item))
                {
                    hasItems.Add(item);
                }
            }
        }
    }
}
