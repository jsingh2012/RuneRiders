using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyHolder;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float minDistance = 5f;
    [SerializeField] private float maxDistance = 10f;
    private void Start()
    {
        foreach (GameObject enemy in enemies)
        {
            StartCoroutine(SpawnPrefabAtRandomLocation(enemy,(float)Random.Range(1, 2)));   
        }
    }

    private IEnumerator SpawnPrefabAtRandomLocation(GameObject enemy, float time)
    {
        yield return null; // Wait for one frame before spawning
        while (true)
        {
            // Calculate a random direction and distance within the specified range
            Vector3 randomDirection = Random.insideUnitSphere.normalized;
            float randomDistance = Random.Range(minDistance, maxDistance);

            // Calculate the spawn position based on the player's position, direction, and distance
            Vector3 spawnPosition = new Vector3(playerTransform.position.x + (randomDirection.x * randomDistance),
                0.6f, playerTransform.position.z + (randomDirection.z * randomDistance));

            // Spawn the prefab at the calculated position
            GameObject e = Instantiate(enemy, spawnPosition, Quaternion.identity);
            e.transform.parent = enemyHolder.transform;
            yield return new WaitForSeconds(time);
        }
    }
}
