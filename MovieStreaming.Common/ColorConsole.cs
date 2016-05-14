﻿using System;

namespace MovieStreaming.Common
{
    public static class ColorConsole
    {
        public static void WriteLineGreen(string message)
        {
            var beforeColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColor;
        }

        public static void WriteWhite(string message)
        {
            var beforeColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColor;
        }

        public static void WriteLineYellow(string message)
        {
            var beforeColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColor;
        }

        public static void WriteMagenta(string message)
        {
            var beforeColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColor;
        }

        public static void WriteLineGray(string message)
        {
            var beforeColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColor;
        }

        public static void WriteLineRed(string message)
        {
            var beforeColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColor;
        }

        public static void WriteLineCyan(string message)
        {
            var beforeColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColor;
        }
    }
}
