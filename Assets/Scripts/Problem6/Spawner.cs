using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject toSpawn;
    [SerializeField] protected Vector2 spawnRadius;
    [SerializeField] protected int maxSpawn;
    
    protected virtual void Start()
    {
        int spawn = Random.Range(1, 12 + 1);

        for (int i = 0; i < spawn; i++)
        {
            GameObject box = Instantiate(toSpawn);
            box.transform.position = GetSpawnPos();
        }
    }

    protected virtual Vector2 GetSpawnPos()
    {
        float x = Random.Range(-spawnRadius.x, spawnRadius.x);
        float y = Random.Range(-spawnRadius.y, spawnRadius.y);

        return new Vector2(x, y);
    }
}
