using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 56f;

    void Start()
    {
        if (roads != null && roads.Any())
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }
    
    public void ModeRoad()
    {
        GameObject modedRoad = roads[0];
        roads.Remove(modedRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        modedRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(modedRoad);
    }
}
