using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Player
{
    public event Action Damaged;

    private Settings _settings;
    private PlayerBehaviour _playerBehaviour;
    private InputPanel _inputPanel;

    public Player(PlayerBehaviour playerBehaviour, InputPanel inputPanel, Settings settings)
    {
        _settings = settings;
        _playerBehaviour = playerBehaviour;
        _inputPanel = inputPanel;
        
        _inputPanel.Clicked += FlyUp;
        _inputPanel.Clicked += TurnOnGravity;
    }

    public void FlyUp()
    {
        _playerBehaviour.AddVerticalVelocity(_settings.flyUpSpeed);
    }
    public void TurnOnGravity()
    {
        _playerBehaviour.SetGravityScale(_settings.gravityScale);
        _inputPanel.Clicked -= TurnOnGravity;
    }
    public void TakeDamage()
    {
        _inputPanel.Clicked -= FlyUp;
        Damaged?.Invoke();
    }


    [Serializable]
    public class Settings
    {
        public float flyUpSpeed;
        public float gravityScale;
    }
}
