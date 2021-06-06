using UnityEngine;

namespace Code
{
    public class Bullet : MonoBehaviour
    {
        private const float Time = 1.5f;
        private void Start()
        {
            Destroy(gameObject, Time);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag("Enemy")) return;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
