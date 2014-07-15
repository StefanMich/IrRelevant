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
    /// Interaction logic for ItemControl2.xaml
    /// </summary>
    public partial class ItemControl : UserControl
    {
        private bool isExpanded = true;
        private double expandedHeight;


        public ItemControl()
        {
            InitializeComponent();
            expandedHeight = ContentGrid.Height;
        }
        public ItemControl(string title, string content, IconPlaceholder icon):this()
        {
            Header.Content = title;
            Icon.Source = getBitmap(icon);
        }

       

        private static BitmapImage getBitmap(IconPlaceholder icon)
        {
            string uri;
            switch (icon)
            {
                case IconPlaceholder.Book:
                    uri = "book";
                    break;
                case IconPlaceholder.Video:
                    uri = "video";
                    break;
                case IconPlaceholder.List:
                    uri = "link";
                    break;
                default:
                    uri = "unknown";
                    break;
            }
            return (BitmapImage)Application.Current.Resources[uri];
        }

        private void collapseButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isExpanded)
            {
                isExpanded = false;
                collapseButton.Source = (BitmapImage)Application.Current.Resources["expand"];

                BackgroundGrid.Height = headerGrid.Height;
                ContentGrid.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                isExpanded = true;
                collapseButton.Source = (BitmapImage)Application.Current.Resources["collapse"];

                BackgroundGrid.Height =expandedHeight;
                ContentGrid.Visibility = System.Windows.Visibility.Visible;
            }

        }
    }
}
