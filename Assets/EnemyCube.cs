using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Speed of movement

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        Vector3 targetPosition = player.position;
        targetPosition.y = transform.position.y; // Keep the same Y-coordinate

        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
