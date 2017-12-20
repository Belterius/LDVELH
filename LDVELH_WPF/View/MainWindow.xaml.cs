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
        private MainWindowViewModel _dataContextViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _dataContextViewModel = (MainWindowViewModel) DataContext;
            _dataContextViewModel.ActionButtonChanged += Vm_ActionButtonChanged;
            GeneratePlayerPossibleDecision(_dataContextViewModel.MyStory);
        }

        private void Vm_ActionButtonChanged(object sender, EventArgs e)
        {
            GeneratePlayerPossibleDecision(_dataContextViewModel.MyStory);
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
            foreach (Event possibleEvent in story.ActualParagraph.GetListDecision)
            {
                if (ShouldGenerateButton(possibleEvent, story))
                {
                    Button buttonDecision = new Button {Content = possibleEvent.TriggerMessage};
                    buttonDecision.Click += delegate {
                        try
                        {
                            possibleEvent.ResolveEvent(story);
                            if (possibleEvent is LootEvent)
                            {
                                //A LootEvent should only be done once, it is handled by the code but it's more user friendly to disable the button once the action is not possible anymore
                                buttonDecision.IsEnabled = !(((LootEvent)possibleEvent).Done);
                            }
                        }
                        catch (YouAreDeadException)
                        {
                            _dataContextViewModel.HandleDeath(story);
                        }
                    };
                    ((Grid)(groupBoxChoices.Content)).Children.Add(buttonDecision);
                    buttonDecision.HorizontalAlignment = HorizontalAlignment.Center;
                    buttonDecision.VerticalAlignment = VerticalAlignment.Center;
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
            if (possibleEvent is ItemRequiredEvent)
            {
                if (!story.PlayerHero.PossesItem(((ItemRequiredEvent)possibleEvent).ItemName))
                {
                    return false;
                }
            }
            return true;
        }
        public double SetXPosition(Button button, GroupBox groupBox)
        {
            double totalX = ((Grid)(groupBox.Content)).ActualWidth;
            double mySize = button.ActualWidth;
            return (totalX - mySize) / 2;
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
