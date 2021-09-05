using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreTextBehaviour : MonoBehaviour
{
    private Text _scoreText;

    public void UpdateText(string scoreText)
    {
        if (_scoreText == null)
        {
            _scoreText = GetComponent<Text>();
        }

        _scoreText.text = scoreText;
    }
}
