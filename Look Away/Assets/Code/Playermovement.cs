using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement; 

namespace Code
{
    public class Playermovement : MonoBehaviour
    {
        [FormerlySerializedAs("MovementSpeed")] public float movementSpeed = 5;
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;

        private void Start()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
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
                SceneManager.LoadScene("Main Menu");

            }

            if (col.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
            

        }
    }
}