using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace SodaMachine.Tests
{
    [TestClass]
    public class SodaMachineTests
    {
        [TestMethod]
        public void UT_SodaMachine_ProcessInput_insert()
        {
            ConsoleApplication1.SodaMachine sodaMachine = new ConsoleApplication1.SodaMachine();

            Assert.AreEqual(0, sodaMachine.GetMoney());

            sodaMachine.ProcessInput("insert 0");
            Assert.AreEqual(0, sodaMachine.GetMoney());

            sodaMachine.ProcessInput("insert 1");
            Assert.AreEqual(1, sodaMachine.GetMoney());

            sodaMachine.ProcessInput("insert 4");
            Assert.AreEqual(5, sodaMachine.GetMoney());

            sodaMachine.ProcessInput("insert -1");
            Assert.AreEqual(4, sodaMachine.GetMoney());

            sodaMachine.ProcessInput("insert -5");
            Assert.AreEqual(-1, sodaMachine.GetMoney());
        }

        [TestMethod]
        public void UT_SodaMachine_ProcessInput_order()
        {
            ConsoleApplication1.SodaMachine sodaMachine = new ConsoleApplication1.SodaMachine();

            Assert.AreEqual(5, sodaMachine.GetInventoryNr("coke"));

            sodaMachine.ProcessInput("insert 20");
            sodaMachine.ProcessInput("order coke");
            Assert.AreEqual(4, sodaMachine.GetInventoryNr("coke"));

            sodaMachine.ProcessInput("order coke");
            Assert.AreEqual(4, sodaMachine.GetInventoryNr("coke"));
        }

        [TestMethod]
        public void UT_SodaMachine_ProcessInput_sms_order()
        {
            ConsoleApplication1.SodaMachine sodaMachine = new ConsoleApplication1.SodaMachine();

            Assert.AreEqual(5, sodaMachine.GetInventoryNr("coke"));

            sodaMachine.ProcessInput("sms order coke");
            Assert.AreEqual(4, sodaMachine.GetInventoryNr("coke"));

            sodaMachine.ProcessInput("sms order coke");
            sodaMachine.ProcessInput("sms order coke");
            sodaMachine.ProcessInput("sms order coke");
            sodaMachine.ProcessInput("sms order coke");
            Assert.AreEqual(0, sodaMachine.GetInventoryNr("coke"));

            sodaMachine.ProcessInput("sms order coke");
            Assert.AreEqual(0, sodaMachine.GetInventoryNr("coke"));
        }

        [TestMethod]
        public void UT_SodaMachine_ProcessInput_recall()
        {
            ConsoleApplication1.SodaMachine sodaMachine = new ConsoleApplication1.SodaMachine();

            sodaMachine.ProcessInput("insert 1");
            Assert.AreEqual(1, sodaMachine.GetMoney());

            sodaMachine.ProcessInput("recall");
            Assert.AreEqual(0, sodaMachine.GetMoney());
        }
    }
}
