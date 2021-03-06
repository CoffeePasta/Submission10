using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawner : Spawner
{
    Queue<GameObject> boxQue = new Queue<GameObject>();
    Queue<float> respawnQue = new Queue<float>();
    float currentTime;

    [SerializeField] private LayerMask unspawnable;

    protected override void Start()
    {
        int spawn = Random.Range(1, maxSpawn + 1);

        for (int i = 0; i < spawn; i++)
        {
            GameObject boxObj = Instantiate(toSpawn);
            boxObj.transform.position = GetSpawnPos();
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (respawnQue.Count > 0 && currentTime >= respawnQue.Peek())
        {
            respawnQue.Dequeue();

            GameObject respawnObj = boxQue.Dequeue();
            respawnObj.transform.position = GetSpawnPos();
            respawnObj.gameObject.SetActive(true);
        }
    }

    protected override Vector2 GetSpawnPos()
    {
        Vector2 spawnPoint = new Vector2();
        spawnPoint.x = Random.Range(-spawnRadius.x, spawnRadius.x);
        spawnPoint.y = Random.Range(-spawnRadius.y, spawnRadius.y);

        if (Physics2D.OverlapBox(spawnPoint, Vector2.one, unspawnable))
            return GetSpawnPos();

        return spawnPoint;
    }

    public void Respawn(GameObject box)
    {
        boxQue.Enqueue(box);
        respawnQue.Enqueue(currentTime + 3f);
    }
}
