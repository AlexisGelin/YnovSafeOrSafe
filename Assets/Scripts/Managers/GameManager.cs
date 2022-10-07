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
        LevelGenerator.Instance.Init();

        Time.timeScale = 1;
    }

    private void Start()
    {
        LoadGame();

        UIManager.Instance.Init();
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

    public void EndGame()
    {
        PlayerData.Instance.CheckForHighScore();

        UIManager.Instance.EndGame();

        PlayerController.Instance.enabled = false;

        Time.timeScale = 0;
    }

    public void SaveGame()
    {
        SavingSystem.i.Save("saveSlot2");
    }

    public void LoadGame()
    {
        SavingSystem.i.Load("saveSlot2");
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }
}
