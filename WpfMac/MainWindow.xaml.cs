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

using System.Net.NetworkInformation;

namespace WpfMac
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

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            foreach (string sMac in GetMyMacAddress())
                listBox1.Items.Add(sMac);
        }

        private static List<string> GetMyMacAddress()
        {
            List<String> slistMac = new List<string>();

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                PhysicalAddress address = nic.GetPhysicalAddress();
                if ((NetworkInterfaceType.Tunnel != nic.NetworkInterfaceType)
                     && !String.IsNullOrEmpty(address.ToString()))
                {
                    string sMac = string.Join(":", (from z in nic.GetPhysicalAddress()
                         .GetAddressBytes()
                                                    select z.ToString("X2")).ToArray());
                    slistMac.Add(String.Format("{0}\t {1}", sMac, nic.Description));

                }
            }
            return slistMac;
        }
        private string ListBoxSelectedItem()
        {
            return listBox1.SelectedItem.ToString();
        }
    }
}
