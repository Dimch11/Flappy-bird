using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText
{
    private Score _score;
    private ScoreTextBehaviour _scoreTextBehaviour;

    public ScoreText(Score score, ScoreTextBehaviour scoreTextBehaviour)
    {
        _score = score;
        _scoreTextBehaviour = scoreTextBehaviour;

        _score.ScoreChanged += UpdateScoreText;
    }
    public void UpdateScoreText(int score)
    {
        _scoreTextBehaviour.UpdateText(score.ToString());
    }
}
