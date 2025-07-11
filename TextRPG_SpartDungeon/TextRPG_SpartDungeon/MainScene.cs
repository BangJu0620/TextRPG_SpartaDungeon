using System.Numerics;
using static TextRPG_SpartDungeon.StatusScene;

namespace TextRPG_SpartDungeon
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            ItemList itemList = new ItemList();
            HasItemList hasItemList = new HasItemList();
            DungeonList dungeonList = new DungeonList();
            GameContext gameContext = new GameContext
            {
                statusScene = new StatusScene(),
                loadMainScene = new LoadMainScene(),
                inventoryScene = new InventoryScene(),
                shopScene = new ShopScene(),
                player = new Character(1, "Chad", "전사", 10, 5, 100, 50000, 0),
                items = itemList.items,
                hasItems = hasItemList.hasItems,
                eventManager = new EventManager(),
                dungeons = dungeonList.dungeons,
                random = new Random(),
                dungeonScene = new DungeonScene(),
                saveLoadData = new SaveLoadData(),
                filePath = "save"
            };

            ToWriteText writeTxt = gameContext.loadMainScene.WriteText;
            ToCheckPlayerInput checkPlayerInput = gameContext.loadMainScene.CheckPlayerInput;

            writeTxt();
            checkPlayerInput(gameContext);


        }
    }
}
