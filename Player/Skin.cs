using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public abstract class Skin
    {
        public abstract void Clear();
        public abstract void Render(string text);
    }

    public class ClassicSkin : Skin
    {
        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class ColorSkin1 : Skin
    {
        public ColorSkin1(ConsoleColor color)
        {
            _color = color;
        }

        private ConsoleColor _color { get; }

        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render(string text)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public class ColorSkin2 : Skin
    {
        Random random = new Random();

        private ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(random.Next(consoleColors.Length));
        }

        public override void Clear()
        {
            Console.Clear();
            for (int i = 0; i < 30; i++)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Write('\u058D');
            }
        }

        public override void Render(string text)
        {
            Console.ForegroundColor = GetRandomConsoleColor();
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
