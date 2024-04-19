using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public Camera mainCamera;
    public float shootForce = 10f;
    public float cooldownTime = 0.5f; // Cooldown time between shots
    public float ballLifetime = 3f; // Lifetime of the ball

    private float lastShootTime;

    void Update()
    {
        // Check if enough time has passed since the last shot for cooldown
        if (Time.time - lastShootTime >= cooldownTime && Input.GetMouseButtonDown(0))
        {
            // Calculate ray from camera through mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray intersects with anything in the scene
            if (Physics.Raycast(ray, out hit))
            {
                // Calculate the direction from the camera to the point where the mouse clicked
                Vector3 direction = hit.point - mainCamera.transform.position;

                // Instantiate the ball at the camera's position
                GameObject ball = Instantiate(ballPrefab, mainCamera.transform.position, Quaternion.identity);

                // Apply force to the ball in the calculated direction
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(direction.normalized * shootForce, ForceMode.Impulse);
                }

                // Destroy the ball after its lifetime
                Destroy(ball, ballLifetime);

                // Update the last shoot time
                lastShootTime = Time.time;
            }
        }
    }
}
