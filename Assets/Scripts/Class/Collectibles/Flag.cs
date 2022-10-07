using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : Collectible
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerData.Instance.playerWin = true;
        PlayerData.Instance.NumberOfLevel++;

        GameManager.Instance.EndGame();
    }
}
