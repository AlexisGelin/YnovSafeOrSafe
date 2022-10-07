using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] TMP_Text _titleTxt, _coinInTheRunTxt, _hishScoreTxt, _scoreTxt;
    string _title;

    public void Init()
    {
        _title = PlayerData.Instance.playerWin ? "VICTOIRE" : "DEFAITE";
        _titleTxt.text = _title;
        _coinInTheRunTxt.text = "Piece recoltee : " + PlayerData.Instance.CoinInTheRun.ToString();
        _scoreTxt.text = "Distance : " + PlayerData.Instance.Score + "m";
        _hishScoreTxt.text = "Distance max : " + PlayerData.Instance.HighScore + "m";
    }
}
