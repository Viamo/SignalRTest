using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SignalRTest
{
    public partial class MainWindow : Window
    {
        private int i = 0;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            new Thread(async () =>
            {
                try
                {
                    // Variant 1
                    //new HubConnectionBuilder().WithUrl($"https://localhost:5001/").Build().StartAsync();

                    // Variant 2
                    //new HubConnectionBuilder().WithUrl($"https://localhost:5001/").Build().StartAsync().Wait();

                    // Variant 3
                    await new HubConnectionBuilder().WithUrl($"https://localhost:5001/").Build().StartAsync();
                }
                catch { }
            }).Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            textBlock.Text = i++.ToString();
        }
    }
}
