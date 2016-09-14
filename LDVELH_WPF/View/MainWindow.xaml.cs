using LDVELH_WPF.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            TranslateLabel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm = (MainWindowViewModel) DataContext;
            vm.ActionButtonChanged += Vm_ActionButtonChanged;
            generatePlayerPossibleDecision(vm.MyStory);
        }

        private void Vm_ActionButtonChanged()
        {
            generatePlayerPossibleDecision(vm.MyStory);
        }

        private void TranslateLabel()
        {
            groupBoxHeroStat.Header = GlobalTranslator.Instance.translator.ProvideValue("HeroStats");
            labelDescriptionHitPoint.Content = GlobalTranslator.Instance.translator.ProvideValue("HitPoints");
            labelDescriptionAgility.Content = GlobalTranslator.Instance.translator.ProvideValue("Agility");
            LabelWeaponMastery.Content = GlobalTranslator.Instance.translator.ProvideValue("WeaponMasteryLabel");
            LabelCapacities.Content = GlobalTranslator.Instance.translator.ProvideValue("CapacitiesLabel");
            LabelHunger.Content = GlobalTranslator.Instance.translator.ProvideValue("Hunger");
            groupBoxInventory.Header = GlobalTranslator.Instance.translator.ProvideValue("Inventory");
            LabelBackPack.Content = GlobalTranslator.Instance.translator.ProvideValue("BackPack");
            LabelSpecialItems.Content = GlobalTranslator.Instance.translator.ProvideValue("SpecialItems");
            LabelWeapons.Content = GlobalTranslator.Instance.translator.ProvideValue("Weapon");
            labelDescriptionGold.Content = GlobalTranslator.Instance.translator.ProvideValue("LabelGold");
            buttonThrowItem.Content = GlobalTranslator.Instance.translator.ProvideValue("ThrowItem");
            buttonUseItem.Content = GlobalTranslator.Instance.translator.ProvideValue("UseItem");
            buttonThrowWeapon.Content = GlobalTranslator.Instance.translator.ProvideValue("ThrowWeapon");
            groupBoxChoices.Header = GlobalTranslator.Instance.translator.ProvideValue("Choices");
            buttonSave.Content = GlobalTranslator.Instance.translator.ProvideValue("Save");
            buttonLoad.Content = GlobalTranslator.Instance.translator.ProvideValue("Load");
        }

        /********************************************************/
        //The following function generate View elements, they REQUIRE to be present in the view, as ViewModel should NOT be aware of the View
        private void generatePlayerPossibleDecision(Story story)
        {
            clearOldPossibleDecision();
            generateButtonPossibleDecision(story);
            placeButtonPossibleDecision(groupBoxChoices);
        }
        private void clearOldPossibleDecision()
        {
            ((Grid)(groupBoxChoices.Content)).Children.Clear();
        }
        private void generateButtonPossibleDecision(Story story)
        {
            foreach (Event possibleEvent in story.ActualParagraph.getListDecision)
            {
                if (ShouldGenerateButton(possibleEvent, story))
                {
                    Button buttonDecision = new Button();
                    buttonDecision.Content = possibleEvent.TriggerMessage;
                    buttonDecision.Click += delegate {
                        try
                        {
                            possibleEvent.resolveEvent(story);
                            if (possibleEvent is LootEvent)
                            {
                                //A LootEvent should only be done once, it is handled by the code but it's more user friendly to disable the button once the action is not possible anymore
                                buttonDecision.IsEnabled = !(((LootEvent)possibleEvent).Done);
                            }
                        }
                        catch (YouAreDeadException)
                        {
                            vm.handleDeath(story);
                        }
                    };
                    ((Grid)(groupBoxChoices.Content)).Children.Add(buttonDecision);
                    buttonDecision.HorizontalAlignment = HorizontalAlignment.Center;
                    buttonDecision.VerticalAlignment = VerticalAlignment.Center;
                }
            }
            this.UpdateLayout();
        }
        private bool ShouldGenerateButton(Event possibleEvent, Story story)
        {
            if (possibleEvent is CapacityEvent)
            {
                if (!story.getHero.possesCapacity(((CapacityEvent)possibleEvent).CapacityRequiered))
                {
                    return false;
                }
            }
            if (possibleEvent is ItemRequieredEvent)
            {
                if (!story.getHero.possesItem(((ItemRequieredEvent)possibleEvent).itemRequiered))
                {
                    return false;
                }
            }
            return true;
        }
        public double setXPosition(Button button, GroupBox groupBox)
        {
            double totalX = ((Grid)(groupBox.Content)).ActualWidth;
            double mySize = button.ActualWidth;
            return (totalX - mySize) / 2;
        }
        int marginBetweenButton = 6;
        public double calculateYPosition(double totalHeightButton, int numberButton, GroupBox groupBox)
        {
            double availableY = ((Grid)(groupBox.Content)).ActualHeight;

            return (availableY - totalHeightButton - marginBetweenButton * numberButton - 1) / 2;
        }
        public double totalHeightButton(GroupBox groupBox)
        {
            double totalHeight = 0;
            foreach (Button button in ((Grid)(groupBoxChoices.Content)).Children)
            {
                totalHeight += button.ActualHeight;
            }
            return totalHeight;
        }
        public int totalNumberButton(GroupBox groupBox)
        {
            int totalNumberButton = 0;
            foreach (Button button in ((Grid)(groupBoxChoices.Content)).Children)
            {
                totalNumberButton++;
            }
            return totalNumberButton;
        }
        public void placeButtonPossibleDecision(GroupBox groupBox)
        {
            double topMargin = calculateYPosition(totalHeightButton(groupBox), totalNumberButton(groupBox), groupBox);
            double previousButtonY = topMargin - marginBetweenButton; //we don't need the margin for the first button
            double previousButtonHeight = 0;
            foreach (Button button in ((Grid)(groupBoxChoices.Content)).Children)
            {
                button.Margin = new Thickness(setXPosition(button, groupBox), previousButtonY, setXPosition(button, groupBox), (((Grid)(groupBox.Content)).ActualHeight - button.ActualHeight - previousButtonY));
                previousButtonHeight = button.ActualHeight;
                previousButtonY = (previousButtonY + previousButtonHeight + marginBetweenButton);
            }
        }
    }
}
