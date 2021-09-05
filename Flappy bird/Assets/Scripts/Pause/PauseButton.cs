using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseButton
{
    public PauseButton(Button button, PauseManager pauseManager, PauseWindow pauseWindow)
    {
        button.onClick.AddListener(pauseManager.Pause);
        button.onClick.AddListener(pauseWindow.Show);
    }
}
