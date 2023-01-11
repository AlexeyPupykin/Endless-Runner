using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlotSpawner : MonoBehaviour
{
    private int initAmount = 5;
    private float initStartZ = 25;
    private float plotSize = 56f;
    private float xPosLeft = -36f;
    private float xPosRight = 36f;
    private float lastZpos = -56f;

    public List<GameObject> plots;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnPlot();
        }

        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
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
