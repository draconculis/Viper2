using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Viper2
{
    public class Game
    {
        ViperConsole Viper;
        public Game(ViperConsole console)
        {
            Viper = console;
        }

        #region The Game ---------------------------------------------------

        public void Initialize()
        {
            Viper.Write("Hej ", Colors.Green);
            Viper.Write("och ");
            Viper.Write("hå, ", Colors.Blue, Colors.Cyan);
            Viper.Write("Lallalaaaa", Colors.Yellow);
            Viper.WriteLine();
        }

        public void DoStuff()
        {
            string input = Viper.Input;

            Viper.WriteLine(input);
        }

        #endregion The Game ------------------------------------------------
    }
}
