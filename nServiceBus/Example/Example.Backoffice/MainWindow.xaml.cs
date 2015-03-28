using System;
using System.Windows;
using Example.ServiceBus.Contracts;

namespace Example.Backoffice
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var bus = ServiceBus.Bus;

            bus.Send(
                new CancelOrder {OrderId = Guid.NewGuid()}
            )
           .Register<Status>(status =>
            {
                Box.Text = status.ToString();
            });
        }
    }
}
