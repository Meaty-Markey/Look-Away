using UnityEngine;

public class Enamy : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = -transform.right * speed;
    }
}