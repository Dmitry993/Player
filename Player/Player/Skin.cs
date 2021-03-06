﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public interface ISkin
    {
        void Clear();
        void Render(string text);
    }

    public class ClassicSkin : ISkin
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Render(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class ColorSkin1 : ISkin
    {
        public ColorSkin1(ConsoleColor color)
        {
            _color = color;
        }

        private ConsoleColor _color { get; }

        public void Clear()
        {
            Console.Clear();
        }

        public void Render(string text)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public class ColorSkin2 : ISkin
    {
        Random random = new Random();

        private ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(random.Next(consoleColors.Length));
        }

        public void Clear()
        {
            Console.Clear();
            for (int i = 0; i < 30; i++)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Write('\u058D');
            }
        }

        public void Render(string text)
        {
            Console.ForegroundColor = GetRandomConsoleColor();
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
