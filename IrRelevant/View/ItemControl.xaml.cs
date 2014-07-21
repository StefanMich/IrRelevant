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
        private Item currentitem;

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
            if (currentitem != null)
                currentitem.Icon = e.ChangedTo;
        }

        void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentitem != null)
                currentitem.Content = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd).Text;
        }

        void Header_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentitem != null)
                currentitem.Title = Header.Text;
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
        private ItemControl(string title, string content, IconEnum icon, bool expanded)
            : this()
        {
            Header.Text = title;
            textBox.Document.Blocks.Clear();
            textBox.Document.Blocks.Add(new Paragraph(new Run(content)));
            IconDrawer.SetIcon(icon);

            if (!expanded)
                Collapse();
        }

        public ItemControl(Item item)
            : this(item.Title, item.Content, item.Icon, item.Expanded)
        {
            this.currentitem = item;
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

            if (currentitem != null)
                currentitem.Expanded = true;
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

            if (currentitem != null)
                currentitem.Expanded = false;
        }
    }
}
