using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LDVELH_WPF.ViewModel.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {
        public MainWindowViewModelTests()
        {
            Hero hero = new Hero("NoName");
            _viewModel = new MainWindowViewModel(hero, false);
        }

        private readonly MainWindowViewModel _viewModel;

        [TestMethod()]
        public void ActionButtonHasChangedTest()
        {
            StoryParagraph paragraph = new StoryParagraph("AParagraph", 100);
            bool didFire = false;
            bool didEnded = false;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual(paragraph, _viewModel.MyStory.ActualParagraph);
            };
            _viewModel.ActionButtonChanged += (object sender, EventArgs e) =>
            {
                didEnded = true;
            };
            _viewModel.MyStory.ActualParagraph = paragraph;
            Assert.IsTrue(didFire);
            Assert.IsTrue(didEnded);
        }

        [TestMethod()]
        public void HeroTest()
        {
            Hero hero = new Hero("NoName");
            bool didFire = false;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual(hero, _viewModel.Hero);
            };
            _viewModel.Hero = hero;
            Assert.IsTrue(didFire);
        }

        [TestMethod()]
        public void UseItemCommandTest()
        {
            Item selectedItem = new Consumable("SelectedItem", 1, 2);
            bool didFire = false;
            bool didChangeCharges = false;

            _viewModel.Hero.AddLoot(selectedItem);
            _viewModel.SelectedItem = selectedItem;
            Assert.IsTrue(_viewModel.Hero.PossesItem(selectedItem.Name));

            selectedItem.PropertyChanged += (s, e) =>
            {
                didFire = true;
                if (e.PropertyName.Equals("ChargesLeft"))
                {
                    didChangeCharges = true;
                }
                Assert.AreEqual(selectedItem, _viewModel.SelectedItem);
            };

            _viewModel.UseItemCommand.Execute(selectedItem);
            Assert.IsTrue((_viewModel.Hero.PossesItem(selectedItem.Name)));
            Assert.IsTrue(didFire);
            Assert.IsTrue(didChangeCharges);
        }

        [TestMethod()]
        public void ThrowLootCommandTest()
        {
            Item selectedItem = new Consumable("SelectedItem", 1, 1);

            _viewModel.Hero.AddLoot(selectedItem);
            Assert.IsTrue(_viewModel.Hero.PossesItem(selectedItem.Name));


            _viewModel.ThrowLootCommand.Execute(selectedItem);
            Assert.IsTrue(!(_viewModel.Hero.PossesItem(selectedItem.Name)));
        }

        [TestMethod()]
        public void SelectedItemTest()
        {
            Item selectedItem = new Consumable("SelectedItem", 1, 1);
            bool didFire = false;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("SelectedItem", e.PropertyName);
                Assert.AreEqual(selectedItem, _viewModel.SelectedItem);
            };
            _viewModel.SelectedItem = selectedItem;
            Assert.IsTrue(didFire);
        }

        [TestMethod()]
        public void SelectedWeaponTest()
        {
            Weapon selectedWeapon = new Weapon("SelectedWeapon", WeaponTypes.Axe);
            bool didFire = false;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("SelectedWeapon", e.PropertyName);
                Assert.AreEqual(selectedWeapon, _viewModel.SelectedWeapon);
            };
            _viewModel.SelectedWeapon = selectedWeapon;
            Assert.IsTrue(didFire);
        }

        [TestMethod()]
        public void MyStoryTest()
        {
            Story myStory = new Story("myTitle", _viewModel.Hero);
            bool didFire = false;
            _viewModel.PropertyChanged += (s, e) =>
            {
                didFire = true;
                Assert.AreEqual("MyStory", e.PropertyName);
                Assert.AreEqual(myStory, _viewModel.MyStory);
            };
            _viewModel.MyStory = myStory;
            Assert.IsTrue(didFire);
        }
    }
}