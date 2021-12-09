using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Viper2
{
    public class ViperConsole
    {
        public TextBlock Block { get; set; }
        public TextBox Box { get; set; }
        public string Input {
            get => Box.Text;
            set => Box.Text = value;
        }
        public Color TextColor { get; set; } = Colors.White;
        public Color TextBackgroundColor { get; set; } = Colors.Transparent;

        public double FontSize
        {
            get => Block.FontSize;
            set
            {
                Box.FontSize = value < 1 ? 1 : value;
                Block.FontSize = value < 1 ? 1 : value;
            }
        }

        public ViperConsole(TextBlock textblock, TextBox textbox)
        {
            Block = textblock;
            Box = textbox;

            Block.PreviewMouseWheel += PreviewMouseWheel;
            Box.PreviewMouseWheel += PreviewMouseWheel;

            Clear();

            Box.Focus();
        }

        private void PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl))
                return;

            if (e.Delta > 0)
                FontSize++;

            else if (e.Delta < 0)
                FontSize--;
        }

        public void Clear()
        {
            Block.Text = "";
            Box.Text = "";
        }

        public void SetBackgroundColor(Color color)
        {
            Brush brush = new SolidColorBrush(color);

            Block.Background = brush;
            Box.Background = brush;
        }

        public void SetInputTextColor(Color color)
        {
            Brush brush = new SolidColorBrush(color);
            Box.Foreground = brush;
        }

        internal void ClearBox()
        {
            Input = "";
        }

        internal void WriteLine(string text = "")
        {
            WriteLine(text, TextColor, TextBackgroundColor);
        }

        internal void WriteLine(string text, Color color)
        {
            WriteLine(text, color, TextBackgroundColor);
        }

        internal void WriteLine(string text, Color color, Color background)
        {
            Write(text + Environment.NewLine, color, background);
        }

        internal void Write(string text)
        {
            Write(text, TextColor, TextBackgroundColor);
        }

        internal void Write(string text, Color color)
        {
            Write(text, color, TextBackgroundColor);
        }

        internal void Write(string text, Color color, Color background)
        {
            Brush brush = new SolidColorBrush(color);
            Brush back = new SolidColorBrush(background);
            Block.Inlines.Add(new Run(text)
            {
                Foreground = brush,
                Background = back,
            });

            ((ScrollViewer)Block.Parent).ScrollToBottom();
        }
    }
}
