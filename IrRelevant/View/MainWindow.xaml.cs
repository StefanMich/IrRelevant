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

namespace IrRelevant
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


        private string insertPicture(string path, int width)
        {
            return "<img src=\"file://" + AppDomain.CurrentDomain.BaseDirectory + path + "\" width=\"" + Width + "px height=\"100px\"\"/>";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NotePanel.Children.Add(new ItemControl());
        }

    }
}
