namespace GalacticQuest
{
    public class Player
    {
        public int Hp { get; private set; } = 100;
        public int Attack { get; private set; } = 10;
        public List<(string, int)> Items { get; private set; } = new List<(string, int)>();
        public int Credits { get; private set; } = 10;

        public Player(int hp, int attack, List<(string, int)> items,int credits)
        {
            Hp = hp;
            Attack = attack;
            Items = items;
            Credits = credits;
        }

        public Player(int hp, int attack, List<(string, int)> items)
     : this(hp, attack, items, 10) 
        {
            
        }

        public Player(int hp, int attack)
        {
            Hp = hp;
            Attack = attack;
        }

        public Player(int hp)
        {
            Hp = hp;
        }

        public Player()
        {
        }

        public void UpdateHp(int hp)
        {
            Hp += hp;

            if (Hp <= 0)
            {
                Hp = 0;
                OnDeath();
                return;
            }
        }

        public bool UpdateCredits(int credits)
        {
            if (Credits + credits < 0)
            {
                return false;
            }
            Credits += credits;
            return true;
        }

        public void AddItem((string, int) item)
        {
            Items.Add(item);
        }

        public bool RemoveItem(string name)
        {
            int indexToRemove = Items.FindIndex(item => item.Item1.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (indexToRemove >= 0)
            {
                Items.RemoveAt(indexToRemove);
                Console.WriteLine($"Item removed: {name}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Error: Item '{name}' was not found in the inventory.");
                return false;
            }
        }

        public void OnDeath()
        {
            Console.WriteLine("Player has died. Game Over.");
        }

        public void ShowProfile()
        {
            Console.WriteLine("Displaying Player Profile:");

            Console.WriteLine($"Player HP: {Hp}");
            Console.Write("\n");

            Console.WriteLine("Player Items: ");
            for (int index = 0; index < Items.Count; ++index)
            {
                Console.WriteLine($"Item -> Name: {Items[index].Item1}" + " | " + $"Attack: {Items[index].Item2}");
            }
            Console.Write("\n");

            Console.WriteLine($"Player Attack: {Attack}");
            int playerTotalAttack = Attack;
            for (int index = 0; index < Items.Count; ++index)
            {
                string itemName = Items[index].Item1;
                int itemAttack = Items[index].Item2;

                playerTotalAttack += itemAttack;
            }
            Console.WriteLine($"Player Attack (Combined With Items Attack): {playerTotalAttack}");
            Console.Write("\n");
        }
    }
}