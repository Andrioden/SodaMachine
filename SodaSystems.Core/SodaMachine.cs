using System;
using System.Linq;

namespace SodaSystems.Core
{
    public class SodaMachine
    {
        private int money = 0;

        private Soda[] inventory = new[]
        {
            new Soda { Name = "coke", Amount = 5 },
            new Soda { Name = "sprite", Amount = 3 },
            new Soda { Name = "fanta", Amount = 3 }
        };

        public int GetMoney()
        {
            return money;
        }

        private Soda GetSoda(string sodaName)
        {
            return inventory
                .Where(i => i.Name.Equals(sodaName, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();
        }

        public bool HasSodaWithName(string sodaName)
        {
            return GetSoda(sodaName) != null;
        }

        public int GetSodaAmount(string sodaName)
        {
            return GetSoda(sodaName).Amount;
        }

        public void InsertMoney(int amount)
        {
            money += amount;
        }

        public OrderResult Order(string sodaName, int amount, bool ignoreCost = false)
        {
            Soda soda = GetSoda(sodaName);

            if (soda == null)
                return OrderResult.NoSodaWithName;
            if (soda.Amount <= 0)
                return OrderResult.NoSodaLeft;
            if (ignoreCost == false && money < 20)
                return OrderResult.NeedMoreMoney;

            // All ok, run order
            if (ignoreCost == false)
                money -= 20;

            soda.Amount--;
            return OrderResult.Ok;
        }

        public int RecallMoney()
        {
            int recalling = money;
            money = 0;
            return recalling;
        }
    }

    public enum OrderResult
    {
        Ok,
        NoSodaWithName,
        NoSodaLeft,
        NeedMoreMoney
    }
}