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
        _pauseWindowBehaviour.exitToMenuButton.onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(Scenes.MainMenu);
    }

    private void Resume()
    {
        _pauseManager.Resume();
        _pauseWindowBehaviour.Hide();
    }
}
