using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private int initAmount = 5;
    private int spawnInterval = 56;
    private int lastSpawnZ= 28;
    private int spawnAmount = 4;

    public List<GameObject> obstacles;

    public GameObject coins;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnObstacles();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacles()
    {
        lastSpawnZ += spawnInterval;

        GameObject coinInstance = null;

        for (int i = 0; i < spawnAmount; i++)
        {
            if(Random.Range(0, 4) == 0)
            {
                GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];

                Instantiate(obstacle, new Vector3(0, 0, lastSpawnZ), obstacle.transform.rotation);

                if (Random.Range(0, 2) == 1 && coinInstance == null)
                {
                    CoinCollectableSpace space = obstacle.GetComponent<CoinCollectableSpace>();
                    coinInstance = Instantiate(coins, new Vector3(space.GetLane(), 0, lastSpawnZ + 0), coins.transform.rotation);
                }
            }
            else
            {
                if (Random.Range(0, 2) == 1 && coinInstance == null)
                {
                    coinInstance = Instantiate(coins, new Vector3(0, 0, lastSpawnZ + 0), coins.transform.rotation);
                }
            }
        }
    }
}
