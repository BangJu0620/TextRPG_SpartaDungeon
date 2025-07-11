using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    public class ShopScene
    {
        public void ShopListView(GameContext gameContext)
        {
            Console.WriteLine($"[보유골드]\n{gameContext.player.gold} G\n");
            Console.WriteLine($"[아이템 목록]");

            foreach (ItemData item in gameContext.items)
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
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");

            Console.Write("원하시는 행동을 입력해주세요.\n>>");

            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.Clear();
                EventManager.RunMainScene(gameContext);
            }
            else if (input == "1")
            {
                Console.Clear();
                HandleBuy(gameContext);
            }
            else if(input == "2")
            {
                Console.Clear();
                HandleSell(gameContext);
            }
        }

        public void HandleBuy(GameContext gameContext)
        {
            Console.WriteLine($"[보유골드]\n{gameContext.player.gold} G\n");
            Console.WriteLine($"[아이템 목록]");

            foreach (ItemData item in gameContext.items)
            {
                if (item.isOwned == true)
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {gameContext.items.IndexOf(item) + 1} {item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}\t|  구매완료");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {gameContext.items.IndexOf(item) + 1} {item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}\t|  구매완료");
                    }
                }
                else
                {
                    if (item.itemAttackPoint != 0)
                    {
                        Console.WriteLine($"- {gameContext.items.IndexOf(item) + 1} {item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}\t|  {item.itemPrice} G");
                    }
                    else if (item.itemDefensePoint != 0)
                    {
                        Console.WriteLine($"- {gameContext.items.IndexOf(item) + 1} {item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}\t|  {item.itemPrice} G");
                    }
                }
            }

            Console.WriteLine("\n0. 나가기");

            Console.Write("원하시는 행동을 입력해주세요.\n>>");

            string input = Console.ReadLine();

            if (0 <= int.Parse(input) && int.Parse(input) <= gameContext.items.Count)
            {
                if(input == "0")
                {
                    Console.Clear();
                    ShopListView(gameContext);
                }
                else
                {
                    for (int i = 1; i <= gameContext.items.Count; i++)
                    {
                        if (int.Parse(input) == i)
                        {
                            if (gameContext.items[i - 1].isOwned)
                            {
                                Console.Clear();
                                Console.WriteLine("이미 구매한 아이템입니다.\n");
                                HandleBuy(gameContext);
                            }
                            else
                            {
                                if (gameContext.player.gold >= gameContext.items[i - 1].itemPrice)
                                {
                                    gameContext.player.gold -= gameContext.items[i - 1].itemPrice;
                                    gameContext.items[i - 1].isOwned = true;
                                    Console.Clear();
                                    Console.WriteLine("구매를 완료했습니다.\n");
                                    HasItemList.GetItem(gameContext);
                                    HandleBuy(gameContext);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Gold 가 부족합니다.\n");
                                    HandleBuy(gameContext);
                                }
                            }
                        }
                    }
                } 
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");
                HandleBuy(gameContext);
            }
        }

        public void HandleSell(GameContext gameContext)
        {
            Console.WriteLine($"[보유골드]\n{gameContext.player.gold} G\n");
            Console.WriteLine($"[아이템 목록]");

            foreach (ItemData item in gameContext.hasItems)
            {
                if (item.itemAttackPoint != 0)
                {
                    Console.WriteLine($"- {gameContext.hasItems.IndexOf(item) + 1} {item.itemName}\t| 공격력 +{item.itemAttackPoint}\t| {item.itemDescription}\t|  {item.itemPrice} G");
                }
                else if (item.itemDefensePoint != 0)
                {
                    Console.WriteLine($"- {gameContext.hasItems.IndexOf(item) + 1} {item.itemName}\t| 방어력 +{item.itemDefensePoint}\t| {item.itemDescription}\t|  {item.itemPrice} G");
                }
            }

            Console.WriteLine("\n0. 나가기");

            Console.Write("원하시는 행동을 입력해주세요.\n>>");

            string input = Console.ReadLine();

            if (0 <= int.Parse(input) && int.Parse(input) <= gameContext.hasItems.Count)
            {
                if (input == "0")
                {
                    Console.Clear();
                    ShopListView(gameContext);
                }
                else
                {
                    for (int i = 1; i <= gameContext.hasItems.Count; i++)
                    {
                        if (int.Parse(input) == i)
                        {
                            if (gameContext.hasItems[i - 1].isEquipped)
                            {
                                gameContext.player.gold += (int)(gameContext.hasItems[i - 1].itemPrice * 0.85f);
                                gameContext.hasItems[i - 1].isOwned = false;
                                gameContext.hasItems[i - 1].isEquipped = false;
                                Console.Clear();
                                Console.WriteLine("판매를 완료했습니다.\n");
                                HasItemList.RemoveItem(gameContext);
                                HandleSell(gameContext);
                            }
                            else
                            {
                                gameContext.player.gold += (int)(gameContext.hasItems[i - 1].itemPrice * 0.85f);
                                gameContext.hasItems[i - 1].isOwned = false;
                                Console.Clear();
                                Console.WriteLine("판매를 완료했습니다.\n");
                                HasItemList.RemoveItem(gameContext);
                                HandleSell(gameContext);
                            } 
                        }
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");
                HandleSell(gameContext);
            }
        }
    }
}
