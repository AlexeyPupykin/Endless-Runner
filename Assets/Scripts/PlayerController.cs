using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float minXValue = -6.5f;
    public float maxXValue = 6.5f;
    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;
        float vMovement = Input.GetAxis("Vertical") * movementSpeed;

        transform.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXValue, maxXValue), transform.position.y, transform.position.z);

        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(123);
        spawnManager.SpawnTriggerEntered();
    }
}
