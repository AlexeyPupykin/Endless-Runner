using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float minXValue = -6.5f;
    public float maxXValue = 6.5f;
    private float previousX;
    public float rotationSpeed = 100f;
    //private float previousY;

    public SpawnManager spawnManager;

    public Animator model;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        previousX = transform.position.x;

        float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;
        //float vMovement = Input.GetAxis("Vertical") * movementSpeed;

        transform.Translate(new Vector3(hMovement, 0, movementSpeed) * Time.deltaTime);

        var deltaX = transform.position.x - previousX;


        model.transform.eulerAngles = new Vector3(transform.eulerAngles.y, deltaX * rotationSpeed, transform.eulerAngles.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXValue, maxXValue), transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(999);
            model.Play("Jump");
            GetComponent<Animator>().Play("Jump");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(123);
        spawnManager.SpawnTriggerEntered();
    }
}
