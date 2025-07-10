using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    public delegate void ToWriteText();
    public delegate void ToCheckPlayerInput(StatusScene statusScene, InventoryScene inventoryScene, ShopScene shopScene, Character player, List<ItemData> items, List<ItemData> hasItems);

    
    public class LoadMainScene
    {
        public void WriteText()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
        }

        public void CheckPlayerInput(StatusScene statusScene, InventoryScene inventoryScene, ShopScene shopScene, Character player, List<ItemData> items, List<ItemData> hasItems)
        {
            int startSelect = int.Parse(Console.ReadLine());
            if (startSelect == 1)
            {
                Console.Clear();
                statusScene.StatusView(statusScene, inventoryScene, shopScene, player, items, hasItems);
            }
            else if (startSelect == 2)
            {
                Console.Clear();
                inventoryScene.InventoryView(statusScene, inventoryScene, shopScene, player, items, hasItems);
            }
            else if (startSelect == 3)
            {
                Console.Clear();
                shopScene.ShopListView(statusScene, inventoryScene, shopScene, player, items, hasItems);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");

                WriteText();
                CheckPlayerInput(statusScene, inventoryScene, shopScene, player, items, hasItems);
            }
        }
    }


    public class EventManager
    {
        public static void RunMainScene(StatusScene statusScene, InventoryScene inventoryScene, ShopScene shopScene, Character player, List<ItemData> items, List<ItemData> hasItems)
        {
            LoadMainScene scene = new LoadMainScene();

            scene.WriteText();
            scene.CheckPlayerInput(statusScene, inventoryScene, shopScene, player, items, hasItems);
        }
    }
}
