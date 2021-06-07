using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Old_Code.Code
{
    public class PlayerMovement : MonoBehaviour
    {
        public static float MoveSpeed;

        public Rigidbody2D rb;

        public TMP_Text coin;

        public GameObject go;

        private int _coins;

        private Vector2 _moveDirection;

        private SpriteRenderer _sr;

        private float _time;

        private void Start()
        {
            coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
            _coins = PlayerPrefs.GetInt("TotalCoins");
            rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            MoveSpeed = Kyanshouse.MainPlayer.Movespeed;
            gameObject.GetComponent<SpriteRenderer>().sprite = Kyanshouse.MainPlayer.PlayerSprite;
        }


        private void Update()
        {
            ProcessInputs();

            _time -= Time.deltaTime;

            if (!(_time < 0)) return;

            Instantiate(go);
            go.transform.position = new Vector2(Random.Range(0, 0), Random.Range(0, 0));
            _time = Random.Range(0, 10);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(200, 0, 0);
                Debug.Log("This works");
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-200, 0, 0);
                Debug.Log("This works");
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, 200);
                Debug.Log("This works");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -200);
                Debug.Log("This works");
            }
        }

        private void FixedUpdate()
        {
            Move();
        }


        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                _coins += 1;
                coin.text = $"Coins: {_coins}";
                Destroy(col.gameObject);
            }

            if (col.gameObject.CompareTag("Plant"))
            {
                _coins += 1;
                coin.text = $"Coins: {_coins}";
                Destroy(col.gameObject);
            }

            if (col.gameObject.CompareTag("Enemy"))
            {
                _coins -= 1;
                coin.text = $"Coins: {_coins}";
                Destroy(col.gameObject);
                PlayerPrefs.SetInt("Coin", _coins);
                SceneManager.LoadScene("Menu");
            }

            if (col.gameObject.CompareTag("Finish")) SceneManager.LoadScene("Menu");
        }

        private void ProcessInputs()
        {
            var moveUp = Input.GetAxisRaw("Vertical");
            var moveLeft = Input.GetAxisRaw("Horizontal");
            _moveDirection = new Vector2(moveLeft, moveUp).normalized;

            if (moveLeft > 0)
                _sr.flipX = true;
            else if (moveLeft < 0) _sr.flipX = false;

            if (Input.GetKeyDown(KeyCode.Space) && moveLeft < 0)
                transform.position += new Vector3(-100, 0, 0);
            else if (Input.GetKeyDown(KeyCode.Space) && moveUp > 0) transform.position += new Vector3(100, 0, 0);

            if (Input.GetKeyDown(KeyCode.Space) && moveLeft < 0)
                transform.position += new Vector3(0, 0, -100);
            else if (Input.GetKeyDown(KeyCode.Space) && moveUp > 0) transform.position += new Vector3(0, 0, -100);
        }

        private void Move()
        {
            rb.velocity = new Vector2(_moveDirection.x * MoveSpeed, _moveDirection.y * MoveSpeed);
        }
    }
}