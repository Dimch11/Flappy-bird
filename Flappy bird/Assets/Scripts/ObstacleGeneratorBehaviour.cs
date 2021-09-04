using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObstacleGeneratorBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;

    public ObstacleBehaviour InstantiateObstacle()
    {
        return Instantiate(_obstaclePrefab, transform.position, Quaternion.identity, transform)
            .GetComponent<ObstacleBehaviour>();
    }
    public void SetObstacleSpeed(ObstacleBehaviour obstacle, float speed)
    {
        obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0) * Vector2.left;
    }
}
