using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public float time;

    public Transform sp;
    public GameObject EmanyPrefab;

    private void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            Spawn();
            time = Random.Range(0, 5);
        }
    }


    private void Spawn()
    {
        Instantiate(EmanyPrefab, sp.position, sp.rotation);
    }
}