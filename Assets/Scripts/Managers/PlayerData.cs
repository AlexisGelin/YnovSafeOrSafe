using BaseTemplate.Behaviours;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoSingleton<PlayerData>, ISavable
{
    [SerializeField] int score, highScore, coin, coinInTheRun;
    public int Score { get => score; set => score = value; }
    public int HighScore { get => highScore; }
    public int Coin { get => coin; }
    public int CoinInTheRun { get => coinInTheRun; set => coinInTheRun = value; }

    public void AddCoin(int amount)
    {
        coin += amount;
        coinInTheRun += amount;

        UIManager.Instance.RunningScreen.UpdateCoinText();
    }



    public void CheckForHighScore()
    {
        if (score >= highScore)
        {
            highScore = score;
        }
    }

    public object CaptureState()
    {
        var saveData = new PlayerSaveData()
        {
            Coin = coin,
            HighScore = highScore

        };

        return saveData;
    }

    public void RestoreState(object state)
    {
        var saveData = (PlayerSaveData)state;

        highScore = saveData.HighScore;
        coin = saveData.Coin;
    }
}

[Serializable]
public class PlayerSaveData
{
    public int HighScore, Coin;
}