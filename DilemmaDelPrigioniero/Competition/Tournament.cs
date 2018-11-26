﻿using DilemmaDelPrigioniero.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace DilemmaDelPrigioniero.Competition
{
    public class Tournament
    {
        public const int NUM_CLONES = 3;                      // Notazione, le costanti si scrivono tutte maiuscole con underscore tra le parole (es. NOME_COSTANTE);
        public const int NUM_MATCHES = 100;
        public const int BOTH_COOPERATE_SCORE = 50;
        public const int BOTH_DEFECT_SCORE = 30;
        public const int ONLY_ONE_COOPERATE_SCORE = 0;
        public const int ONLY_ONE_DEFECT_SCORE = 110;

        private Random dice;

        private List<Player> players = new List<Player>();    // Lista, sequenza di oggetti. In questo caso List<Player> indica una lista di elementi "Player";

        public Tournament()
        {
            dice = new Random();
            for (int i = 0; i < NUM_CLONES; i++)
            {
                players.Add(new DummyPlayer());               // " NomeLista.Add " permette di inserire un elemento alla fine della lista;
                players.Add(new BastardInside());
            }

            for (int  j = 0;  j <players.Count;  j++)
            {
                int x = dice.Next(players.Count);
                int y = dice.Next(players.Count);

                var temp = players[x];
                players[x] = players[y];
                players[y] = temp;
            }
        }

        public void Giostra()
        {
            for (int i = 0; i < players.Count - 1; i++)
            {
                for (int j = i + 1; j < players.Count; j++)
                {
                    Giostra(players[i], players[j]);          // Overload del metodo Giostra. Si distingue per la presenza di parametri;
                }
            }
        }

        private void Giostra(Player p1, Player p2)
        {
            p1.ChangeOpponent();
            p2.ChangeOpponent();
            for (int i = 0; i < NUM_MATCHES; i++)
            {
                Move m1 = p1.NextMove();
                Move m2 = p2.NextMove();
                p1.ReceiveOpponentMove(m2);
                p2.ReceiveOpponentMove(m1);

                if(m1==Move.COLLABORATE && m2==Move.COLLABORATE)
                {
                    p1.AddScore(BOTH_COOPERATE_SCORE);
                    p2.AddScore(BOTH_COOPERATE_SCORE);
                }
                else if(m1 == Move.COLLABORATE && m2 == Move.DEFECT)
                {
                    p1.AddScore(ONLY_ONE_COOPERATE_SCORE);
                    p2.AddScore(ONLY_ONE_DEFECT_SCORE);
                }
                else if(m1 == Move.DEFECT && m2 == Move.COLLABORATE)
                {
                    p1.AddScore(ONLY_ONE_DEFECT_SCORE);
                    p2.AddScore(ONLY_ONE_COOPERATE_SCORE);
                }
                else if(m1 == Move.DEFECT && m2 == Move.DEFECT)
                {
                    p1.AddScore(BOTH_DEFECT_SCORE);
                    p2.AddScore(BOTH_DEFECT_SCORE);
                }
            }
        }

        public void ShowResult()
        {
            foreach(var item in players)
            {
                Console.WriteLine($"{item.GetType().Name}: {item.Score}");
            }
        }

        public void Sort()
        {
            players.Sort(new PlayerComparer());
        }
    }
}
