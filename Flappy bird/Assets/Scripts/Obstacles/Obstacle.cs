using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Obstacle
{
    private ObstacleBehaviour _obstacleBehaviour;

    public Obstacle(ObstacleBehaviour obstacleBehaviour, Player player)
    {
        _obstacleBehaviour = obstacleBehaviour;
    }

    public void SetPosition(Vector2 position)
    {
        _obstacleBehaviour.SetPosition(position);
    }
    public void SetPartHeights(float bottomPartHeight, float topPartHeight)
    {
        _obstacleBehaviour.SetBottomPartHeight(bottomPartHeight);
        _obstacleBehaviour.SetTopPartHeight(topPartHeight);
    }
    public void Launch(float speed)
    {
        _obstacleBehaviour.SetSpeed(speed);
    }

    public class Factory : PlaceholderFactory<Obstacle>
    {
    }
}