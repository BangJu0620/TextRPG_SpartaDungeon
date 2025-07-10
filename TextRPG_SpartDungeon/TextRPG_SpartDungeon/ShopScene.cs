using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    public class ShopScene
    {
        public void ShopListView(StatusScene statusScene, InventoryScene inventoryScene, ShopScene shopScene, Character player, List<ItemData> items, List<ItemData> hasItems)
        {
            Console.WriteLine($"[보유골드]\n{player.gold} G\n");
            Console.WriteLine($"[아이템 목록]");

            foreach (ItemData item in items)
            {
                if (item.isOwned == true)
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}\t|  구매완료");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}\t|  구매완료");
                    }
                }
                else
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}\t|  {item.itemPrice} G");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}\t|  {item.itemPrice} G");
                    }
                }
            }

            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("0. 나가기");

            Console.Write("원하시는 행동을 입력해주세요.\n>>");

            string input = Console.ReadLine();
            if (input == "0")
            {
                EventManager.RunMainScene(statusScene, inventoryScene, shopScene, player, items, hasItems);
            }
            else if (input == "1")
            {
                HandleBuy(statusScene, inventoryScene, shopScene, player, items, hasItems);
            }
        }

        public void HandleBuy(StatusScene statusScene, InventoryScene inventoryScene, ShopScene shopScene, Character player, List<ItemData> items, List<ItemData> hasItems)
        {
            Console.WriteLine($"[보유골드]\n{player.gold} G\n");
            Console.WriteLine($"[아이템 목록]");

            foreach (ItemData item in items)
            {
                if (item.isOwned == true)
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {items.IndexOf(item) + 1} {item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}\t|  구매완료");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {items.IndexOf(item) + 1} {item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}\t|  구매완료");
                    }
                }
                else
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {items.IndexOf(item) + 1} {item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}\t|  {item.itemPrice} G");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {items.IndexOf(item) + 1} {item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}\t|  {item.itemPrice} G");
                    }
                }
            }

            Console.WriteLine("\n0. 나가기");

            Console.Write("원하시는 행동을 입력해주세요.\n>>");

            string input = Console.ReadLine();

            if (0 <= int.Parse(input) && int.Parse(input) <= items.Count)
            {
                if(input == "0")
                {
                    ShopListView(statusScene, inventoryScene, shopScene, player, items, hasItems);
                }
                else
                {
                    for (int i = 1; i <= items.Count; i++)
                    {
                        if (int.Parse(input) == i)
                        {
                            if (items[i - 1].isOwned)
                            {
                                Console.WriteLine("이미 구매한 아이템입니다.");
                                HandleBuy(statusScene, inventoryScene, shopScene, player, items, hasItems);
                            }
                            else
                            {
                                if (player.gold >= items[i - 1].itemPrice)
                                {
                                    player.gold -= items[i - 1].itemPrice;
                                    items[i - 1].isOwned = true;
                                    Console.WriteLine("구매를 완료했습니다.");
                                    HasItemList.GetItem(items, hasItems);
                                    HandleBuy(statusScene, inventoryScene, shopScene, player, items, hasItems);
                                }
                                else
                                {
                                    Console.WriteLine("Gold 가 부족합니다.");
                                    HandleBuy(statusScene, inventoryScene, shopScene, player, items, hasItems);
                                }
                            }
                        }
                    }
                } 
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }

            HandleBuy(statusScene, inventoryScene, shopScene, player, items, hasItems);
        }
    }
}
