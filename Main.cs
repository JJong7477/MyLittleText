using System.ComponentModel;
using System.Linq;

namespace Text_RPG_JJong7477
{
    internal class GameManager
    {

        Player player = new Player();            //플레이어 객체 생성.
        Item item = new Item();                  //아이템 객체 생성.
        Shop shop = new Shop();                  //상점 객체 생성.


        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("코린이 마을에 오신 용사님 환영합니다.");
            Console.WriteLine("이곳은 코딩던전으로 들어가기전 활동을 할 수 있는 곳입니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태창 보기");
            Console.WriteLine("2. 인벤토리 열기");
            Console.WriteLine("3. 상점 입장");
            Console.WriteLine("4. 던전 입장(미구현)");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine("");
            Console.WriteLine("0. 게임 종료(미구현)");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int route = int.Parse(Console.ReadLine());

            switch (route)
            {
                case 1:
                    StatusMenu();
                    break;
                case 2:
                    InventoryMenu();
                    break;
                case 3:
                    ShopMenu();
                    break;
                case 4:
                    Console.WriteLine("던전은 아직 구현되지 않았습니다.");
                    Thread.Sleep(1000);
                    MainMenu();
                    break;
                case 5:
                    RestMenu();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                    Thread.Sleep(1000);                                          //1초 대기후, 아래 메소드 실행.
                    MainMenu();
                    break;
            }
        }


        public void StatusMenu()
        {
            Console.Clear();
            Console.WriteLine("<<상태창>>");
            Console.WriteLine("용사님의 정보가 표시됩니다.");
            Console.WriteLine("");
            Console.WriteLine($"Lv. {player.Lvl}");
            Console.WriteLine($"직업 : {player.job}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.Write($"공격력 : {player.Attack}"); player.ShowAttackStack();
            Console.Write($"방어력 : {player.Defense}"); player.ShowDefenseStack();
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int route = int.Parse(Console.ReadLine());

            if (route == 0)
            {
                MainMenu();
            }
            else if (route == 8)
            {
                player.EXP();
                Thread.Sleep(500);
                StatusMenu();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                Thread.Sleep(1000);
                StatusMenu();
            }
        }


        public void InventoryMenu()
        {
            Console.Clear();
            Console.WriteLine("<<인벤토리>>");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Player.ShowInventoryItems(false);
            Console.WriteLine("");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int route = int.Parse(Console.ReadLine());

            if (route == 1)
            {
                EquipMenu();
            }
            else if (route == 0)
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                Thread.Sleep(1000);
                InventoryMenu();
            }
        }


        public void EquipMenu()
        {
            Console.Clear();
            Console.WriteLine("<<인벤토리 - 장착 관리>>");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Player.ShowInventoryItems(true);
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int route = int.Parse(Console.ReadLine());


            if (route == 0)
            {
                InventoryMenu();
            }
            else if (route > 0 && route <= Player.InventoryItems.Count)
            {
                Item item = Player.InventoryItems[route - 1];

                if (item.IsEquipped == false)                       //해당 아이템이 장착되어 있지 않다면
                {
                    var sameItemType = Player.InventoryItems.FirstOrDefault(it => it.ItemType == item.ItemType && it.IsEquipped); //'그' 아이템과 타입이 같으며, 장착된 아이템은 sameItemType에 저장됨.

                    if (sameItemType != null)  //해당 아이템이 비어있지 않다면(있다면)
                    {
                        sameItemType.IsEquipped = false;                  //장착 해제
                        player.Attack -= sameItemType.ItemAttack;         //플레이어의 공격력 감소
                        player.Defense -= sameItemType.ItemDefense;       //플레이어의 방어력 감소

                        //item.IsEquipped = true;
                    }
                    //Linq사용법 찾아보기
                    item.IsEquipped = true;                                     //장착 상태로 변경
                    player.Attack += item.ItemAttack;                           //플레이어의 공격력 증가
                    player.Defense += item.ItemDefense;                         //플레이어의 방어력 증가
                    Console.WriteLine($"{item.Name} 장착 완료!");
                }
                else                                                //아이템이 장착되어 있다면
                {
                    item.IsEquipped = false;                                    //장착 해제 상태로 변경
                    player.Attack -= item.ItemAttack;                           //플레이어의 공격력 감소
                    player.Defense -= item.ItemDefense;                         //플레이어의 방어력 감소
                    Console.WriteLine($"{item.Name} 장착 해제 완료!");
                }
                Thread.Sleep(1000);
                EquipMenu();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                Thread.Sleep(1000);
                EquipMenu();
            }
        }


        public void ShopMenu()
        {
            Console.Clear();
            Console.WriteLine("<<상점>>");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("[판매 목록]");
            Shop.ShowShopItems(false);
            Console.WriteLine("");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int route = int.Parse(Console.ReadLine());

            if (route == 1)
            {
                BuyMenu();
            }
            else if (route == 2)
            {
                SellMenu();
            }
            else if (route == 0)
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                Thread.Sleep(1000);
                ShopMenu();
            }
        }

        public void BuyMenu()
        {
            Console.Clear();
            Console.WriteLine("<<상점 - 아이템 구매>>");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Shop.ShowShopItems(true);
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int route = int.Parse(Console.ReadLine());
            switch (route)
            {
                case 0:
                    ShopMenu();
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    //1~7까지의 아이템이 있고
                    Item item = Shop.Items[route - 1]; //아이템 리스트에서 해당 아이템을 가져옴.
                    if (item.IsPlayerItem == true)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.");
                        //Thread.Sleep(1000);
                        //BuyMenu();
                    }
                    //아이템이 이미 구매한 아이템이라면 이미구매한아이템 출력
                    //아니라면 다시 이프문
                    else
                    {
                        if (item.ItemPrice <= player.Gold)
                        {
                            Console.WriteLine("아이템 구매 완료!");
                            player.Gold -= item.ItemPrice; //플레이어의 골드에서 아이템 가격을 뺌.
                            item.IsPlayerItem = true;       //아이템이 플레이어의 아이템으로 변경됨.
                            Player.InventoryItems.Add(item); //인벤토리에 아이템 추가
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");
                            //Thread.Sleep(1000);
                        }
                        //BuyMenu();
                    }
                    Thread.Sleep(1000);
                    BuyMenu();
                    break;
                //보유 금액이 충분하다면 구매
                //아니라면 Gold 부족 출력
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                    Thread.Sleep(1000);
                    BuyMenu();
                    break;
            }
        }

        public void SellMenu()
        {
            Console.Clear();
            Console.WriteLine("<<상점 - 아이템 판매>>");
            Console.WriteLine("필요없는 아이템을 팔 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Shop.ShowShopItems(true);
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int route = int.Parse(Console.ReadLine());
            switch (route)
            {
                case 0:
                    ShopMenu();
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    //1~7까지의 아이템이 있고
                    Item item = Shop.Items[route - 1]; //아이템 리스트에서 해당 아이템을 가져옴.
                    if (item.IsPlayerItem == false)
                    {
                        Console.WriteLine("보유하지 않은 아이템입니다.");
                    }
                    else
                    {
                        Console.WriteLine("아이템 판매 완료!");
                        player.Gold += item.ItemPrice * 85 / 100;  //플레이어의 골드에 아이템 가격85% 더함.
                        item.IsEquipped = false;                  //아이템 장착 해제
                        item.IsPlayerItem = false;       //더이상 플레이어 아이템이 아님.
                        Player.InventoryItems.Remove(item); //인벤토리에 아이템 삭제 근데 혹시 어차피 아이템 삭제하면 윗 두줄 안써도 상관없지않나?
                    }
                    Thread.Sleep(1000);
                    SellMenu();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                    Thread.Sleep(1000);
                    SellMenu();
                    break;
            }
        }

        public void RestMenu()
        {
            Console.Clear();
            Console.WriteLine("<<휴식하기>>");
            Console.WriteLine($"500 G 를 내면 체력을 100으로 회복할 수 있습니다. (보유 골드 : {player.Gold} G)");
            Console.WriteLine("");
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int route = int.Parse(Console.ReadLine());

            if (route == 1)
            {
                if (player.Gold >= 500 && player.Hp < 100)
                {
                    player.Gold -= 500;                       //500골드 차감
                    player.Hp = 100;                          //체력 회복
                    Console.WriteLine("휴식을 완료했습니다.");
                }
                else if (player.Gold >= 500 && player.Hp >= 100)
                {
                    Console.WriteLine("체력이 이미 가득찼습니다.");
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                }
                Thread.Sleep(1000);
                RestMenu();
            }
            else if (route == 0)
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                Thread.Sleep(1000);
                RestMenu();
            }
        }

        static void Main(string[] args)
        {
            GameManager player1 = new GameManager();            //게임 매니저 객체 생성. 일반 메소드는 혼자서 실행 불가능.
            Shop.MakeShopItems();
            player1.MainMenu();                                 //객체 생성 후 메인메뉴 실행.
        }
    }
}
