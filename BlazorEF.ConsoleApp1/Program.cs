﻿namespace BlazorEF.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            foreach (string arg in args)
            {
                Console.WriteLine($"arg={arg}");
            }

            Console.ReadKey();
        }
    }
}