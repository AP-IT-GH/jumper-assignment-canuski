using UnityEngine;

public class CoinMoveForward : MonoBehaviour
{
    public float speed = 5f; // Speed of movement

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