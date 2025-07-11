using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    public class InventoryScene
    {
        public void InventoryView(GameContext gameContext)
        {
            Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");
            foreach(ItemData item in gameContext.hasItems)
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
                Console.Clear();
                EventManager.RunMainScene(gameContext);
            }
            else if(input == "1")
            {
                Console.Clear();
                HandleEquip(gameContext);
            }
        }

        public void HandleEquip(GameContext gameContext)
        {
            Console.WriteLine("인벤토리 - 장착 관리\n보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");
            foreach (ItemData item in gameContext.hasItems)
            {
                if (item.isEquipped == true)
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {gameContext.hasItems.IndexOf(item) + 1} [E]{item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {gameContext.hasItems.IndexOf(item) + 1} [E]{item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}");
                    }
                }
                else
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {gameContext.hasItems.IndexOf(item) + 1} {item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {gameContext.hasItems.IndexOf(item) + 1} {item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}");
                    }
                }
            }
            Console.WriteLine("\n0. 나가기");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");

            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.Clear();
                InventoryView(gameContext);
            }
            else
            {
                for(int i = 1; i < gameContext.hasItems.Count + 1; i++)
                {
                    if(int.Parse(input) == i)
                    {
                        if (gameContext.hasItems[i - 1].isEquipped)
                        {
                            gameContext.hasItems[i - 1].isEquipped = false;
                        }
                        else
                        {
                            foreach (ItemData item in gameContext.hasItems)
                            {
                                if (gameContext.hasItems[i - 1].itemType == item.itemType && item.isEquipped)
                                {
                                    item.isEquipped = false;
                                }
                            }
                            gameContext.hasItems[i - 1].isEquipped = true;
                        }
                    }
                }
                Console.Clear();
                HandleEquip(gameContext);
            }
        }
    }

    public class ItemData
    {
        public string itemName;
        public string itemType;
        public int itemAttackPoint;
        public int itemDefensePoint;
        public string itemDescription;
        public int itemPrice;
        public bool isOwned;
        public bool isEquipped;

        public ItemData(string iName, string iType,int iAP, int iDP, string iDescription, int iPrice, bool iOwned, bool iEquipped)
        {
            itemName = iName;
            itemType = iType;
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
            items.Add(new ItemData("천 갑옷", "Armor", 0, 3, "얇지만 움직이기 쉬운 천 갑옷입니다.", 700, false, false));
            items.Add(new ItemData("수련자 갑옷", "Armor", 0, 5, "수련에 도움을 주는 갑옷입니다.", 1000, false, false));
            items.Add(new ItemData("무쇠갑옷", "Armor", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1800, false, false));
            items.Add(new ItemData("스파르타의 갑옷", "Armor", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, false, false));
            items.Add(new ItemData("낡은 검", "Weapon", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.", 600, false, false));
            items.Add(new ItemData("짧은 단검", "Weapon", 3, 0, "빠르고 가볍지만 위력이 낮은 단검입니다.", 900, false, false));
            items.Add(new ItemData("청동 도끼", "Weapon", 5, 0, "어디선가 사용됐던거 같은 도끼입니다.", 1500, false, false));
            items.Add(new ItemData("스파르타의 창", "Weapon", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2700, false, false));
        }
    }

    public class HasItemList
    {
        public List<ItemData> hasItems = new List<ItemData>();

        public static void GetItem(GameContext gameContext)
        {
            foreach(ItemData item in gameContext.items)
            {
                if (item.isOwned && !gameContext.hasItems.Contains(item))
                {
                    gameContext.hasItems.Add(item);
                }
            }
        }

        public static void RemoveItem(GameContext gameContext)
        {
            foreach(ItemData item in gameContext.items)
            {
                if(!item.isOwned)
                {
                    gameContext.hasItems.Remove(item);
                }
            }
        }
    }
}
