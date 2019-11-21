using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodaSystems.Console;

namespace SodaSystems.Tests
{
    [TestClass]
    public class SodaMachineConsoleTests
    {
        [TestMethod]
        public void UT_SodaMachineConsole_ProcessInput_insert()
        {
            SodaMachineConsole console = new SodaMachineConsole();

            Assert.AreEqual(0, console.GetSodaMachine().GetMoney());

            console.ProcessInput("insert 0");
            Assert.AreEqual(0, console.GetSodaMachine().GetMoney());

            console.ProcessInput("insert 1");
            Assert.AreEqual(1, console.GetSodaMachine().GetMoney());

            console.ProcessInput("insert 4");
            Assert.AreEqual(5, console.GetSodaMachine().GetMoney());

            console.ProcessInput("insert -1");
            Assert.AreEqual(4, console.GetSodaMachine().GetMoney());

            console.ProcessInput("insert -5");
            Assert.AreEqual(-1, console.GetSodaMachine().GetMoney());
        }

        [TestMethod]
        public void UT_SodaMachineConsole_ProcessInput_order()
        {
            SodaMachineConsole console = new SodaMachineConsole();

            Assert.AreEqual(5, console.GetSodaMachine().GetSodaAmount("coke"));

            console.ProcessInput("insert 20");
            console.ProcessInput("order coke");
            Assert.AreEqual(4, console.GetSodaMachine().GetSodaAmount("coke"));

            console.ProcessInput("order coke");
            Assert.AreEqual(4, console.GetSodaMachine().GetSodaAmount("coke"));
        }

        [TestMethod]
        public void UT_SodaMachineConsole_ProcessInput_sms_order()
        {
            SodaMachineConsole console = new SodaMachineConsole();

            Assert.AreEqual(5, console.GetSodaMachine().GetSodaAmount("coke"));

            console.ProcessInput("sms order coke");
            Assert.AreEqual(4, console.GetSodaMachine().GetSodaAmount("coke"));

            console.ProcessInput("sms order coke");
            console.ProcessInput("sms order coke");
            console.ProcessInput("sms order coke");
            console.ProcessInput("sms order coke");
            Assert.AreEqual(0, console.GetSodaMachine().GetSodaAmount("coke"));

            console.ProcessInput("sms order coke");
            Assert.AreEqual(0, console.GetSodaMachine().GetSodaAmount("coke"));
        }

        [TestMethod]
        public void UT_SodaMachineConsole_ProcessInput_recall()
        {
            SodaMachineConsole console = new SodaMachineConsole();

            console.ProcessInput("insert 1");
            Assert.AreEqual(1, console.GetSodaMachine().GetMoney());

            console.ProcessInput("recall");
            Assert.AreEqual(0, console.GetSodaMachine().GetMoney());
        }
    }
}
