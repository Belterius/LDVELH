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
        MainWindowViewModel DataContextViewModel;

        public MainWindow()
        {
            InitializeComponent();
            TranslateLabel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContextViewModel = (MainWindowViewModel) DataContext;
            DataContextViewModel.ActionButtonChanged += Vm_ActionButtonChanged;
            GeneratePlayerPossibleDecision(DataContextViewModel.MyStory);
        }

        private void Vm_ActionButtonChanged(object sender, EventArgs e)
        {
            GeneratePlayerPossibleDecision(DataContextViewModel.MyStory);
        }

        private void TranslateLabel()
        {
            //groupBoxHeroStat.Header = GlobalTranslator.Instance.Translator.ProvideValue("HeroStats");
            //labelDescriptionHitPoint.Content = GlobalTranslator.Instance.Translator.ProvideValue("HitPoints");
            labelDescriptionAgility.Content = GlobalTranslator.Instance.Translator.ProvideValue("Agility");
            LabelWeaponMastery.Content = GlobalTranslator.Instance.Translator.ProvideValue("WeaponMasteryLabel");
            LabelCapacities.Content = GlobalTranslator.Instance.Translator.ProvideValue("CapacitiesLabel");
            LabelHunger.Content = GlobalTranslator.Instance.Translator.ProvideValue("Hunger");
            groupBoxInventory.Header = GlobalTranslator.Instance.Translator.ProvideValue("Inventory");
            LabelBackPack.Content = GlobalTranslator.Instance.Translator.ProvideValue("BackPack");
            LabelSpecialItems.Content = GlobalTranslator.Instance.Translator.ProvideValue("SpecialItems");
            LabelWeapons.Content = GlobalTranslator.Instance.Translator.ProvideValue("Weapon");
            labelDescriptionGold.Content = GlobalTranslator.Instance.Translator.ProvideValue("LabelGold");
            buttonThrowItem.Content = GlobalTranslator.Instance.Translator.ProvideValue("ThrowItem");
            buttonUseItem.Content = GlobalTranslator.Instance.Translator.ProvideValue("UseItem");
            buttonThrowWeapon.Content = GlobalTranslator.Instance.Translator.ProvideValue("ThrowWeapon");
            groupBoxChoices.Header = GlobalTranslator.Instance.Translator.ProvideValue("Choices");
            buttonSave.Content = GlobalTranslator.Instance.Translator.ProvideValue("Save");
            buttonLoad.Content = GlobalTranslator.Instance.Translator.ProvideValue("Load");
        }

        /********************************************************/
        //The following functions generate View elements, they REQUIRE to be present in the view, as ViewModel should NOT be aware of the View
        private void GeneratePlayerPossibleDecision(Story story)
        {
            ClearOldPossibleDecision();
            GenerateButtonPossibleDecision(story);
            PlaceButtonPossibleDecision(groupBoxChoices);
        }
        private void ClearOldPossibleDecision()
        {
            ((Grid)(groupBoxChoices.Content)).Children.Clear();
        }
        private void GenerateButtonPossibleDecision(Story story)
        {
            foreach (Event PossibleEvent in story.ActualParagraph.GetListDecision)
            {
                if (ShouldGenerateButton(PossibleEvent, story))
                {
                    Button ButtonDecision = new Button();
                    ButtonDecision.Content = PossibleEvent.TriggerMessage;
                    ButtonDecision.Click += delegate {
                        try
                        {
                            PossibleEvent.ResolveEvent(story);
                            if (PossibleEvent is LootEvent)
                            {
                                //A LootEvent should only be done once, it is handled by the code but it's more user friendly to disable the button once the action is not possible anymore
                                ButtonDecision.IsEnabled = !(((LootEvent)PossibleEvent).Done);
                            }
                        }
                        catch (YouAreDeadException)
                        {
                            DataContextViewModel.HandleDeath(story);
                        }
                    };
                    ((Grid)(groupBoxChoices.Content)).Children.Add(ButtonDecision);
                    ButtonDecision.HorizontalAlignment = HorizontalAlignment.Center;
                    ButtonDecision.VerticalAlignment = VerticalAlignment.Center;
                }
            }
            this.UpdateLayout();
        }
        private bool ShouldGenerateButton(Event possibleEvent, Story story)
        {
            if (possibleEvent is CapacityEvent)
            {
                if (!story.PlayerHero.PossesCapacity(((CapacityEvent)possibleEvent).CapacityRequiered))
                {
                    return false;
                }
            }
            if (possibleEvent is ItemRequieredEvent)
            {
                if (!story.PlayerHero.PossesItem(((ItemRequieredEvent)possibleEvent).ItemName))
                {
                    return false;
                }
            }
            return true;
        }
        public double SetXPosition(Button button, GroupBox groupBox)
        {
            double TotalX = ((Grid)(groupBox.Content)).ActualWidth;
            double MySize = button.ActualWidth;
            return (TotalX - MySize) / 2;
        }
        int MarginBetweenButton = 6;
        public double CalculateYPosition(double totalHeightButton, int numberButton, GroupBox groupBox)
        {
            double availableY = ((Grid)(groupBox.Content)).ActualHeight;

            return (availableY - totalHeightButton - MarginBetweenButton * numberButton - 1) / 2;
        }
        public double TotalHeightButton(GroupBox groupBox)
        {
            double TotalHeight = 0;
            foreach (Button Button in ((Grid)(groupBoxChoices.Content)).Children)
            {
                TotalHeight += Button.ActualHeight;
            }
            return TotalHeight;
        }
        public int TotalNumberButton(GroupBox groupBox)
        {
            int TotalNumberButton = 0;
            foreach (Button Button in ((Grid)(groupBoxChoices.Content)).Children)
            {
                TotalNumberButton++;
            }
            return TotalNumberButton;
        }
        public void PlaceButtonPossibleDecision(GroupBox groupBox)
        {
            double TopMargin = CalculateYPosition(TotalHeightButton(groupBox), TotalNumberButton(groupBox), groupBox);
            double PreviousButtonY = TopMargin - MarginBetweenButton; //we don't need the margin for the first button
            double PreviousButtonHeight = 0;
            foreach (Button Button in ((Grid)(groupBoxChoices.Content)).Children)
            {
                Button.Margin = new Thickness(SetXPosition(Button, groupBox), PreviousButtonY, SetXPosition(Button, groupBox), (((Grid)(groupBox.Content)).ActualHeight - Button.ActualHeight - PreviousButtonY));
                PreviousButtonHeight = Button.ActualHeight;
                PreviousButtonY = (PreviousButtonY + PreviousButtonHeight + MarginBetweenButton);
            }
        }
    }
}
