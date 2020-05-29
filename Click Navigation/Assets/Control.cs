using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] Transform target;
    Camera camera;
    void Awake()
    {
        // Get a reference to the Camera component
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        // If the left mouse button was NOT clicked on this frame, end the function.
    if (!Input.GetMouseButton(0)) return; 
    
        // Get the point on the screen where the mouse is
        Vector2 mousePosition = Input.mousePosition;

        // Initialize a ray using the ScreenPointToRay method
        Ray cameraRay = camera.ScreenPointToRay(mousePosition);

        // Declare a RaycastHit
        RaycastHit hit;
        
        // Start a raycast and pass in the RaycastHit to get data back
        bool hitSomething = Physics.Raycast(cameraRay, out hit);

        // If the ray did not hit anything, end the function
        if (!hitSomething) return;

        // If we didn't hit the ground, end the function
        if (!hit.collider.CompareTag("Ground")) return;

        // Set the position of the target to the point where the ray hit
        target.position = hit.point;
    }
}