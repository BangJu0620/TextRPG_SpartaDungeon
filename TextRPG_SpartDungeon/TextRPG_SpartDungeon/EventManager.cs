using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
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
            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전입장\n5. 휴식하기\n6. 저장하기/불러오기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
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
                gameContext.dungeonScene.DungeonListView(gameContext);

                WriteText();
                CheckPlayerInput(gameContext);
            }
            else if (startSelect == 5)
            {
                Console.Clear();
                gameContext.eventManager.Rest(gameContext);
            }
            else if(startSelect == 6)
            {
                Console.Clear();
                gameContext.saveLoadData.SaveLoadScene(gameContext);
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
            Console.WriteLine("휴식하기");
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

        public void LevelUp(GameContext gameContext)
        {
            if(gameContext.player.level == gameContext.player.exp)
            {
                Console.WriteLine("레벨업! 축하드립니다!");
                Console.WriteLine($"Lv.{gameContext.player.level.ToString("D2")} -> {(gameContext.player.level + 1).ToString("D2")}\n");
                gameContext.player.level++;
                gameContext.player.exp = 0;
                gameContext.player.attackPoint += 0.5f;
                gameContext.player.defensePoint += 1;
            }
        }
    }

    public class SaveLoadData
    {
        public void SaveLoadScene(GameContext gameContext)
        {
            Console.WriteLine("저장하기 / 불러오기");
            Console.WriteLine("\n1. 저장하기\n2. 불러오기\n0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");

            string input = Console.ReadLine();

            if(input == "0")
            {
                Console.Clear();
                EventManager.RunMainScene(gameContext);
            }
            else if(input == "1")
            {
                Console.Clear();
                SaveItemData(gameContext);
                SaveLoadScene(gameContext);
            }
            else if(input == "2")
            {
                Console.Clear();
                LoadItemData(gameContext);
                SaveLoadScene(gameContext);
            }
        }
        public static void SaveItemData(GameContext gameContext)
        {
            using (StreamWriter writer = new StreamWriter(gameContext.filePath))
            {
                writer.WriteLine("Name, Type, AttackPoint, DefensePoint, Description, Price, IsOwned, IsEquipped");

                foreach(var item in gameContext.items)
                {
                    string line = $"{item.itemName}, {item.itemType}, {item.itemAttackPoint}, {item.itemDefensePoint}, {item.itemDescription}, {item.itemPrice}, {item.isOwned}, {item.isEquipped}";
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("저장 완료");
        }

        public static ItemList LoadItemData(GameContext gameContext)
        {
            ItemList items = new ItemList();

            if (!File.Exists(gameContext.filePath))
            {
                Console.WriteLine("저장된 파일이 없습니다.");
                return items;
            }

            string[] lines = File.ReadAllLines(gameContext.filePath);

            for(int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                if(parts.Length == 8)
                {
                    string name = parts[0];
                    string type = parts[1];
                    int AP = int.Parse(parts[2]);
                    int DP = int.Parse(parts[3]);
                    string description = parts[4];
                    int price = int.Parse(parts[5]);
                    bool owned;
                    if (parts[6] == "true")
                    {
                        owned = true;
                    }
                    else
                    {
                        owned = false;
                    }
                    bool equipped;
                    if (parts[7] == "true")
                    {
                        equipped = true;
                    }
                    else
                    {
                        equipped = false;
                    }
                }
            }
            Console.WriteLine("불러오기 완료");
            return items;
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
        public List<Dungeon> dungeons;
        public Random random;
        public DungeonScene dungeonScene;
        public ItemData itemData;
        public SaveLoadData saveLoadData;
        public string filePath;
    }
}
