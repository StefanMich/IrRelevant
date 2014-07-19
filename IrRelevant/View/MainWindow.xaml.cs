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
using IrRelevant.Model;

namespace IrRelevant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Mode> modes;

        public MainWindow()
        {
            InitializeComponent();

            modes = new List<Mode>();
            modes.Add(new Mode("Default"));
            modes.Add(new Mode("TEst"));

            ModeBox.ItemsSource = modes;
            ModeBox.DisplayMemberPath = "Title";
            ModeBox.SelectedIndex = 0;

            ModeBox.SelectionChanged += ModeBox_SelectionChanged;
        }

        void ModeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowMode(getCurrentMode());
        }


        private string insertPicture(string path, int width)
        {
            return "<img src=\"file://" + AppDomain.CurrentDomain.BaseDirectory + path + "\" width=\"" + Width + "px height=\"100px\"\"/>";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getCurrentMode().Items.Add(new Item());
            ShowMode(getCurrentMode());
        }

        private Mode getCurrentMode()
        {
            return modes[ModeBox.SelectedIndex];
        }


        private void ShowMode(Mode mode)
        {
            NotePanel.Children.Clear();
            foreach (Item item in mode.items)
            {
                NotePanel.Children.Add(new ItemControl(item));
            }
        }

    }
}
