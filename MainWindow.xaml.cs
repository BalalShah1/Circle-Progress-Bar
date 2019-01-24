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
using System.Management;
using System.Diagnostics;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PerformanceCounter perfCPU = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        System.Windows.Threading.DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0,0,0,1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            rpbCPU.Value = (int) perfCPU.NextValue();
            lblCPUPercent.Text = "CPU : " + " " + rpbCPU.Value.ToString() + " " + "%";
        }

        private void RpbCPU_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
