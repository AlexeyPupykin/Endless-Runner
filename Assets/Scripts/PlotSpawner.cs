using System.Collections.Generic;
using UnityEngine;

public class PlotSpawner : MonoBehaviour
{
    private int initAmount = 5;
    private float plotSize = 56f;
    private float xPosLeft = -36f;
    private float xPosRight = 36f;
    private float lastZpos = -56f;

    public List<GameObject> plots;
    private Transform player;

    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnPlot();
        }

        player = GameObject.Find("Player").transform;
    }

    public void SpawnPlot()
    {
        GameObject plotLeft = plots[Random.Range(0, plots.Count)];
        GameObject plotRight = plots[Random.Range(0, plots.Count)];

        float zPos = lastZpos + plotSize;

        Instantiate(plotLeft, new Vector3(xPosLeft, 0.025f, zPos), plotLeft.transform.rotation);
        Instantiate(plotRight, new Vector3(xPosRight, 0.025f, zPos), new Quaternion(0, 180, 0, 0));

        lastZpos += plotSize;
    }
}
