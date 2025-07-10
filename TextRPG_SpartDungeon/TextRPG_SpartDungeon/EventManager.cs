using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    public delegate void ToWriteText();
    public delegate void ToCheckPlayerInput(GameContext gameContext);

    
    public class LoadMainScene
    {
        public void WriteText()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전입장\n5. 휴식하기");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
        }

        public void CheckPlayerInput(GameContext gameContext)
        {
            int startSelect = int.Parse(Console.ReadLine());
            if (startSelect == 1)
            {
                Console.Clear();
                gameContext.statusScene.StatusView(gameContext);
            }
            else if (startSelect == 2)
            {
                Console.Clear();
                gameContext.inventoryScene.InventoryView(gameContext);
            }
            else if (startSelect == 3)
            {
                Console.Clear();
                gameContext.shopScene.ShopListView(gameContext);
            }
            else if (startSelect == 4)
            {
                Console.Clear();
                Console.WriteLine("미구현");

                WriteText();
                CheckPlayerInput(gameContext);
            }
            else if (startSelect == 5)
            {
                Console.Clear();
                gameContext.eventManager.Rest(gameContext);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");

                WriteText();
                CheckPlayerInput(gameContext);
            }
        }
    }


    public class EventManager
    {
        public static void RunMainScene(GameContext gameContext)
        {
            LoadMainScene scene = new LoadMainScene();

            scene.WriteText();
            scene.CheckPlayerInput(gameContext);
        }

        public void Rest(GameContext gameContext)
        {
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {gameContext.player.gold} G");
            Console.WriteLine("\n1. 휴식하기");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");

            int input = int.Parse(Console.ReadLine());

            if(input == 0)
            {
                Console.Clear();
                RunMainScene(gameContext);
            }
            else if(input == 1)
            {
                if(gameContext.player.gold >= 500)
                {
                    gameContext.player.gold -= 500;
                    gameContext.player.healthPoint = 100;
                    Console.Clear();
                    Console.WriteLine("휴식을 완료했습니다.\n");
                    Rest(gameContext);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Gold 가 부족합니다.");
                    Rest(gameContext);
                }
            }
        }
    }

    public class GameContext
    {
        public LoadMainScene loadMainScene;
        public StatusScene statusScene;
        public InventoryScene inventoryScene;
        public ShopScene shopScene;
        public Character player;
        public List<ItemData> items;
        public List<ItemData > hasItems;
        public EventManager eventManager;
    }
}
