using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.Init();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StartRunning()
    {
        UIManager.Instance.StartRunning();

        PlayerController.Instance.Init();

        PlayerController.Instance.enabled = true;

    }
}
