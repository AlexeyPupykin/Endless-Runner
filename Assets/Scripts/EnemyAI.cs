using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float movementSpeed = 8f;
    private Rigidbody enemyRb;
    private GameObject player;
    private float reactDistance = 50f;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (!player) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);
        Vector3 lookDirection;

        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        if (distance <= reactDistance)
        {
            if (distance > 5f)
            {
                targetPos.z += (distance / 2f);
            }

            lookDirection = (targetPos - transform.position).normalized;
            enemyRb.AddForce(lookDirection * movementSpeed);
        }
        else
        {
            lookDirection = (targetPos - transform.position).normalized;
            enemyRb.AddForce(lookDirection * movementSpeed * 0.2f);
        }

        if((transform.position.z - player.transform.position.z) < -3f)
        {
            Destroy(gameObject);
        }
    }
}
