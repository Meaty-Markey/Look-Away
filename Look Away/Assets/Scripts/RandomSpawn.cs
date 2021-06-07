using UnityEngine;
using UnityEngine.Serialization;

public class RandomSpawn : MonoBehaviour
{
    public float time;

    [FormerlySerializedAs("EmanyPrefab")] public GameObject emanyPrefab;
    [FormerlySerializedAs("LightPrefab")] public GameObject lightPrefab;

    private void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            Spawn();
            time = Random.Range(0, 4);
        }
    }


    private void Spawn()
    {
        Instantiate(emanyPrefab);
        emanyPrefab.transform.position = new Vector2(Random.Range(-90, 27), Random.Range(-66, 56));

        Instantiate(lightPrefab);
        lightPrefab.transform.position = new Vector2(Random.Range(-90, 27), Random.Range(-66, 56));
    }
}