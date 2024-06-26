using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float minSpeed = 10f; // Minimum speed
    public float maxSpeed = 40f; // Maximum speed
    private float speed; // Speed of movement

    void Start()
    {
        // Set a random speed between minSpeed and maxSpeed when the object is spawned
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        // Move the object forward in the z-axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Trigger event handler
    void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the tag "BackWall"
        if (other.CompareTag("BackWall"))
        {
            // Destroy this GameObject
            Destroy(gameObject);
        }
    }
}
