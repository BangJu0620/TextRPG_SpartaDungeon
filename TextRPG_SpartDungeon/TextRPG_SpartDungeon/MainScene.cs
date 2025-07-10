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
            Character player = new Character(1, "Chad", "전사", 10, 5, 100, 1500);
            

            ToWriteText writeTxt = loadMainScene.WriteText;
            ToCheckPlayerInput checkPlayerInput = loadMainScene.CheckPlayerInput;

            writeTxt();
            checkPlayerInput(statusScene, player);

            

        }
    }
}
