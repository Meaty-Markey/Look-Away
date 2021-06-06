using UnityEngine;

namespace Code
{
    public class ParticlesScript : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag("Bullet")) return;
            GetComponent<ParticleSystem>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
