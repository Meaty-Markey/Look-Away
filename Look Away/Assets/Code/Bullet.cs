using UnityEngine;
using TMPro;


    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D rb;

       

        private void Start()
        {
           
        }

    void Update()
    {
     
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
