﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DilemmaDelPrigioniero.Competition
{
    public class Evolution
    {
        private const int NUM_EPOCHS = 1000;
        private const int NUM_CHANGES = 1;
        private Tournament tournament;
        public Evolution()
        {
            tournament = new Tournament();
        }

        public void Evolve()
        {
            for (int i = 0; i < NUM_EPOCHS; i++)
            {
                tournament.Reset();
                tournament.Giostra();
                tournament.Sort();
                breedAndKill();
            }

            tournament.ShowResult();

        }

        private void breedAndKill()
        {
            for (int i = 0; i < NUM_CHANGES; i++)
            {
                tournament.RemoveLast();
            }
            for (int i = 0; i < NUM_CHANGES; i++)
            {
                tournament.CloneAt(i);
            }
        }
    }
}
