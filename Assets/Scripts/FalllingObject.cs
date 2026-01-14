using UnityEngine;
using System.Collections;

public class FallingObstacleLoop : MonoBehaviour
{
    [Header("Delays")]
    public float fallDelay = 1f;          // Time before starting the fall
    public float resetDelay = 3f;         // Time before resetting position

    [Header("Position")]
    private Vector3 startPosition;        // Sky position
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;  // Save original sky position
    }

    void OnEnable()
    {
        StartCoroutine(FallingSequence());
    }

    IEnumerator FallingSequence()
    {
        // Step 1: Reset to sky
        ResetObstacle();

        // Step 2: Wait before fall
        yield return new WaitForSeconds(fallDelay);

        // Step 3: Enable gravity to fall
        rb.useGravity = true;

        // Step 4: Wait before resetting again
        yield return new WaitForSeconds(resetDelay);

        // Step 5: Loop by re-enabling sequence
        StartCoroutine(FallingSequence());
    }

    void ResetObstacle()
    {
        // Teleport back to sky position
        transform.position = startPosition;

        // Reset Rigidbody physics
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
