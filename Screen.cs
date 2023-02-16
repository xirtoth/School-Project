﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace School_Project
{
    public class Screen
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private GameController gc = GameController.Instance;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public Screen(int width, int height)
        {
            Width = width;
            Height = height;
            IntPtr consoleWindow = GetConsoleWindow();
            if (consoleWindow != IntPtr.Zero)
            {
                //tää maximoi konsolin (en tiä toimiiko visual studio code konsolissa). suosittelen vahvasti visual studioo, tai sit ku buildaa, ni menee siihen kansioon ja käyttää exe filee
                ShowWindow(consoleWindow, 3);
            }
            Console.WindowHeight = Height;
            Console.WindowWidth = Width;
            Console.SetBufferSize(width, height);
        }

        public void PrintPlayer()
        {
            // tää ei tuu toimiin, ennenkun pelaajalla on position value, public Position pos {get; set;} ja asetettu jossain (todnäk player constructorissa)
            // Console.SetCursorPosition(gc.Player.Pos.x, gc.Player.Pos.y);
            Write("@");
        }

        public void Write(string text, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.Write(text);
            Console.ResetColor();
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void DrawScreen()
        {
            //tähän tulee vielä kaikki mapin piirtämiset, entityt, pelaaja jne. kunhan ne ny on eka valmiina.
        }
    }
}