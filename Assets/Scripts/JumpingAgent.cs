using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class JumpingAgent : Agent
{
    public float Force = 15f;
    private Rigidbody rb;
    public float obstacleCheckDistance = 1f; // Distance at which the agent detects obstacles
    public LayerMask obstacleLayerMask; // Layer for obstacle detection

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Freeze rotation around X and Z axes
        Debug.Log("Agent initialized with Force: " + Force);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // If the action is greater than 0.5, it indicates a jump
        if (actionBuffers.ContinuousActions[0] > 0.5f && IsGrounded() && ShouldJump())
        {
            Thrust();
        }
    }

    public override void OnEpisodeBegin()
    {
        this.transform.localPosition = new Vector3(0, 0.5f, 0);
        this.transform.localRotation = Quaternion.identity;
        Debug.Log("Episode started: Agent reset.");
    }

    private void Thrust()
    {
        rb.AddForce(Vector3.up * Force, ForceMode.Impulse);
        Debug.Log("Applied thrust to jump.");
    }

    private bool IsGrounded()
    {
        float rayLength = 0.55f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength))
        {
            return hit.collider.CompareTag("Ground");
        }
        return false;
    }

    private bool ShouldJump()
    {
        // Check if there's an obstacle in front within the defined distance
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, obstacleCheckDistance, obstacleLayerMask))
        {
            return true;
        }
        return false;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut.Clear();

        if (Input.GetKey(KeyCode.UpArrow) && IsGrounded() && ShouldJump())
        {
            continuousActionsOut[0] = 1; // Request a jump action
            Debug.Log("Jump requested through heuristic.");
        }
    }
}
