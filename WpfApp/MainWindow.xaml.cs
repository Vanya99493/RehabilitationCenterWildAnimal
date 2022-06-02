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

namespace WpfApp
{
    // За допомогою прогами ведеться облік диких тварин з параметрами догляду за ними: вид харчування (хижаки, травоїдні),
    // належність до виду (ссавці, холоднокровні, комахи); особливості навколишнього середовища (водойма, пустеля, ліс) та,
    // за необхідності, тип лікування.

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Center.DeserializeListOfAnimals();
            LoadPage(new Animals());
        }

        public void AnimalsClick(object sender, RoutedEventArgs e) => LoadPage(new Animals());
        public void RehabilitationClick(object sender, RoutedEventArgs e) => LoadPage(new Rehabilitation());
        public void AddAnimalClick(object sender, RoutedEventArgs e) => LoadPage(new AddAnimal());

        public void LoadPage(Page page)
        {
            MainFrame.Content = page;
            ClearEntryStack();
        }

        private void ClearEntryStack()
        {
            if (!MainFrame.CanGoBack && !MainFrame.CanGoForward)
            {
                return;
            }
            var entry = MainFrame.RemoveBackEntry();
            if (entry != null)
            {
                MainFrame.RemoveBackEntry();
            }
        }
    }
}