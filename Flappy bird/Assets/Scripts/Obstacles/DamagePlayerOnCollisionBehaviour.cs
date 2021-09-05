using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DamagePlayerOnCollisionBehaviour : MonoBehaviour
{
    private Player _player;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _player.TakeDamage();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _player.TakeDamage();
        }
    }
}
