using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace NewtonCalculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		//function to enable the clear button
		public void EnableClearButton()
		{
			ClearButton.IsEnabled = true;
		}

		//function to disable the clear button
		public void DisableClearButton()
		{
			ClearButton.IsEnabled = false;
		}

		//function to enable the convert button
		public void EnableConvertButton()
		{
			ConvertButton.IsEnabled = true;
		}

		//function to disable the convert button
		public void DisableConvertButton()
		{
			ConvertButton.IsEnabled = false;
		}

		//This is the code for the convert button. 
		private void ConvertButton_Click(object sender, RoutedEventArgs e)
		{
			DisableConvertButton();
			double mass = Convert.ToDouble(test_mass_textbox.Text);
			double weight = mass * 9.8;

			//We don't want values to be over 1000 newtons
			if (weight > 1000)
			{
				WeightCalcTextbox.Text = "The object is too heavy";
			}

			//We don't want values to be less than 10 newtons
			else if (weight < 10)
			{
				WeightCalcTextbox.Text = "The object is too light";
			}

			//Anything between 10 and 1000 newtons will calculate normally
			else
			{
				WeightCalcTextbox.Text = Convert.ToString(weight);
			}
		}

		

		//After the clear button is clicked, the clear button and convert button
			//will no longer be enabled. And the Mass and Weight Text boxes will be cleared
		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			WeightCalcTextbox.Text = "";
			test_mass_textbox.Text = "";

			DisableClearButton();
			DisableConvertButton();
		}

		//When the user enters a number into the mass textbox, the clear button and convert
			//button will become enabled. This box only accepts keys 0-9 and one decimal point
		private void test_mass_textbox_previewtextinput(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
			e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert
				((sender as TextBox).SelectionStart, e.Text));

			EnableClearButton();
			EnableConvertButton();

		}
	}
}
