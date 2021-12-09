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

namespace Viper2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViperConsole Viper;
        private Game theGame;

        public MainWindow()
        {
            InitializeComponent();

            Viper = new ViperConsole(textblock_console, textb_input);
            
            Viper.SetBackgroundColor(Colors.Black);
            Viper.SetInputTextColor(Colors.White);
            Viper.TextColor = Colors.White;

            theGame = new Game(Viper);
        }

        private void textb_input_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                theGame.DoStuff();
                Viper.ClearBox();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            theGame.Initialize();
        }
    }
}
