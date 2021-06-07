using System.Collections;
using UnityEngine;

namespace Old_Code.Code
{
    public class Aimovement : MonoBehaviour
    {
        private const float Movespeed = 1f;
        public Rigidbody2D rb;
        private readonly float _countdownTimer = 1f;
        private float _currentTime;
        private float _up, _down, _left, _right;

        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            _currentTime = _countdownTimer;

            #region dont look at this bitch

            _left = GameObject.Find("WallLeft").transform.position.x;
            _right = GameObject.Find("WallRight").transform.position.x;
            _up = GameObject.Find("WallUp").transform.position.y;
            _down = GameObject.Find("Floor").transform.position.y;

            #endregion
        }

        public void Update()
        {
            _currentTime += Time.deltaTime;
            if (!(_currentTime >= _countdownTimer)) return;

            StartCoroutine(Move(new Vector3(Random.Range(_left, _right), Random.Range(_down, _up), 0)));
            _currentTime = 0;
        }

        private IEnumerator Move(Vector3 newpos)
        {
            var timeSinceStart = 0f;
            while (true)
            {
                timeSinceStart += Time.deltaTime;
                transform.transform.position = Vector3.Lerp(transform.position, newpos, timeSinceStart / 2 * Movespeed);
                if (transform.position == newpos) yield break;

                yield return null;
            }
        }
    }
}