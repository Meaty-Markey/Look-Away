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
        }

        private void Update()
        {
            var moveUp = Input.GetAxis("Vertical");
            var moveLeft = Input.GetAxis("Horizontal");
            transform.position += new Vector3(moveLeft, moveUp, 0) * Time.deltaTime * movementSpeed;
        }


         void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Emany")
            {
                Destroy(gameObject);
            }

            if (col.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
            }
            

        }
    }
}