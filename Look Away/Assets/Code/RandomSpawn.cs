using UnityEngine;
using UnityEngine.Serialization;

namespace Code
{
    public class RandomSpawn : MonoBehaviour
    {
        public float time;

        public GameObject ememyPrefab;
        public GameObject lightPrefab;

        private void Update()
        {
            time -= Time.deltaTime;

            if (!(time < 0)) return;
            Spawn();
            time = Random.Range(0, 2);
        }


        private void Spawn()
        {
            Instantiate(ememyPrefab);
            ememyPrefab.transform.position = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));

            Instantiate(lightPrefab);
            lightPrefab.transform.position = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));
        }
    }
}