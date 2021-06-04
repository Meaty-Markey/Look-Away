 using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public float dash = 0;

    SpriteRenderer sr; 

    private Rigidbody2D _rb;
    private Vector2 moveDirection; 

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var MoveUp = Input.GetAxis("Vertical");
        var MoveLeft = Input.GetAxis("Horizontal");
        moveDirection = new UnityEngine.Vector2(MoveUp, MoveLeft).normalized;

        transform.position += new Vector3(MoveLeft, 0, 0) * Time.deltaTime * MovementSpeed;

  

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rb.velocity.y) < 0.001f)
        {
            _rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            dash = 1;
        }

        else if (Input.GetKeyDown(KeyCode.W) && dash > 0)
        {
            transform.position += new Vector3(5, 0, 0);
            dash = 0;
        }

        else if (Input.GetKeyDown(KeyCode.S) && dash > 0)
        {
            transform.position += new Vector3(-5, 0, 0);
            dash = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
       //if (col.gameObject.tag == "Emany") ;
       //{
         // Destroy(gameObject);
       //}

    }
} 

