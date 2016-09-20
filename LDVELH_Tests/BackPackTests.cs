﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LDVELH_WPF;

namespace LDVELH_Tests
{
    [TestClass]
    public class BackPackTests
    {

        [TestMethod]
        public void BackPack_AddOnEmpty()
        {
            Consummable consummable = CreateLoot.CreateConsummable.minorHealthPotion();
            BackPack basicBackPack = new BackPack();

            basicBackPack.AddItem(consummable);

            Assert.AreEqual(true, basicBackPack.GetItems.Contains(consummable));

        }

        [TestMethod]
        public void BackPack_AddOnNonEmpty_Tests()
        {
            Consummable consummable = CreateLoot.CreateConsummable.minorHealthPotion();
            Consummable consummable2 = new Consummable("Random Consumable", 12, 1);
            Consummable consummable4 = new Consummable("Random Consumable", 12, 1);//Allow to check if the override Equal works on Contains()
            Consummable consummable3 = new Consummable("Random Consumable FALSE", 12, 1);
            BackPack basicBackPack = new BackPack();

            basicBackPack.AddItem(consummable);
            basicBackPack.AddItem(consummable2);

            Assert.AreEqual(true, basicBackPack.GetItems.Contains(consummable));
            Assert.AreEqual(true, basicBackPack.GetItems.Contains(consummable4));
            Assert.AreEqual(false, basicBackPack.GetItems.Contains(consummable3));

        }

        [TestMethod]
        public void BackPack_AddOnFull_Tests()
        {
            Consummable consummable = CreateLoot.CreateConsummable.minorHealthPotion();
            Consummable consummable2 = new Consummable("Random Consumable one", 12, 1);
            Consummable consummable3 = new Consummable("Random Consumable two", 12, 1);
            Consummable consummable4 = new Consummable("Random Consumable three", 12, 1);
            BackPack smallBackPack = new BackPack(3);

            smallBackPack.AddItem(consummable);
            smallBackPack.AddItem(consummable2);
            smallBackPack.AddItem(consummable3);

            try
            {
                smallBackPack.AddItem(consummable4);
                Assert.Fail();//we should have thrown an exception and gone in the catch
            }
            catch (BackPackFullException)
            {
                Assert.AreEqual(true, smallBackPack.GetItems.Contains(consummable));
                Assert.AreEqual(true, smallBackPack.GetItems.Contains(consummable2));
                Assert.AreEqual(true, smallBackPack.GetItems.Contains(consummable3));
            }

        }

        [TestMethod]
        public void BackPack_RemoveOnNonEmpty_Tests()
        {
            Consummable consummable = CreateLoot.CreateConsummable.minorHealthPotion();
            Consummable consummable2 = new Consummable("Random Consumable", 12, 1);
            Consummable consummable3 = new Consummable("Random Consumable FALSE", 12, 1);
            BackPack basicBackPack = new BackPack();
            basicBackPack.AddItem(consummable);
            basicBackPack.AddItem(consummable2);

            Assert.AreEqual(true, basicBackPack.GetItems.Contains(consummable));
            Assert.AreEqual(true, basicBackPack.GetItems.Contains(consummable2));

            basicBackPack.RemoveItem(consummable2);

            Assert.AreEqual(true, basicBackPack.GetItems.Contains(consummable));
            Assert.AreEqual(false, basicBackPack.GetItems.Contains(consummable2));

        }

        [TestMethod]
        public void BackPack_RemoveOnEmpty_Tests()
        {
            Consummable consummable = CreateLoot.CreateConsummable.minorHealthPotion();
            BackPack basicBackPack = new BackPack();

            basicBackPack.RemoveItem(consummable);

            Assert.AreEqual(false, basicBackPack.GetItems.Contains(consummable));

        }

        [TestMethod]
        public void BackPack_AddDifferentKindItem_Tests()
        {
            Consummable consummable = CreateLoot.CreateConsummable.minorHealthPotion();
            Food food = new Food("Meal", 1);
            BackPack basicBackPack = new BackPack();

            basicBackPack.AddItem(consummable);
            basicBackPack.AddItem(food);

            Assert.AreEqual(true, basicBackPack.GetItems.Contains(consummable));
            Assert.AreEqual(true, basicBackPack.GetItems.Contains(food));

        }

    }
}
