using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodaSystems.Console;
using SodaSystems.Core;

namespace SodaSystems.Tests
{
    [TestClass]
    public class SodaMachineConsoleTests
    {
        [DataTestMethod]
        [DataRow(1, 0,   1)]
        [DataRow(1, 1,   2)]
        [DataRow(1, 4,   5)]
        [DataRow(1, -1,   0)]
        public void UT_SodaMachineConsole_ProcessInput_insert(int firstInsert, int secondInsert, int expMoney)
        {
            SodaMachineConsole console = BasicSodaMachineConsole();

            console.ProcessInput($"insert {firstInsert}");
            console.ProcessInput($"insert {secondInsert}");
            Assert.AreEqual(expMoney, console.Money);
        }

        [TestMethod]
        public void UT_SodaMachineConsole_ProcessInput_order()
        {
            SodaMachineConsole console = BasicSodaMachineConsole();

            Assert.AreEqual(5, console.GetSoda("coke").Units);

            console.ProcessInput("insert 20");
            console.ProcessInput("order coke");
            Assert.AreEqual(4, console.GetSoda("coke").Units);

            console.ProcessInput("order coke");
            Assert.AreEqual(4, console.GetSoda("coke").Units);
        }

        [TestMethod]
        public void UT_SodaMachineConsole_ProcessInput_sms_order()
        {
            SodaMachineConsole console = BasicSodaMachineConsole();

            Assert.AreEqual(5, console.GetSoda("coke").Units);

            console.ProcessInput("sms order coke");
            Assert.AreEqual(4, console.GetSoda("coke").Units);

            console.ProcessInput("sms order coke");
            console.ProcessInput("sms order coke");
            console.ProcessInput("sms order coke");
            console.ProcessInput("sms order coke");
            Assert.AreEqual(0, console.GetSoda("coke").Units);

            console.ProcessInput("sms order coke");
            Assert.AreEqual(0, console.GetSoda("coke").Units);
        }

        [TestMethod]
        public void UT_SodaMachineConsole_ProcessInput_recall()
        {
            SodaMachineConsole console = BasicSodaMachineConsole();

            console.ProcessInput("insert 1");
            Assert.AreEqual(1, console.Money);

            console.ProcessInput("recall");
            Assert.AreEqual(0, console.Money);
        }

        private SodaMachineConsole BasicSodaMachineConsole()
        {
            return new SodaMachineConsole(new List<Soda>
            {
                new Soda { Name = "coke", Units = 5, UnitCost = 20 },
                new Soda { Name = "sprite", Units = 3, UnitCost = 20 },
                new Soda { Name = "fanta", Units = 3, UnitCost = 20 }
            });
        }
    }
}
