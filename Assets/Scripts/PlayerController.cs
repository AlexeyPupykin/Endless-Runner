using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float minXValue = -5f;
    public float maxXValue = 5f;
    private float previousX;
    public float rotationSpeed = 100f;

    public SpawnManager spawnManager;
    public GameManager gameManager;

    public Animator model;

    void Update()
    {
        previousX = transform.position.x;

        float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;

        transform.Translate(new Vector3(hMovement, 0, movementSpeed) * Time.deltaTime);

        var deltaX = transform.position.x - previousX;

        model.transform.eulerAngles = new Vector3(transform.eulerAngles.y, deltaX * rotationSpeed, transform.eulerAngles.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXValue, maxXValue), transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            model.Play("Jump");
            GetComponent<Animator>().Play("Jump");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpawnTrigger")
        {
            spawnManager.SpawnTriggerEntered();
        }

        if (other.tag == "Coin")
        {
            gameManager.CoinCollected();
            Destroy(other.gameObject);
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            movementSpeed = 0f;

            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            StartCoroutine(WaitAndRestart(0.01f)); 
        }
    }

    private IEnumerator WaitAndRestart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameManager.GameOver();
        Destroy(gameObject);
    }
}
