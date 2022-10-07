using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPart : MonoBehaviour
{
    public Transform EndTransform;
    public List<Collectible> Collectibles;

    public void Init()
    {
        foreach (var collectible in Collectibles)
        {
            collectible.Init();
        }
    }
}
