using UnityEngine;
using UnityEngine.Serialization;

namespace Code
{
    public class Playermovement : MonoBehaviour
    {
        [FormerlySerializedAs("MovementSpeed")] public float movementSpeed = 5;
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.isKinematic = true;
            _rb.useFullKinematicContacts = true;
        }

        private void Update()
        {
            var moveUp = Input.GetAxis("Vertical");
            var moveLeft = Input.GetAxis("Horizontal");
            _rb.velocity = (new Vector2(moveLeft, moveUp) * (Time.deltaTime * movementSpeed));
            
        }


        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }

            if (col.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
            

        }
    }
}