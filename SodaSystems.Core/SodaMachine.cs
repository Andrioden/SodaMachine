using System;
using System.Collections.Generic;
using System.Linq;

namespace SodaSystems.Core
{
    public class SodaMachine
    {
        public int Money { get; private set; }
        private List<Soda> Inventory { get; set; }

        public SodaMachine(List<Soda> inventory)
        {
            Money = 0;
            Inventory = inventory;
        }

        private Soda GetSoda(string sodaName)
        {
            return Inventory
                .Where(i => i.Name.Equals(sodaName, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();
        }

        public int GetSodaAmount(string sodaName)
        {
            return GetSoda(sodaName).Amount;
        }

        public void InsertMoney(int amount)
        {
            Money += amount;
        }

        public OrderResult Order(string sodaName, int amount, bool ignoreCost = false)
        {
            Soda soda = GetSoda(sodaName);

            if (soda == null)
                return OrderResult.NoSodaWithName;
            if (soda.Amount <= 0)
                return OrderResult.NoSodaLeft;
            if (ignoreCost == false && Money < 20)
                return OrderResult.NeedMoreMoney;

            // All ok, run order
            if (ignoreCost == false)
                Money -= 20;

            soda.Amount--;
            return OrderResult.Ok;
        }

        public int RecallMoney()
        {
            int recalling = Money;
            Money = 0;
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