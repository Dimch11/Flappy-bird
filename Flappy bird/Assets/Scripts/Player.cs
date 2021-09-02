using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float flyUpSpeed = 20;

    private Rigidbody2D _rb;
    private InputPanel _inputPanel;

    private Vector2 _flyUpVector;

    [Inject]
    public void Construct(InputPanel inputPanel)
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputPanel = inputPanel;
        _inputPanel.Clicked += FlyUp;

        _flyUpVector = new Vector2(0, flyUpSpeed);
    }
    public void Destruct()
    {
        _inputPanel.Clicked -= FlyUp;
    }

    public void FlyUp()
    {
        _rb.velocity = _flyUpVector;
    }
}
