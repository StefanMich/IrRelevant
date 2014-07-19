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
    public enum IconEnum { book, link, video, unknown };
    /// <summary>
    /// Interaction logic for IconDrawer.xaml
    /// </summary>
    public partial class IconDrawer : UserControl
    {
        
        private IconEnum currentIcon;
        private bool drawerOpen = false;
        
        public IconDrawer()
        {
            InitializeComponent();
            //Icon.Source = GetSource(IconEnum.unknown);
            currentIcon = IconEnum.unknown;

            Stackpanel.Visibility = System.Windows.Visibility.Collapsed;

            
        }
        
        private void Icon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ToggleOpen();
        }

        public void ToggleOpen()
        {
            if (!drawerOpen)
            {
                OpenDrawer();

            }
            else
            {
                CloseDrawer();
            }

        }

        public void CloseDrawer()
        {
            Stackpanel.Visibility = System.Windows.Visibility.Collapsed;
            drawerOpen = false;
        }

        public void OpenDrawer()
        {
            Stackpanel.Visibility = System.Windows.Visibility.Visible;
            fillPanel(currentIcon);
            drawerOpen = true;
        }

        private void img_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CloseDrawer();
            Icon.Source = GetSource((sender as IconImage).IconEnum);
        }

        public void SetIcon (IconEnum icon)
        {
            currentIcon = icon;
            Icon.Source = GetSource(icon);
        }


        private IEnumerable<IconEnum> GetIcons(IconEnum exception)
        {

            foreach (IconEnum item in Enum.GetValues(typeof(IconEnum)))
            {
                if (item != exception)
                    yield return item;
            }
        }

        private BitmapImage GetSource(IconEnum icon)
        {
            string s = icon.ToString();
            return (BitmapImage)Application.Current.Resources[icon.ToString()];
        }

        private void fillPanel(IconEnum exception)
        {
            Stackpanel.Children.Clear();
            foreach (var item in GetIcons(exception))
            {
                IconImage img = new IconImage();
                img.Source = GetSource(item);
                img.MouseUp += img_MouseUp;
                img.IconEnum = item;
                Stackpanel.Children.Add(img);
            }
        }

    }
}
