using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public BoxCollider2D spawnArea;
    public BoxCollider2D gameArea;
    public Vector2[] waves;
    public int enemiesRemaining;
    public static EnemyManager instance;
    private int currentWaveIndex = -1;
    private bool isCoroutineStarted1 = false;
    private bool isCoroutineStarted2 = false;
    public string nextLevel;
    
    private void Start()
    {   
        if (spawnArea == null)
        {
            Debug.LogError("Spawn area is not set!");
            return;
        }
        instance = this;
    }

    void FixedUpdate()
    {
        if(currentWaveIndex == prefabs.Length)
        {
            LevelLoader.Instance.LoadNextLevel(nextLevel);
        }
        //Debug.Log("Currentwaveindex" + currentWaveIndex);
        if (enemiesRemaining == 0 && !isCoroutineStarted1 && !isCoroutineStarted2)
        {
            StartCoroutine(Wave());
            isCoroutineStarted1 = true;
            isCoroutineStarted2 = true;
            currentWaveIndex += 1;
        }

    }
    
    private IEnumerator Wave()
    {
        // Wait until all enemies are dead before spawning the next wave
        while (enemiesRemaining > 0)
        {
            yield return null;
        }

        // All enemies are dead, spawn the next wave after a delay
        Debug.Log("Wave" + currentWaveIndex);
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnChargeEvent());
        StartCoroutine(SpawnShootEvent());
    }

    private IEnumerator SpawnChargeEvent()
    {
        // Get the bounds of the spawn area box collider
        yield return new WaitForSeconds(Random.Range(0.1f, 0.8f));
        Debug.Log("charge");
        Bounds spawnBounds = spawnArea.bounds;
        Bounds gameBounds = gameArea.bounds;
        
        for (int i = 0; i < waves[currentWaveIndex].x; i++)
        {
            Vector3 position = new Vector3(Random.Range(spawnBounds.min.x, spawnBounds.max.x),
                                           Random.Range(spawnBounds.min.y, spawnBounds.max.y),
                                           transform.position.z);
            Vector3 gamePosition = new Vector3(Random.Range(gameBounds.min.x, gameBounds.max.x),
                                           Random.Range(gameBounds.min.y, gameBounds.max.y),
                                           transform.position.z);
            GameObject newObject = Instantiate(prefabs[0], position, Quaternion.identity);
            newObject.transform.parent = transform;
            newObject.GetComponent<TestEnemy>().stationaryPosition = gamePosition;
            enemiesRemaining += 1;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.8f));
        }
        isCoroutineStarted1 = false;
    }

    private IEnumerator SpawnShootEvent()
    {
        // Get the bounds of the spawn area box collider
        yield return new WaitForSeconds(Random.Range(0.1f, 0.8f));
        Bounds spawnBounds = spawnArea.bounds;
        Bounds gameBounds = gameArea.bounds;
        
        for (int j = 0; j < waves[currentWaveIndex].y; j++)
        {
            Vector3 position = new Vector3(Random.Range(spawnBounds.min.x, spawnBounds.max.x),
                                           Random.Range(spawnBounds.min.y, spawnBounds.max.y),
                                           transform.position.z);
            Vector3 gamePosition = new Vector3(Random.Range(gameBounds.min.x, gameBounds.max.x),
                                           Random.Range(gameBounds.min.y, gameBounds.max.y),
                                           transform.position.z);
            GameObject newObject = Instantiate(prefabs[1], position, Quaternion.identity);
            newObject.transform.parent = transform;
            newObject.GetComponent<TestEnemy>().stationaryPosition = gamePosition;
            enemiesRemaining += 1;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.8f));
        }
        isCoroutineStarted2 = false;
    }
}