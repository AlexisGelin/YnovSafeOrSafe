using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectibleType { Coin }

public class Collectible : MonoBehaviour
{
    [SerializeField] CollectibleType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null) return;

        switch (type)
        {
            case CollectibleType.Coin:
                PlayerData.Instance.AddCoin(1);
                break;
        }

        Destroy(gameObject);
    }
}
