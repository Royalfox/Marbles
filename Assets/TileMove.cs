using UnityEngine;

public class MovingTile : MonoBehaviour
{
    public Material yellowMaterial; // The yellow material
    public float moveDistance = 0.5f; // Total distance the tile moves (adjust this value)
    public float moveSpeed = 1.0f; // Speed of movement

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool onTile = false;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition - Vector3.right * moveDistance;
        GetComponent<Renderer>().material = yellowMaterial;
    }

    void Update()
    {
        if (onTile)
        {
            MoveTile();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // Ball (player) is on the tile, start moving
            onTile = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // Ball (player) has left the tile, stop moving
            onTile = false;
        }
    }

    void MoveTile()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position == targetPosition || transform.position == initialPosition)
        {
            // The tile has reached its destination or initial position, stop moving
            onTile = false;
        }
    }
}

