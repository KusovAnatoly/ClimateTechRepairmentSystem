using System.Windows;
using System.Windows.Controls;

namespace ClimateTechRepairmentSystem.Views;

public partial class MainWindow : Window
{
    public static Frame ContentFrame { get; set; } = new Frame();

    public MainWindow()
    {
        InitializeComponent();
        ContentFrame = contentFrame;
        ContentFrame.Navigate(new MenuPage());
    }
}