using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoName.Utilities;
using System;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField]
    private int currentCoin;


    public int CurrentCoin => currentCoin;

    public event Action CoinChanged;

    public void UseCoins(int amount)
    {
        currentCoin -= amount;
        CoinChanged?.Invoke();
    }

    public bool HasEnoughCoins(int amount)
    {
        return (currentCoin >= amount);
    }

}
