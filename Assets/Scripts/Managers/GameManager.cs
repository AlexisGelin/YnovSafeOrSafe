using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    bool runStarted = false;

    private void Awake()
    {
        LoadGame();

        UIManager.Instance.Init();

        LevelGenerator.Instance.Init();

        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.anyKey && runStarted == false)
        {
            StartRunning();
            runStarted = true;
        }

    }

    public void ReloadScene()
    {
        SaveGame();

        SceneManager.LoadScene("MainScene");
    }

    public void StartRunning()
    {
        PlayerData.Instance.CoinInTheRun = 0;

        UIManager.Instance.StartRunning();

        PlayerController.Instance.Init();

        PlayerController.Instance.enabled = true;

    }

    public void GameOver()
    {
        PlayerData.Instance.CheckForHighScore();

        UIManager.Instance.GameOver();

        PlayerController.Instance.enabled = false;

        Time.timeScale = 0;
    }

    public void SaveGame()
    {
        SavingSystem.i.Save("saveSlot1");
    }

    public void LoadGame()
    {
        SavingSystem.i.Load("saveSlot1");
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }
}
