using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enamy : MonoBehaviour
{
    public float speed = 5f; 
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity =-transform.right * speed;
    }
}
