using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; 
    
    private void FixedUpdate()
    {
        transform.position = target.position+offset; 
    }
}
