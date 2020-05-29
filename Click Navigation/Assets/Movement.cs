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
        // Get the velocity of the NavMeshAgent
        Vector3 velocity = navMeshAgent.velocity;

        // Use the velocity to get the component vector in the Z direction
        Vector3 forwardVelocity = Vector3.Scale(velocity, transform.forward);

        // Speed is a scalar. We can get it from the magnitude of the forwardVelocity vector
        float forwardSpeed = forwardVelocity.magnitude;

        // Now we can set the Speed parameter of the Animator
        animator.SetFloat("Speed", forwardSpeed);
    }
}