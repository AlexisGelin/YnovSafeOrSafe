using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoSingleton<LevelGenerator>
{
    const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 20f;

    [SerializeField] LevelPart levelpart_Start, levelpart_End;
    [SerializeField] List<LevelPart> lvlParts;

    //Cache
    int countLevelPart = 0;
    LevelPart lastLevelPart;
    Vector3 lastEndPos;

    public void Init()
    {
        SpawnLevelPart(levelpart_Start.EndTransform.position);
    }

    private void Update()
    {
        if (Vector3.Distance(lastEndPos, PlayerController.Instance.transform.position) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            if (countLevelPart <= PlayerData.Instance.NumberOfLevel * 5)
            {
                SpawnLevelPart(lastLevelPart.EndTransform.position);
            }
        }
    }

    void SpawnLevelPart(Vector3 spawnPosition)
    {
        if (countLevelPart == PlayerData.Instance.NumberOfLevel * 5)
        {
            lastLevelPart = Instantiate(levelpart_End, spawnPosition, Quaternion.identity);
        }
        else
        {
            lastLevelPart = Instantiate(lvlParts[Random.Range(0, lvlParts.Count)], spawnPosition, Quaternion.identity);

        }

        lastEndPos = lastLevelPart.EndTransform.position;
        countLevelPart++;
    }
}
