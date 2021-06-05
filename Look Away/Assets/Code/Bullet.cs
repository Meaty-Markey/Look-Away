using UnityEngine;

namespace Code
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 20f;
        public Rigidbody2D rb;
        private const float DeathTimer = 2f;

        private void Start()
        {
            rb.velocity = transform.right * speed;
            Destroy(gameObject, DeathTimer);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag("Enemy")) return;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}