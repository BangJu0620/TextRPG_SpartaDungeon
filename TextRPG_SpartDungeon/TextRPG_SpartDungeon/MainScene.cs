using System.Numerics;
using static TextRPG_SpartDungeon.StatusScene;

namespace TextRPG_SpartDungeon
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            StatusScene statusScene = new StatusScene();
            LoadMainScene loadMainScene = new LoadMainScene();
            InventoryScene inventoryScene = new InventoryScene();
            Character player = new Character(1, "Chad", "전사", 10, 5, 100, 1500);
            ItemList itemList = new ItemList();
            ItemList hasItemList = new ItemList();
            

            ToWriteText writeTxt = loadMainScene.WriteText;
            ToCheckPlayerInput checkPlayerInput = loadMainScene.CheckPlayerInput;

            writeTxt();
            checkPlayerInput(statusScene, inventoryScene, player, itemList.items, hasItemList.items);

            Console.WriteLine(itemList.items[0].itemPrice);

        }
    }
}
