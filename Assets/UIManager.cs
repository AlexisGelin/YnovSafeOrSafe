using BaseTemplate.Behaviours;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    // References
    [SerializeField] CanvasGroup GameOverScreen, RunningScreen, MenuScreen, PauseScreen;

    // Cache
    CanvasGroup _actualCanvas;

    public void Init()
    {
        _actualCanvas = MenuScreen;
    }

    public void StartRunning()
    {
        ActiveScreen(RunningScreen);
    }

    public void GameOver()
    {
        ActiveScreen(GameOverScreen);
    }

    public void Pause()
    {
        ActiveScreen(PauseScreen);
    }

    public void ActiveScreen(CanvasGroup GO)
    {
        DesactiveScreen(_actualCanvas);

        GO.DOFade(1, 0.3f);
        GO.interactable = true;
        GO.blocksRaycasts = true;

        _actualCanvas = GO;
    }

    public void DesactiveScreen(CanvasGroup GO)
    {
        GO.DOFade(0,.1f);
        GO.interactable = false;
        GO.blocksRaycasts = false;
    }
}
