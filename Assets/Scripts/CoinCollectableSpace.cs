using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectableSpace : MonoBehaviour
{
    public List<float> collectableLanesX;
    public List<float> collectableJumpsX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetLane()
    {
        if (collectableLanesX == null || collectableLanesX.Count < 1)
        {
            return -1f;
        }

        return collectableLanesX[Random.Range(0, collectableLanesX.Count)];
    }

    public float GetJump()
    {
        if (collectableJumpsX == null || collectableJumpsX.Count < 1)
        {
            return -1f;
        }

        return collectableJumpsX[Random.Range(0, collectableJumpsX.Count)];
    }
}
