using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_SpartDungeon
{
    public class DungeonScene
    {
        public void DungeonListView(GameContext gameContext)
        {
            Console.WriteLine("던전입장\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            foreach(Dungeon dungeon in gameContext.dungeons)
            {
                Console.WriteLine($"{gameContext.dungeons.IndexOf(dungeon) + 1}. {dungeon.name}\t| 방어력 {dungeon.recommandDefensePoint} 이상 권장");
            }
            Console.WriteLine("0. 나가기");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");

            string input = Console.ReadLine();

            Console.Clear();

            if (0 <= int.Parse(input) && int.Parse(input) <= gameContext.dungeons.Count)
            {
                if(input == "0")
                {
                    EventManager.RunMainScene(gameContext);
                }
                else
                {
                    for(int i = 0; i < gameContext.dungeons.Count; i++)
                    {
                        DungeonClearCheck(input, i, gameContext);
                    }
                    string playerSelect = Console.ReadLine();
                    if (playerSelect == "0")
                    {
                        Console.Clear();
                        DungeonListView(gameContext);
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.\n");
                DungeonListView(gameContext);
            }
        }

        public void DungeonClearCheck(string input, int i, GameContext gameContext)
        {
            if(int.Parse(input) - 1 == i)
            {
                int damage = gameContext.random.Next(gameContext.dungeons[i].lossHealthPoint[0], gameContext.dungeons[i].lossHealthPoint[1]) - gameContext.player.defensePoint + gameContext.dungeons[i].recommandDefensePoint;
                float bonus = gameContext.random.Next((int)gameContext.player.attackPoint, (int)gameContext.player.attackPoint * 2) * 0.01f;
                if(gameContext.player.defensePoint >= gameContext.dungeons[i].recommandDefensePoint)
                {
                    if (gameContext.player.healthPoint > damage)
                    {
                        gameContext.player.exp++;
                        gameContext.eventManager.LevelUp(gameContext);
                        Console.WriteLine($"던전 클리어\n축하합니다!!\n{gameContext.dungeons[i].name}을 클리어 하셨습니다.");

                        Console.WriteLine($"\n[탐험 결과]\n체력 {gameContext.player.healthPoint} -> {gameContext.player.healthPoint - damage}");
                        gameContext.player.healthPoint -= damage;

                        Console.WriteLine($"Gold {gameContext.player.gold} -> {gameContext.player.gold + gameContext.dungeons[i].clearReward}");
                        gameContext.player.gold += gameContext.dungeons[i].clearReward + (int)(gameContext.dungeons[i].clearReward * bonus);

                        Console.WriteLine("\n0. 나가기");

                        Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                    }
                    else
                    {
                        Console.Write("게임 오버!\n\n0. 되돌아가기\n원하시는 행동을 입력해주세요.\n>>");
                    }
                }
                else
                {
                    if (gameContext.player.healthPoint > damage)
                    {
                        int dungeonFail = gameContext.random.Next(1, 6);
                        if (dungeonFail < 3)
                        {
                            Console.WriteLine("던전 실패");
                            Console.WriteLine("캐릭터를 더 성장시키고 다시 도전해주세요.");

                            Console.WriteLine($"\n[탐험 결과]\n체력 {gameContext.player.healthPoint} -> {gameContext.player.healthPoint - damage / 2}");
                            gameContext.player.healthPoint -= damage / 2;

                            Console.WriteLine("\n0. 나가기");

                            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                        }
                        else
                        {
                            if (gameContext.player.healthPoint > damage)
                            {
                                gameContext.player.exp++;
                                gameContext.eventManager.LevelUp(gameContext);
                                Console.WriteLine($"던전 클리어\n축하합니다!!\n{gameContext.dungeons[i].name}을 클리어 하셨습니다.");

                                Console.WriteLine($"\n[탐험 결과]\n체력 {gameContext.player.healthPoint} -> {gameContext.player.healthPoint - damage}");
                                gameContext.player.healthPoint -= damage;

                                Console.WriteLine($"Gold {gameContext.player.gold} -> {gameContext.player.gold + gameContext.dungeons[i].clearReward}");
                                gameContext.player.gold += gameContext.dungeons[i].clearReward + (int)(gameContext.dungeons[i].clearReward * bonus);

                                Console.WriteLine("\n0. 나가기");

                                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                            }
                            else
                            {
                                Console.Write("게임 오버!\n\n0. 되돌아가기\n원하시는 행동을 입력해주세요.\n>>");
                            }
                        }
                    }
                    else
                    {
                        Console.Write("게임 오버!\n\n0. 되돌아가기\n원하시는 행동을 입력해주세요.\n>>");
                    }   
                }
            }
        }

        public void DungeonClearLossHealthPoint(GameContext gameContext)
        {

        }

        public void DungeonClearGetReward()
        {

        }
    }

    public class Dungeon
    {
        public string name;
        public int recommandDefensePoint;
        public int recommandAttackPoint;
        public int clearReward;
        public int[] lossHealthPoint;

        public Dungeon(string dungeonName, int recommandDP, int recommandAP, int clear, int[] lossHP)
        {
            name = dungeonName;
            recommandDefensePoint = recommandDP;
            recommandAttackPoint = recommandAP;
            clearReward = clear;
            lossHealthPoint = lossHP;
        }
    }

    public class DungeonList
    {
        public List<Dungeon> dungeons = new List<Dungeon>();

        public DungeonList()
        {
            dungeons.Add(new Dungeon("쉬운 던전", 5, 10, 1000, [20, 35]));
            dungeons.Add(new Dungeon("일반 던전", 11, 12, 1700, [20, 35]));
            dungeons.Add(new Dungeon("어려운 던전", 17, 15, 2500, [20, 35]));
        }
    }
}
