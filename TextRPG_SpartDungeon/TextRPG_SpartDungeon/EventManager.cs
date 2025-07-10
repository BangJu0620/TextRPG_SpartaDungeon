using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    public delegate void ToWriteText();
    public delegate void ToCheckPlayerInput(StatusScene statusScene, Character player);

    
    public class LoadMainScene
    {
        public void WriteText()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
        }

        public void CheckPlayerInput(StatusScene statusScene, Character player)
        {
            bool isCorrectInput = false;

            while (!isCorrectInput)
            {
                int startSelect;
                isCorrectInput = int.TryParse(Console.ReadLine(), out startSelect);
                if (startSelect == 1)
                {
                    isCorrectInput = true;
                    statusScene.StatusView(player);
                    break;
                }
                else if (startSelect == 2)
                {
                    isCorrectInput = true;
                    break;
                }
                else if (startSelect == 3)
                {
                    isCorrectInput = true;
                    break;
                }
                else
                {
                    isCorrectInput = false;
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
        }
    }

    public class EnterShop
    {
        public void WriteList(Character user)
        {
            Console.WriteLine($"[보유골드]\n{user.gold} G\n");
            Console.WriteLine($"[아이템 목록]");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
        }

        public void CheckPlayerInput(StatusScene statusScene, Character player)
        {
            bool isCorrectInput = false;

            while (!isCorrectInput)
            {
                int startSelect;
                isCorrectInput = int.TryParse(Console.ReadLine(), out startSelect);
                if (startSelect == 1)
                {
                    isCorrectInput = true;
                    statusScene.StatusView(player);
                    break;
                }
                else if (startSelect == 2)
                {
                    isCorrectInput = true;
                    break;
                }
                else if (startSelect == 3)
                {
                    isCorrectInput = true;
                    break;
                }
                else
                {
                    isCorrectInput = false;
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
        }
    }
    internal class EventManager
    {
        public static void RunMainScene(StatusScene statusScene, Character player)
        {
            LoadMainScene scene = new LoadMainScene();

            scene.WriteText();
            scene.CheckPlayerInput(statusScene, player);
        }
    }
}
