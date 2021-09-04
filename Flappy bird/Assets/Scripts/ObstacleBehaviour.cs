using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public GameObject obstacleUpPart;
    public GameObject obstacleDownPart;

    public void SetUpPartHeight(float height)
    {
        obstacleUpPart.transform.localPosition = new Vector2(0, height);
    }
    public void SetDownPartHeight(float height)
    {
        obstacleDownPart.transform.localPosition = new Vector2(0, height);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
