using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG_JJong7477
{
    internal class Shop
    {
        public static List<Item> Items = new List<Item>();

        public static void MakeShopItems()
        {
            Items.Add(new Item
            {
                Name = "수련자 갑옷",
                Description = "수련에 도움을 주는 갑옷입니다.",
                ItemAttack = 0,
                ItemDefense = 5,
                ItemPrice = 1000,
                IsPlayerItem = false,
                ItemType = ItemType.Armor
            });

            Items.Add(new Item
            {
                Name = "무쇠갑옷",
                Description = "무쇠로 만들어져 튼튼한 갑옷입니다.",
                ItemAttack = 0,
                ItemDefense = 9,
                ItemPrice = 2000,
                IsPlayerItem = false,
                ItemType = ItemType.Armor
            });

            Items.Add(new Item
            {
                Name = "스파르타의 갑옷",
                Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                ItemAttack = 0,
                ItemDefense = 15,
                ItemPrice = 3500,
                IsPlayerItem = false,
                ItemType = ItemType.Armor
            });

            Items.Add(new Item
            {
                Name = "낡은 검",
                Description = "쉽게 볼 수 있는 낡은 검 입니다.",
                ItemAttack = 2,
                ItemDefense = 0,
                ItemPrice = 600,
                IsPlayerItem = false,
                ItemType = ItemType.Weapon
            });

            Items.Add(new Item
            {
                Name = "청동 도끼",
                Description = "어디선가 사용됐던거 같은 도끼입니다.",
                ItemAttack = 5,
                ItemDefense = 0,
                ItemPrice = 1500,
                IsPlayerItem = false,
                ItemType = ItemType.Weapon
            });

            Items.Add(new Item
            {
                Name = "스파르타의 창",
                Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.",
                ItemAttack = 15,
                ItemDefense = 0,
                ItemPrice = 4000,
                IsPlayerItem = false,
                ItemType = ItemType.Weapon
            });

            Items.Add(new Item
            {
                Name = "낡은 키보드와 마우스",
                Description = "코딩근육을 키워봅시다.",
                ItemAttack = 4,
                ItemDefense = 3,
                ItemPrice = 1500,
                IsPlayerItem = false,
                ItemType = ItemType.Accessory
            });
        }
        public static void ShowShopItems(bool buyingMenu)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Item items = Items[i];

                if (buyingMenu == false)
                {
                    Console.Write($"- {items.Name} |공격력 +{items.ItemAttack} 방어력 +{items.ItemDefense}| {items.Description} | ");
                }
                else
                {
                    Console.Write($"- {i+1} {items.Name} |공격력 +{items.ItemAttack} 방어력 +{items.ItemDefense}| {items.Description} | ");
                }

                //아이템이 플레이어의 인벤토리에 존재하지 않는다면 구매가격
                if (items.IsPlayerItem == false) { Console.WriteLine($"{items.ItemPrice} G"); }

                //만약 아이템이 플레이어의 인벤토리에 존재한다면 구매완료
                else { Console.WriteLine("보유중"); }
            }
        }
    }
}
