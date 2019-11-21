using SodaSystems.Core;
using SodaSystems.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaSystems.Console
{
    public class SodaMachineConsole
    {
        private SodaMachine sodaMachine = new SodaMachine();

        public SodaMachine GetSodaMachine()
        {
            return sodaMachine;
        }

        public void Start()
        {
            while (true)
            {
                Print("\n\nAvailable commands:");
                Print("insert (money) - Money put into money slot");
                Print("order (coke, sprite, fanta) - Order from machines buttons");
                Print("sms order (coke, sprite, fanta) - Order sent by sms");
                Print("recall - gives money back");
                Print("-------");
                Print("Inserted money: " + sodaMachine.GetMoney());
                Print("-------\n\n");

                string input = System.Console.ReadLine();
                ProcessInput(input);
            }
        }

        public void ProcessInput(string input)
        {
            if (input.StartsWith("insert"))
                ProcessInsert(input);

            else if (input.StartsWith("order"))
                ProcessOrder(input);

            else if (input.StartsWith("sms order"))
                ProcessOrder(input, ignoreCost: true, recallAfter: false);

            else if (input.Equals("recall"))
                ProcessRecall();

            else
                Print($"Unknown command '{input}'");
        }

        private void ProcessInsert(string input)
        {
            string amountStr = input.Split(' ').Last();

            if (amountStr.IsInteger())
            {
                int amount = amountStr.ToInteger();
                sodaMachine.InsertMoney(amountStr.ToInteger());

                Print($"Adding {amount} to credit");
            }
            else
                Print($"Unknown command '{input}', please use the format 'insert (money)'");
        }

        private void ProcessOrder(string input, bool ignoreCost = false, bool recallAfter = true)
        {
            string sodaName = input.Split(' ').Last();

            OrderResult result = sodaMachine.Order(sodaName, 1, ignoreCost);

            if (result == OrderResult.Ok)
            {
                Print("Giving coke out");

                if (recallAfter)
                    ProcessRecall();
            }
            else if (result == OrderResult.NoSodaWithName)
                Print($"No such soda with name '{sodaName}'");
            else if (result == OrderResult.NoSodaLeft)
                Print($"No {sodaName} left");
            else if (result == OrderResult.NeedMoreMoney)
                Print($"Need {20 - sodaMachine.GetMoney()} more");
        }

        private void ProcessRecall()
        {
            int recalledMoney = sodaMachine.RecallMoney();
            Print($"Giving {recalledMoney} out in change");
        }

        private static void Print(string str)
        {
            // ... Can extend with logging functionality

            System.Console.WriteLine(str);
        }
    }
}
