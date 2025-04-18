using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG_JJong7477
{
    internal class Player
    {
        public int Gold { get; set; } = 1500000;   //플레이어의 골드
        public int Lvl { get; set; } = 1;     //플레이어의 레벨
        public float Attack { get; set; } = 10; //플레이어의 공격력
        public int Defense { get; set; } = 5; //플레이어의 방어력
        public int Hp { get; set; } = 100;   //플레이어의 체력
        public int Exp { get; set; } = 0; //플레이어의 경험치

        public string job = "코딩 초보";

        public static List<Item> InventoryItems = new List<Item>(); //인벤토리 리스트 생성
        //만약 플레이어가 아이템을 샀다면 리스트에 해당 아이템을 추가해야함.
        //만약 플레이어가 아이템을 장착했다면 리스트에 해당 아이템을 추가해야함. (isEquipped = true) 로 가능하지 않을까?

        public static void ShowInventoryItems(bool isEquipMenu)
        {
            for (int i = 0; i < InventoryItems.Count; i++)
            {
                Item items = InventoryItems[i];

                //if (isEquipMenu == false && items.IsEquipped == false)                      //인벤토리메뉴에서 장착X
                //{
                //    Console.WriteLine($"- {items.Name} |공격력 +{items.ItemAttack} 방어력 +{items.ItemDefense}| {items.Description}");
                //}
                //else if (isEquipMenu == true && items.IsEquipped == false)                  //장착메뉴에서 장착X
                //{
                //    Console.WriteLine($"- {i + 1} {items.Name} |공격력 +{items.ItemAttack} 방어력 +{items.ItemDefense}| {items.Description}");
                //}
                //else if (isEquipMenu == true && items.IsEquipped == true)                   //인벤토리메뉴에서 장착O
                //{
                //    Console.WriteLine($"- {i + 1} [E]{items.Name} |공격력 +{items.ItemAttack} 방어력 +{items.ItemDefense}| {items.Description}");
                //}
                //else if (isEquipMenu == false && items.IsEquipped == true)                  //장착메뉴에서 장착O
                //{
                //    Console.WriteLine($"- [E]{items.Name} |공격력 +{items.ItemAttack} 방어력 +{items.ItemDefense}| {items.Description}");
                //}

                if (isEquipMenu == true) //장착메뉴
                {
                    string equipped = items.IsEquipped ? "[E]" : ""; //장착된 아이템은 [E]로 표시
                    Console.WriteLine($"- {i + 1} {equipped}{items.Name} |공격력 +{items.ItemAttack} 방어력 +{items.ItemDefense}| {items.Description}");
                }
                else //인벤토리메뉴
                {
                    string equipped = items.IsEquipped ? "[E]" : ""; //장착된 아이템은 [E]로 표시
                    Console.WriteLine($"- {equipped}{items.Name} |공격력 +{items.ItemAttack} 방어력 +{items.ItemDefense}| {items.Description}");
                }
            }
        }

        public void ShowAttackStack()
        {
            int plusAttack = 0;

            for (int i = 0; i < InventoryItems.Count; i++)
            {
                Item items = InventoryItems[i];
                if (items.IsEquipped == true) //장착된 아이템의 공격력
                {
                    plusAttack += items.ItemAttack;
                }
            }

            Console.WriteLine($" + ({plusAttack})");
        }

        public void ShowDefenseStack()
        {
            int plusDefense = 0;

            for (int i = 0; i < InventoryItems.Count; i++)
            {
                Item items = InventoryItems[i];
                if (items.IsEquipped == true) //장착된 아이템의 방어력
                {
                    plusDefense += items.ItemDefense;
                }
            }

            Console.WriteLine($" + ({plusDefense})");
        }

        public void EXP()
        {
            ++Exp;

            if (Exp == Lvl)
            {
                Lvl++;
                Exp = 0;
                Attack += 0.5f;
                Defense++;
                Console.WriteLine("레벨업했습니다.");
                return;
            }

            Console.WriteLine("경험치가 증가했습니다.");
        }
    }
}
