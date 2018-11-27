using System;
using System.Collections.Generic;
using System.Text;

namespace DilemmaDelPrigioniero.Players
{
    public enum Move
    {                           // Convenzione sulle { } : prima e ultima graffa su righe separate;
        COLLABORATE, DEFECT     // Definisco un nuovo tipo Move (enum) e automaticamente associo 0 al primo e 1 al secondo;
    }
    public interface Player : IComparable<Player>    // Tendenzialmente si utilizza mettere una "i" di fronte al nome di una interfaccia (es. iPlayer), non è raro trovarlo;
    {
        int Score { get; }                           // Tutto ciò che si trova in un'interfaccia è "public" quindi non serve indicarlo;
        Move NextMove();
        void ReceiveOpponentMove(Move m);            // Pascal Case, la prima lettera di ogni parola và maiuscola (uso: Classi, Namespace, Funzioni e Proprietà);
        void AddScore(int score);                    // Camel Case, la prima lettera minuscola e maiuscola la prima lettera di ogni parola successiva (Variabili);
        void ChangeOpponent();
        void Reset();
    }
}
