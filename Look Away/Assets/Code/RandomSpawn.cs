using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public float time;

    public GameObject EmanyPrefab;
    public GameObject LightPrefab;

    private void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            Spawn();
            time = Random.Range(0, 2);
        }
    }


    private void Spawn()
    {
        Instantiate(EmanyPrefab);
        EmanyPrefab.transform.position = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));

        Instantiate(LightPrefab);
        LightPrefab.transform.position = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));
    }
}