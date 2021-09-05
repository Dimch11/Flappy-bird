using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindowBehaviour : MonoBehaviour
{
    public Button exitToMenuButton;
    public Text currentScoreText;
    public Text bestScoreText;

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void SetCurrentScoreText(string text)
    {
        currentScoreText.text = text;
    }
    public void SetBestScoreText(string text)
    {
        bestScoreText.text = text;
    }
}
