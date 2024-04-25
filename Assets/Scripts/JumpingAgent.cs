using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using System;
using Unity.VisualScripting;

public class CubeJumpAgent : Agent
{
    public float jumpForce = 10f; // The force applied to make the cube jump
    private float jumpPenalty = -0.1f; // Penalty for jumping when not necessary
    private Rigidbody cubeRigidbody;
    private bool isGrounded;
    private float survivalReward = 0.01f; // Reward for each timestep the agent survives
    private float successfulPassReward = 1.0f; // Reward for successfully passing an obstacle
    private float coinReward = 0.5f; // Reward for collecting a coin
    private float hitObstaclePenalty = -1.0f; // Penalty for hitting an obstacle
    public Spawner spawner;

    // Initialize agent properties and components
    public override void Initialize()
    {
        cubeRigidbody = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        if (cubeRigidbody == null)
        {
            Debug.LogError("Rigidbody not found on " + gameObject.name);
            return; // Stop the function if Rigidbody is not found
        }

        cubeRigidbody.velocity = Vector3.zero;
        cubeRigidbody.angularVelocity = Vector3.zero;
        transform.localPosition = new Vector3(5, -6.472911f, -1.685753f);
        transform.localRotation = Quaternion.identity;
        isGrounded = true;
    }


    // Handle actions from the neural network
    public override void OnActionReceived(ActionBuffers actions)
    {
        AddReward(survivalReward); // Reward for surviving each timestep

        if (actions.ContinuousActions[0] > 0.5f && isGrounded)
        {
            cubeRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
            AddReward(jumpPenalty); // Penalty for jumping unnecessarily
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check for collision with ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        // Check for collision with avoidable objects like fighter jets
        else if (collision.gameObject.CompareTag("Avoid"))
        {
            AddReward(hitObstaclePenalty);
            spawner.ResetSpawner();
            EndEpisode();
        }
        // Check for collision with walls that provide reward after successfully passing an obstacle
        else if (collision.gameObject.CompareTag("WallReward"))
        {
            AddReward(successfulPassReward);
            // Here you may want to continue the episode instead of ending it
        }
        // Check for collision with coins
        else if (collision.gameObject.CompareTag("coin"))
        {
            Console.WriteLine("coin taken");
            AddReward(coinReward); // Give the agent a reward for collecting a coin
            Destroy(collision.gameObject); // Destroy the coin GameObject
            // Do not end the episode to allow for further coin collection and obstacle passing
        }
    }
    // Implement manual control for debugging purposes
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;
    }
    // Observations can be added from a Ray Perception Sensor 3D component if necessary
}
