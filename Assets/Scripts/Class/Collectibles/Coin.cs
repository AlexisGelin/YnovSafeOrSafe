using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible
{
    public override void Init()
    {
        base.Init();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null) return;

        PlayerData.Instance.AddCoin(1);

        Destroy(gameObject);
    }
}
