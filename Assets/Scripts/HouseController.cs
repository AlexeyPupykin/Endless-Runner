using UnityEngine;

public class HouseController : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (player && transform.position.z + 112f < player.position.z)
        {
            Destroy(this.gameObject);
        } 
    }
}
