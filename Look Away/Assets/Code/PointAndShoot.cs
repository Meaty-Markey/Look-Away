using UnityEngine;

namespace Code
{
    public class PointAndShoot : MonoBehaviour
    {
        public GameObject crosshairs;
        public GameObject player;
        public GameObject bulletPrefab;
        public GameObject bulletStart;


        public float bulletSpeed = 60.0f;


        public float time;

        private Vector3 _target;


        private void Start()
        {
            Cursor.visible = false;
        }


        private void Update()
        {
            time -= Time.deltaTime;

            _target = transform.GetComponent<Camera>()
                .ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            crosshairs.transform.position = new Vector2(_target.x, _target.y);

            var difference = _target - player.transform.position;
            var rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

            if (Input.GetMouseButton(0))
            {
                var distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                FireBullet(direction, rotationZ);
            }
        }

        private void FireBullet(Vector2 direction, float rotationZ)
        {
            var b = Instantiate(bulletPrefab);
            b.transform.position = bulletStart.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}