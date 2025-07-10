using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static TextRPG_SpartDungeon.Program;

namespace TextRPG_SpartDungeon
{
    public class StatusScene
    {
        public void StatusView(Character user, InventoryScene inventoryScene, List<ItemData> items)
        {
            Console.WriteLine($"Lv. {user.level.ToString("D2")}");
            Console.WriteLine($"{user.name} ( {user.job} )");
            Console.WriteLine($"공격력 : {user.attackPoint}");
            Console.WriteLine($"방어력 : {user.defensePoint}");
            Console.WriteLine($"체 력 : {user.healthPoint}");
            Console.WriteLine($"Gold : {user.attackPoint} G");
            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            string input = Console.ReadLine();
            if (input == "0")
            {
                EventManager.RunMainScene(this, inventoryScene, user, items);
            }
        }
    }

    public class Character
    {
        public int level;
        public string name;
        public string job;
        public int attackPoint;
        public int defensePoint;
        public int healthPoint;
        public int gold;

        public Character(int level, string name, string job, int attackPoint, int defensePoint, int healthPoint, int gold)
        {
            this.level = level;
            this.name = name;
            this.job = job;
            this.attackPoint = attackPoint;
            this.defensePoint = defensePoint;
            this.healthPoint = healthPoint;
            this.gold = gold;
        }

    }
}
