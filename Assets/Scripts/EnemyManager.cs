using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
//Test10
    public static EnemyManager Instance;
    // Start is called before the first frame update
    [SerializeField] public GameObject enemyHolder;
    [SerializeField] public Transform enemyWithWeaponHolder = null;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float minDistance = 10f;
    [SerializeField] private float maxDistance = 30f;
    private void Start()
    {
        Instance = this;
        foreach (GameObject enemy in enemies)
        {
            StartCoroutine(SpawnPrefabAtRandomLocation(enemy,(float)Random.Range(1, 3)));   
        }
    }

    private IEnumerator SpawnPrefabAtRandomLocation(GameObject enemy, float time)
    {
        yield return null; // Wait for one frame before spawning
        while (true)
        {
            // Spawn the prefab at the calculated position
            GameObject e = Instantiate(enemy, GetRandomPointOn2DPlane(), Quaternion.identity);
            e.transform.parent = enemyHolder.transform;
            yield return new WaitForSeconds(time);
        }
    }
    
    private Vector3 GetRandomPointOn2DPlane()
    {
        if (playerTransform)
        {
            float angle = Random.Range(0f, 2f * Mathf.PI);
            float distance = Random.Range(minDistance, maxDistance);

            float x = Mathf.Cos(angle) * distance;
            float y = Mathf.Sin(angle) * distance;

            Vector2 randomPoint = new Vector2(playerTransform.position.x + x, playerTransform.position.z + y);
            return new Vector3(randomPoint.x, 0.6f, randomPoint.y);
        } 
        return Vector3.zero;
    }
}
