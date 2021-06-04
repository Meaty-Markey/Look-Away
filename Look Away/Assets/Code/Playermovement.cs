using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;


    private Rigidbody2D _rb;
    private Vector2 moveDirection;

    private SpriteRenderer sr;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var MoveUp = Input.GetAxis("Vertical");
        var MoveLeft = Input.GetAxis("Horizontal");
        moveDirection = new Vector2(MoveUp, MoveLeft).normalized;

        transform.position += new Vector3(MoveLeft, 0, 0) * Time.deltaTime * MovementSpeed;


        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rb.velocity.y) < 0.001f)
        {
            _rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }





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