using UnityEngine;
using TMPro;


    public class Bullet : MonoBehaviour
    {
      
        public Rigidbody2D rb;

        public float time; 

        private void Start()
        {
        time = 5;
        }

    void Update()
    {
        time -= Time.deltaTime; 

        if (time < 0)
        {
            Destroy(gameObject);
            time = Random.Range(0, 5); 
        }
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
