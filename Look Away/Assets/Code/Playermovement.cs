using UnityEngine;

public class Playermovement : MonoBehaviour
{

    private Rigidbody2D rb;

    public float moveSpeed;

    private Vector2 moveDirection;

    private SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInputs();
    }
q
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        moveDirection = new UnityEngine.Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        print("It works");
    }

    void Move()
    {
        rb.velocity = new UnityEngine.Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Died");
            Destroy(gameObject);
        }
    }
}