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
    /// Interaction logic for ItemControl.xaml
    /// </summary>
    public partial class ItemControl : UserControl
    {
        private bool isExpanded = true;
        private double expandedHeight;
        private Item item;

        public ItemControl()
        {
            InitializeComponent();
            expandedHeight = ContentGrid.Height;
            IconDrawer.MouseUp += IconDrawer_MouseUp;
            textBox.GotFocus += textBox_GotFocus;
            Header.GotFocus += Header_GotFocus;

            Header.TextChanged += Header_TextChanged;
            textBox.TextChanged += textBox_TextChanged;
            IconDrawer.IconChanged += IconDrawer_IconChanged;
        }

        void IconDrawer_IconChanged(IconDrawer id, IconDrawer.IconChangedArgs e)
        {
            if (item != null)
                item.Icon = e.ChangedTo;
        }

        void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (item != null)
                item.Content = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd).Text;
        }

        void Header_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (item != null)
                item.Title = Header.Text;
        }

        void Header_GotFocus(object sender, RoutedEventArgs e)
        {
            IconDrawer.CloseDrawer();
        }

        void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            IconDrawer.CloseDrawer();
        }

        void IconDrawer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Expand();
        }
        private ItemControl(string title, string content, IconEnum icon)
            : this()
        {
            Header.Text = title;
            textBox.Document.Blocks.Clear();
            textBox.Document.Blocks.Add(new Paragraph(new Run(content)));
            IconDrawer.SetIcon(icon);
        }

        public ItemControl(Item item)
            : this(item.Title, item.Content, item.Icon)
        {
            this.item = item;
        }

        private void collapseButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isExpanded)
            {
                Collapse();
            }
            else
            {
                Expand();
            }

        }

        private void Expand()
        {
            isExpanded = true;
            collapseButton.Source = (BitmapImage)Application.Current.Resources["collapse"];

            BackgroundGrid.Height = expandedHeight;
            ContentGrid.Visibility = System.Windows.Visibility.Visible;
            foreach (UIElement item in ContentGrid.Children)
            {
                item.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void Collapse()
        {
            isExpanded = false;
            collapseButton.Source = (BitmapImage)Application.Current.Resources["expand"];

            BackgroundGrid.Height = headerGrid.Height;
            ContentGrid.Visibility = System.Windows.Visibility.Collapsed;
            foreach (UIElement item in ContentGrid.Children)
            {
                item.Visibility = System.Windows.Visibility.Collapsed;
            }
            IconDrawer.CloseDrawer();
        }
    }
}
