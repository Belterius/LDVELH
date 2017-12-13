using LDVELH_WPF.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            UpdateLayout();
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
            return ((Grid) (groupBoxChoices.Content)).Children.Cast<Button>().Sum(button => button.ActualHeight);
        }
        public int TotalNumberButton(GroupBox groupBox)
        {
            return ((Grid) (groupBoxChoices.Content)).Children.Cast<Button>().Count();
        }
        public void PlaceButtonPossibleDecision(GroupBox groupBox)
        {
            double topMargin = CalculateYPosition(TotalHeightButton(groupBox), TotalNumberButton(groupBox), groupBox);
            double previousButtonY = topMargin - MarginBetweenButton; //we don't need the margin for the first button
            foreach (Button button in ((Grid)(groupBoxChoices.Content)).Children)
            {
                button.Margin = new Thickness(SetXPosition(button, groupBox), previousButtonY, SetXPosition(button, groupBox), (((Grid)(groupBox.Content)).ActualHeight - button.ActualHeight - previousButtonY));
                double previousButtonHeight = button.ActualHeight;
                previousButtonY = (previousButtonY + previousButtonHeight + MarginBetweenButton);
            }
        }
    }
}
