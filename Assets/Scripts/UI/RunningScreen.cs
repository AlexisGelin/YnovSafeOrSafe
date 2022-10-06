using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunningScreen : MonoBehaviour
{
    [SerializeField] TMP_Text _coinTxt, _distTxt;
    public void Init()
    {
        UpdateDistText();
        UpdateCoinText();
    }

    public void UpdateDistText()
    {
        _distTxt.text = PlayerData.Instance.Score.ToString();
    }

    public void UpdateCoinText()
    {
        _coinTxt.text = PlayerData.Instance.Coin.ToString();
    }

}
