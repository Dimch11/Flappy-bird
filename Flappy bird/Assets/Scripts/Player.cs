using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Player : ITakeDamage
{
    private float _flyUpSpeed;

    [Inject] private PlayerBehaviour _playerBehaviour;
    [Inject] private InputPanel _inputPanel;

    
    [Inject]
    public Player(float flyUpSpeed)
    {
        _flyUpSpeed = flyUpSpeed;

        _inputPanel.Clicked += FlyUp;
    }

    public void FlyUp()
    {
        _playerBehaviour.AddVerticalVelocity(_flyUpSpeed);
    }

    public void TakeDamage()
    {
        _inputPanel.Clicked -= FlyUp;
    }
}
