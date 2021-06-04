using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public float time = 0;

    public Transform sp;
    public GameObject EmanyPrefab;

    void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            Spawn();
            time = (Random.Range(0, 5)); 
        }

    }


    void Spawn()
    {
        Instantiate(EmanyPrefab, sp.position, sp.rotation);
    }
}

