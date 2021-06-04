using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bl = 3; 
    
    void Update()
    {
     if (Input.GetButtonDown("Fire1") && bl >= 1)
        {
            Shoot();
            bl -= 1; 
        }

      else if (Input.GetKeyDown(KeyCode.R))
        {
            bl = 3; 
        }
        
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
