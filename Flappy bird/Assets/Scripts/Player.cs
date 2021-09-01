using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;

    public void Construct()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void FlyUp()
    {
        
    }
}
