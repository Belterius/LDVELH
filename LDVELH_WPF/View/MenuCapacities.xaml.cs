using LDVELH_WPF.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for MenuCapacities.xaml
    /// </summary>
    public partial class MenuCapacities : Window
    {
        public MenuCapacities()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int top = 0;
            int bottom = 0;
            int left = 0;
            int right = 0;
            foreach (CapacityType capaType in Enum.GetValues(typeof(CapacityType)))
            {
                CapacityCheckBox myCheckbox = new CapacityCheckBox
                {
                    Name = capaType.ToString(),
                    MyCapacity = capaType,
                    Margin = new Thickness(left, top, right, bottom)
                };
                myCheckbox.Checked += CheckBox_Checked;
                myCheckbox.Unchecked += CheckBox_UnChecked;
                System.Windows.Forms.CheckBox test = new System.Windows.Forms.CheckBox();
                Label label = new Label
                {
                    Content = myCheckbox.MyCapacity.GetTranslation(),
                    ToolTip = GlobalTranslator.Instance.Translator.ProvideValue(
                        "ToolTip" + myCheckbox.MyCapacity.ToString()),
                    Margin = new Thickness(left + 20, top - 5, 0, 0)
                };
                ((Grid)(groupBoxCapacities.Content)).Children.Add(myCheckbox);
                ((Grid)(groupBoxCapacities.Content)).Children.Add(label);
                top += 20;
            }
        }
        private void CheckBox_Checked(object sender, EventArgs e)
        {
            if (((MenuCapacitiesViewModel)DataContext).Hero.Capacities.Count >= ((MenuCapacitiesViewModel)DataContext).Hero.MaxNumberOfCapacities)
            {
                //Ugly Hack.
                //I know that if my Hero already has reached his max number of capacities, I won't be able to add a new one.
                //Problem : I am still ticking the checkbox, for an un-added capacity.
                //Per MVVM View, my RelayCommand cannot send me back if it managed to add the Capacity or not.
                //I cannot either bind my IsChecked property on one of my View Model property as it would break the build each time you create a new Capacity.
                //I am not sure if it is better to keep the Add and Remove Method in the ViewModel and do the hack, or do the Add and Remove Method here without the hack.
                //I decided that I prefer not to do any operation on my Data in the View.

                //Won't add the capacity so we make sure to uncheck the box, the additional call to CheckBox_Unchecked won't matter
                ((CapacityCheckBox)sender).IsChecked = false;
            }
            ((MenuCapacitiesViewModel)DataContext).AddCapacityCommand.Execute(((CapacityCheckBox)sender).MyCapacity);
        }
        private void CheckBox_UnChecked(object sender, EventArgs e)
        {
            ((MenuCapacitiesViewModel)DataContext).RemoveCapacityCommand.Execute(((CapacityCheckBox)sender).MyCapacity);
        }
    }

    public class CapacityCheckBox : CheckBox
    {
        public CapacityType MyCapacity { get; set; }

        public CapacityCheckBox()
        {
        }
    }
}
