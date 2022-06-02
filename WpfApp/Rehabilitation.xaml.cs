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
using WpfApp.Classes;
using WpfApp.Data;

namespace WpfApp
{
    public partial class Rehabilitation : Page
    {
        private List<Couple<int, Animal>> _animalsForHeal = new List<Couple<int, Animal>>();
        private List<Couple<int, Animal>> _animalsForRemove = new List<Couple<int, Animal>>();

        public Rehabilitation()
        {
            InitializeComponent();
            ReloadListsAndComboBoxes();
        }

        private void ReloadListsAndComboBoxes()
        {
            _animalsForHeal.Clear();
            _animalsForRemove.Clear();
            HealComboBox.Items.Clear();
            RemoveComboBox.Items.Clear();
            FillListsAndComboBoxes();
        }
        private void FillListsAndComboBoxes()
        {
            int index = 0;
            foreach (var item in Center.Animals)
            {
                if (item.TypeOfTherapy == 0)
                    _animalsForRemove.Add(new Couple<int, Animal>(index++, item));
                else
                    _animalsForHeal.Add(new Couple<int, Animal>(index++, item));
            }
            foreach (var item in _animalsForHeal)
            {
                HealComboBox.Items.Add(item.Value.ToLongString());
            }
            foreach (var item in _animalsForRemove)
            {
                RemoveComboBox.Items.Add(item.Value.ToShortString());
            }
        }

        public void HealAnimalClick(object sender, RoutedEventArgs e)
        {
            if (HealComboBox.Items.Count == 0 || HealComboBox.SelectedIndex == -1)
                return;

            MessageBox.Show(Center.HealAnimalAndGetInfo(_animalsForHeal[HealComboBox.SelectedIndex].Key));
            CleanListsAndSerialize();
        }
        public void RemoveAnimalClick(object sender, RoutedEventArgs e)
        {
            if (RemoveComboBox.Items.Count == 0 || RemoveComboBox.SelectedIndex == -1)
                return;

            Center.RemoveAnimal(_animalsForRemove[RemoveComboBox.SelectedIndex].Key);
            CleanListsAndSerialize();
        }

        private void CleanListsAndSerialize()
        {
            ReloadListsAndComboBoxes();
            Center.SerializeListOfAnimals();
        }
    }
}