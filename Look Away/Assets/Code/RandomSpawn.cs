using UnityEngine;
using UnityEngine.Serialization;

namespace Code
{
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
                time = Random.Range(0, 2);
            }
        }


        private void Spawn()
        {
            Instantiate(emanyPrefab);
            emanyPrefab.transform.position = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));

            Instantiate(lightPrefab);
            lightPrefab.transform.position = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));
        }
    }
}