using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] TMP_Text _coinTxt;
    public void Init()
    {
        _coinTxt.text = PlayerData.Instance.Coin.ToString();
    }
}
