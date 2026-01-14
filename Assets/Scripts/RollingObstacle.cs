using UnityEngine;

public class RollingObstacle : MonoBehaviour
{
    public float speed = 10f;
    public float rollSpeed = 300f;

    void Update()
    {
        // Move towards the player (in -Z direction usually)
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // Rotate to look like rolling
        transform.Rotate(Vector3.right * rollSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit by Rolling Obstacle!");
            // Call game over method here
        }
    }
}
