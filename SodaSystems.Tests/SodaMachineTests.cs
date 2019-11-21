using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodaSystems.Core;

namespace SodaSystems.Tests
{
    [TestClass]
    public class SpeedRoute
    {
        [TestMethod]
        public void UT_SodaMachine_ProcessInput_insert()
        {
            SodaMachine sodaMachine = new SodaMachine();

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
            SodaMachine sodaMachine = new SodaMachine();

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
            SodaMachine sodaMachine = new SodaMachine();

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
            SodaMachine sodaMachine = new SodaMachine();

            sodaMachine.ProcessInput("insert 1");
            Assert.AreEqual(1, sodaMachine.GetMoney());

            sodaMachine.ProcessInput("recall");
            Assert.AreEqual(0, sodaMachine.GetMoney());
        }
    }
}
