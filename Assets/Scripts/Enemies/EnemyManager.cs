using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject prefab;
    public BoxCollider2D spawnArea;
    public BoxCollider2D gameArea;
    public int count = 10;

    private void Start()
    {
        if (spawnArea == null)
        {
            Debug.LogError("Spawn area is not set!");
            return;
        }

        // Get the bounds of the spawn area box collider
        Bounds spawnBounds = spawnArea.bounds;
        Bounds gameBounds = gameArea.bounds;
        
        // Loop through the count and instantiate prefabs at random positions within the spawn area bounds
        for (int i = 0; i < count; i++)
        {
            Vector3 position = new Vector3(Random.Range(spawnBounds.min.x, spawnBounds.max.x),
                                           Random.Range(spawnBounds.min.y, spawnBounds.max.y),
                                           transform.position.z);
            Vector3 gamePosition = new Vector3(Random.Range(gameBounds.min.x, gameBounds.max.x),
                                           Random.Range(gameBounds.min.y, gameBounds.max.y),
                                           transform.position.z);
            GameObject newObject = Instantiate(prefab, position, Quaternion.identity);
            newObject.transform.parent = transform;
            newObject.GetComponent<TestEnemy>().stationaryPosition = gamePosition;
        }
    }
}