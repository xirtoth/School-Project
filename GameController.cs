﻿using System;

namespace School_Project
{
    public class GameController
    {
        public static GameController Instance { get; set; }
        public Player player { get; set; }
        public Map map { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Screen screen;
        private bool running = false;

        public GameController()
        {
        }

        public void Init()
        {
            Width = 80;
            Height = 20;
            //All here that needs to be initialized like map, player, screen etc.
            // for example Player player = new Player(blabla);
            // Screen screen = new screen(80,35) (or whatever it is)
            // Map map =new Map(mitä onkaan)
            screen = new Screen(Width, Height);
            map = new Map(Width, Height);
            player = new Player("Pelaaja", 100, 100);
            screen.PrintMap();
            running = true;
        }

        public void Run()
        {
            while (running)
            {
                screen.PrintPlayer();
                

                var input = Console.ReadKey(true);
                CheckInput(input);

                //tähän game looppi.
                //Mikä ikinä onkaan syötteen luku.. esim InputParser() -> täällä voi sit olla, että jos vaikka rightarrow, niin player.move(0,1) ja
                //ja jos käytetään tätä gamecontroller instancee. esim niinkun tossa program.cs on toi kommentoituna pois. niin joka classissa voi sit käyttää sitä
                //kun luo vaan classissa GameController gc = Gamecontroller.Instance. sit pystyy kutsuun gc.player.blabla, gc.screen.blabla, gc.mikälie.blabla.
                //eli voidaan poistaa tosta program.cs noi Screen = screen blabla jne
                //esimerkkinä vaikka jos pitää piirtää pelaaja siihen pisteeseen missä se on. (screen class todennäkösesti). niin voidaan vaan laitta
                //mikälie meidän tulostus funktio onkaan.
                // ja tässä game loopissa voidaan kutsua sit screen.printplayer(); tai jos halutaan yksinkertastaa niin player luokassa voi olla vaikka draw funktio.
                //niin sit voidaan vaan kutsua player.Draw(); ja se sit viitaa screen luokkaan jne.
            }
        }

        private void CheckInput(ConsoleKeyInfo input)
        {
            // Move the player in the corresponding direction
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    player.MovePlayer(0, -1);
                    break;

                case ConsoleKey.DownArrow:
                    player.MovePlayer(0, 1);
                    break;

                case ConsoleKey.LeftArrow:
                    player.MovePlayer(-1, 0);
                    break;

                case ConsoleKey.RightArrow:
                    player.MovePlayer(1, 0);
                    break;
            }
        }
    }
}