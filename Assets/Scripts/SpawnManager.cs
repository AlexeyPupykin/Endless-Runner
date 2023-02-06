using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadSpawner;
    PlotSpawner plotSpawner;
    ObstacleSpawner obstacleSpawner;

    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        plotSpawner = GetComponent<PlotSpawner>();
        obstacleSpawner = GetComponent<ObstacleSpawner>();
    }

    public void SpawnTriggerEntered()
    {
        roadSpawner.ModeRoad();
        plotSpawner.SpawnPlot();
        obstacleSpawner.SpawnObstacles();
    }
}
