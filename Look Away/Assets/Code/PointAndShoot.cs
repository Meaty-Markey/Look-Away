using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject superbulletPrefab;
    public GameObject bulletStart;
    public GameObject superbulletStart;

    public SuperBar superbar;

    public int maxsuper = 100;
    public int currentsuper;

    public float bulletSpeed = 60.0f;

    private Vector3 target;

    public float bl = 3;

    public float time;



    void Start()
    {
        Cursor.visible = false;
        bl = 3;
        currentsuper = 0;
        superbar.SetMaxSuper(maxsuper);
    }


    void Update()
    {
        time -= Time.deltaTime;

        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0) && bl > 0)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
            bl -= 1;
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            bl = 3;
        }

        if (time < 0)
        {
            currentsuper += 1;
            superbar.SetSuper(currentsuper);
            time = Random.Range(0, 5);
        }

        else if (Input.GetMouseButtonDown(1) && currentsuper > 50)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            firesuperBullet(direction, rotationZ);
            currentsuper -= 5;
        }

    }
    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    void firesuperBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(superbulletPrefab) as GameObject;
        b.transform.position = superbulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

}
