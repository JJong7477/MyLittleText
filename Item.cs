using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG_JJong7477
{
    enum ItemType
    {
        Armor = 0, // 방어구
        Weapon = 1, // 무기
        Accessory = 2 // 장신구
    }
    internal class Item
    {
        public string Name { get; set; }              //프로퍼티 아이템 이름
        public string Description { get; set; }       //아이템 설명
        public int ItemAttack { get; set; }           //아이템 공격력
        public int ItemDefense { get; set; }          //아이템 방어력
        public int ItemPrice { get; set; }            //아이템 가격
        public bool IsPlayerItem { get; set; } = false; //아이템이 플레이어의 아이템인지 확인하는 변수
        public bool IsEquipped { get; set; } = false; //아이템이 장착된 상태인지 확인하는 변수

        public ItemType ItemType { get; set; }               //아이템 타입 (0 방어구, 1 무기, 2 장신구)
    }
}