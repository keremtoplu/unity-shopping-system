using System.Collections;
using System.Collections.Generic;
using NoName.Utilities;
using UnityEngine;
using TMPro;

public class Game : Singleton<Game>
{
    public int Coins;
    //propa dönüşecek
    [SerializeField]
    private TextMeshProUGUI currentCoinText;

    //uı gidecek

    private void Start()
    {
        currentCoinText.text = Coins.ToString();
    }
    //scoremanagera gidecek
    public void UseCoins(int amount)
    {
        Coins -= amount;
        currentCoinText.text = Coins.ToString();
    }

    public bool HasEnoughCoins(int amount)
    {
        return (Coins >= amount);
    }
    //scoremanagera taşınacak.
}
