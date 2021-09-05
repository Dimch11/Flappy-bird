using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreTriggerBehaviour : MonoBehaviour
{
    private Score _score;

    [Inject]
    public void Construct(Score score)
    {
        _score = score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _score.AddScoreForPassingThroughObstacle();
        }
    }
}
