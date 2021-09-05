using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWindow
{
    private PauseManager _pauseManager;
    private PauseWindowBehaviour _pauseWindowBehaviour;

    public PauseWindow(PauseWindowBehaviour pauseWindowBehaviour, PauseManager pauseManager)
    {
        _pauseManager = pauseManager;
        _pauseWindowBehaviour = pauseWindowBehaviour;

        _pauseWindowBehaviour.resumeButton.onClick.AddListener(Resume);
        _pauseWindowBehaviour.exitToMenuButton.onClick.AddListener(LoadMainScene);
    }

    public void Show()
    {
        _pauseWindowBehaviour.Show();
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(Scenes.MainMenu);
        _pauseManager.Resume();
    }

    private void Resume()
    {
        _pauseManager.Resume();
        _pauseWindowBehaviour.Hide();
    }
}
