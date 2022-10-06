using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] TMP_Text _coinInTheRunTxt, _hishScoreTxt, _scoreTxt;
    public void Init()
    {
        _coinInTheRunTxt.text = "Piece recoltee : " + PlayerData.Instance.CoinInTheRun.ToString();
        _scoreTxt.text = "Distance : " + PlayerData.Instance.Score + "m";
        _hishScoreTxt.text = "Distance max : " + PlayerData.Instance.HighScore + "m";
    }
}
