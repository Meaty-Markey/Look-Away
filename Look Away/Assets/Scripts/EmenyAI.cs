using UnityEngine;

public class EmenyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Vector2 _movement;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        var direction = player.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
        direction.Normalize();
        _movement = direction;
    }

    private void FixedUpdate()
    {
        MoveCharacter(_movement);
    }

    private void MoveCharacter(Vector2 direction)
    {
        _rb.MovePosition((Vector2) transform.position + direction * (moveSpeed * Time.deltaTime));
    }
}