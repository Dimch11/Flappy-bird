using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWindow
{
    private GameOverWindowBehaviour _gameOverWindowBehaviour;
    private PauseManager _pauseManager;
    private AsyncProcessor _asyncProcessor;
    private Score _score;

    private const float _delayBeforeShow = 2f;
    private const string _currentScoreText = "Âàø ñ÷¸ò: ";
    private const string _bestScoreText = "Ëó÷øèé ñ÷¸ò: ";

    public GameOverWindow(GameOverWindowBehaviour gameOverWindowBehaviour, PauseManager pauseManager, 
        Player player, AsyncProcessor asyncProcessor, Score score)
    {
        _gameOverWindowBehaviour = gameOverWindowBehaviour;
        _pauseManager = pauseManager;
        _asyncProcessor = asyncProcessor;
        _score = score;

        _gameOverWindowBehaviour.exitToMenuButton.onClick.AddListener(LoadMainScene);
        player.Damaged += () => _asyncProcessor.StartCoroutine(PauseGameAndShowWindowWithDelay());
    }

    public IEnumerator PauseGameAndShowWindowWithDelay()
    {
        yield return new WaitForSeconds(_delayBeforeShow);

        _pauseManager.Pause();
        Show();
    }
    public void Show()
    {
        _gameOverWindowBehaviour.Show();
        _gameOverWindowBehaviour.SetCurrentScoreText(_currentScoreText + _score.CurScore.ToString());
        _gameOverWindowBehaviour.SetBestScoreText(_bestScoreText + _score.GetBestScore());
    }
    private void LoadMainScene()
    {
        _pauseManager.Resume();
        SceneManager.LoadScene(Scenes.MainMenu);
    }
}
