using BaseTemplate.Behaviours;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    // References
    [SerializeField] CanvasGroup GameOverScreenCG, RunningScreenCG, MenuScreenCG, PauseScreenCG;

    public MenuScreen MenuScreen;
    public RunningScreen RunningScreen;
    public GameOverScreen GameOverScreen;
    public PauseScreen PauseScreen;

    // Cache
    CanvasGroup _actualCanvas;


    public void Init()
    {
        MenuScreen.Init();
        _actualCanvas = MenuScreenCG;
    }

    public void StartRunning()
    {
        RunningScreen.Init();
        ActiveScreen(RunningScreenCG);
    }


    public void Pause()
    {
        PauseScreen.Init();
        ActiveScreen(PauseScreenCG, true,false);
        Time.timeScale = 0;
    }

    public void QuitPause()
    {
        ActiveScreen(RunningScreenCG, true);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        GameOverScreen.Init();
        ActiveScreen(GameOverScreenCG, true);
    }

    public void ActiveScreen(CanvasGroup GO, bool instant = false,bool desactiveLastCanvas = true)
    {
        if (instant) GO.DOFade(1, 0);
        else GO.DOFade(1, 0.3f);

        if (desactiveLastCanvas) DesactiveScreen(_actualCanvas, instant);

        GO.interactable = true;
        GO.blocksRaycasts = true;

        _actualCanvas = GO;
    }

    public void DesactiveScreen(CanvasGroup GO, bool instant)
    {
        if (instant) GO.DOFade(0, 0);
        else GO.DOFade(0, 0.1f);
        GO.interactable = false;
        GO.blocksRaycasts = false;
    }
}
