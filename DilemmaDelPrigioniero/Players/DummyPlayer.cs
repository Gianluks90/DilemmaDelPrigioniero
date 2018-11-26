using System;
using System.Collections.Generic;
using System.Text;

namespace DilemmaDelPrigioniero.Players
{
    public class DummyPlayer : Player   // Implementazione dell'interfaccia " :<nomeInterfaccia> ";
    {
        public int Score { get; private set; }      

        public void AddScore(int score)
        {
            this.Score += score;
        }

        public void ChangeOpponent()
        {

        }

        public int CompareTo(Player other)
        {
            return other.Score-this.Score;
        }

        public Move NextMove()
        {
            return Move.COLLABORATE;    // Notazione di enum: " NomeTipo.NomeEnum ";
        }

        public void ReceiveOpponentMove(Move m)
        {

        }

        public void Reset()
        {
            Score = 0;
        }
    }
}
