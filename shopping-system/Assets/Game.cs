using System.Collections;
using System.Collections.Generic;
using NoName.Utilities;
using UnityEngine;

public class Game : Singleton<Game>
{
    public int Coins;
    //propa dönüşecek

    public void UseCoins(int amount)
    {
        Coins -= amount;
    }

    public bool HasEnoughCoins(int amount)
    {
        return (Coins >= amount);
    }
    //scoremanagera taşınacak.
}
