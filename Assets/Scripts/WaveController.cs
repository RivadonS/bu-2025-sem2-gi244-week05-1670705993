using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Transform[] spawnPoints;
    private Wave wave;
    private int spawnEnemies = 0;
    private float nextSpawnTime = 0;

    public void ChangeWave(Wave wave)
    {
        this.wave = wave;
        spawnEnemies = 0;
        nextSpawnTime = Time.time;
    }

    public bool isCompleted()
    {
        return spawnEnemies >= wave.enemyCount;
    }

    void Update()
    {
        float t = Time.time;

        if (spawnEnemies < wave.enemyCount)
        {
            Spawn();
            spawnEnemies++;
            nextSpawnTime = t + wave.spawnInterval;
        }
    }

    void Spawn()
    {
        int enemyIndex = Random.Range(0, wave.enemyPrefabs.Length);
        int pointIndex = Random.Range(0, spawnPoints.Length);

        var prefabs = wave.enemyPrefabs[enemyIndex];
        var point = spawnPoints[pointIndex];

        Instantiate(
            prefabs,
            point.position,
            Quaternion.Euler(0, 180, 0)
            );
    }
}
