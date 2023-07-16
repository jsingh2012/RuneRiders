using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] GemsPrefabs = null;
    [SerializeField] private Transform GemsHolder = null;
    [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    [SerializeField] private bool _canSpawnGems = true;
    [SerializeField] private float minDistance = 10f;
    [SerializeField] private float maxDistance = 30f;
    
    private void Start()
    {
        foreach (GameObject enemy in GemsPrefabs)
        {
            StartCoroutine(SpawnPrefabAtRandomLocation(enemy,(float)Random.Range(3, 3)));   
        }
    }

    private IEnumerator SpawnPrefabAtRandomLocation(GameObject enemy, float time)
    {
        yield return null; // Wait for one frame before spawning
        while (true)
        {
            // Spawn the prefab at the calculated position
            GameObject e = Instantiate(enemy);
            e.transform.position = GetRandomPointOn2DPlane();
            e.transform.parent = GemsHolder.transform;
            yield return new WaitForSeconds(time);
        }
    }
    
    private Vector3 GetRandomPointOn2DPlane()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        float distance = Random.Range(minDistance, maxDistance);

        float x = Mathf.Cos(angle) * distance;
        float y = Mathf.Sin(angle) * distance;

        Vector2 randomPoint = new Vector2(playerTransform.position.x +x , playerTransform.position.z + y);
        return new Vector3(randomPoint.x, 0.6f, randomPoint.y);
    }
}
