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
using WpfApp.Data;
using WpfApp.Classes;

namespace WpfApp
{
    public partial class AddAnimal : Page
    {
        public AddAnimal()
        {
            InitializeComponent();

            FillKindComboBox("Mammal", "Coldblooded", "Insect");
            FillComboBox(HabitatComboBox, typeof(TypeOfHabitat));
            FillComboBox(FoodComboBox, typeof(TypeOfFood));
            FillComboBox(TherapyComboBox, typeof(TypeOfTherapy));
        }

        private void FillKindComboBox(params string[] items)
        {
            foreach (var item in items)
                KindComboBox.Items.Add(item);
            KindComboBox.SelectedIndex = 0;
        }
        private void FillComboBox(ComboBox comboBox, Type enumType)
        {
            var elementsFromEnum = Enum.GetNames(enumType);
            foreach (var item in elementsFromEnum)
                comboBox.Items.Add(item);
            comboBox.SelectedIndex = 0;
        }

        public void AddAnimalClick(object sender, RoutedEventArgs e)
        {
            if (NameValue.Text == "")
                return;

            switch (KindComboBox.SelectedIndex)
            {
                case 0:
                    Center.AddAnimal(new Mammal(
                        NameValue.Text, 
                        (TypeOfFood)Enum.Parse(typeof(TypeOfFood), FoodComboBox.SelectedItem.ToString()), 
                        (TypeOfHabitat)Enum.Parse(typeof(TypeOfHabitat), HabitatComboBox.SelectedItem.ToString()),
                        (TypeOfTherapy)Enum.Parse(typeof(TypeOfTherapy), TherapyComboBox.SelectedItem.ToString())
                    ));
                    break;
                case 1:
                    Center.AddAnimal(new ColdBlooded(
                        NameValue.Text,
                        (TypeOfFood)Enum.Parse(typeof(TypeOfFood), FoodComboBox.SelectedItem.ToString()),
                        (TypeOfHabitat)Enum.Parse(typeof(TypeOfHabitat), HabitatComboBox.SelectedItem.ToString()),
                        (TypeOfTherapy)Enum.Parse(typeof(TypeOfTherapy), TherapyComboBox.SelectedItem.ToString())
                    ));
                    break;
                case 2:
                    Center.AddAnimal(new Insect(
                        NameValue.Text,
                        (TypeOfFood)Enum.Parse(typeof(TypeOfFood), FoodComboBox.SelectedItem.ToString()),
                        (TypeOfHabitat)Enum.Parse(typeof(TypeOfHabitat), HabitatComboBox.SelectedItem.ToString()),
                        (TypeOfTherapy)Enum.Parse(typeof(TypeOfTherapy), TherapyComboBox.SelectedItem.ToString())
                    ));
                    break;
                default:
                    break;
            }
            Center.SerializeListOfAnimals();
            NameValue.Text = "";
        }
    }
}