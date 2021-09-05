using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButtonBehaviour : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(Scenes.Gameplay));
    }
}
