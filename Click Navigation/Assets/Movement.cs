using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform target; 
    NavMeshAgent navMeshAgent; 
    Animator animator; // Declare animator as private property
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Get reference to animator
    }

    void Update()
    {
        navMeshAgent.destination = target.position;
        UpdateAnimator();
    }

    void UpdateAnimator() {
        // Get the velocity of the NavMeshAgent.
        Vector3 velocity = navMeshAgent.velocity;

        // Convert the velocity from global to local.
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        // Speed is a scalar. We can get it from the z axis of the local velocity. 
        float forwardSpeed = localVelocity.z;

        // Now we can set the Speed parameter of the Animator.
        animator.SetFloat("Speed", forwardSpeed);
    }
}