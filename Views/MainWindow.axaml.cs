using System;
using Avalonia.Controls;
using Carbon.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace Carbon.Views;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        DataContext = new MainViewModel();

        WeakReferenceMessenger.Default.Register<WindowManager> (this, (r, m) => {
            Type windowType = m.Value;
            if (Activator.CreateInstance(windowType) is Window newWindow)
            {
                newWindow.Show();
            }
        });
    }
}