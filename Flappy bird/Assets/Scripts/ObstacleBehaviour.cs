using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleBehaviour : MonoBehaviour
{
    public event Action collideToPlayer;

    public GameObject obstacleUpPart;
    public GameObject obstacleDownPart;

    public void SetTopPartHeight(float height)
    {
        obstacleUpPart.transform.localPosition = new Vector2(0, height);
    }
    public void SetBottomPartHeight(float height)
    {
        obstacleDownPart.transform.localPosition = new Vector2(0, height);
    }
    public void SetSpeed(float speed)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0) * Vector2.left;
    }
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collideToPlayer.Invoke();
        }
    }
}
