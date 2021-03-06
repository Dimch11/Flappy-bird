using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;

public class PlayerBehaviour : MonoBehaviour
{
    public event Action CollidedToScoreTrigger;


    private Rigidbody2D _rb;

    public void AddVerticalVelocity(float velocity)
    {
        _rb.velocity = new Vector2(0, velocity);
    }
    public void SetGravityScale(float gravityScale)
    {
        _rb.gravityScale = gravityScale;
    }

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Score"))
        {
            CollidedToScoreTrigger?.Invoke();
        }
    }
}
