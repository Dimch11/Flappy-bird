using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public event Action<int> ScoreChanged;

    public int CurScore
    {
        get => _curScore;
        private set
        {
            _curScore = value;
            ScoreChanged?.Invoke(_curScore);
        }
    }

    private int _curScore;
    private const string _bestScoreNameInPlayerPrefs = "bestScore";
    private const int _scoreForPassingObstacle = 1;
    private Player _player;

    public Score(Player player)
    {
        _player = player;

        _player.Damaged += UpdateBestScore;
    }

    public void AddScoreForPassingThroughObstacle()
    {
        CurScore += _scoreForPassingObstacle;
    }
    public void UpdateBestScore()
    {
        if (CurScore > GetBestScore())
        {
            SetScore(CurScore);
        }
    }
    private void SetScore(int score)
    {
        PlayerPrefs.SetInt(_bestScoreNameInPlayerPrefs, score);
    }
    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(_bestScoreNameInPlayerPrefs);
    }
}
