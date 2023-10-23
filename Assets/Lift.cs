using UnityEngine;

public class Lift : MonoBehaviour
{
    public float moveDistance = 1.0f;    // Total distance the cube should move.
    public float moveSpeed = 2.0f;       // Speed at which the cube moves.

    private Vector3 initialPosition;     // The initial position of the cube.
    private Vector3 targetPosition;      // The target position for the cube to reach.

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + Vector3.up * moveDistance;
    }

    private void Update()
    {
        // Use Lerp to move the cube up and down.
        transform.position = Vector3.Lerp(initialPosition, targetPosition, (Mathf.Sin(Time.time * moveSpeed) + 1.0f) / 2.0f);
    }
}