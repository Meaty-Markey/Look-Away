using UnityEngine;

namespace Code
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 20f;
        public Rigidbody2D rb;

        private void Start()
        {
            rb.velocity = transform.right * speed;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
    }
}