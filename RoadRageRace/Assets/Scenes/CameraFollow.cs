using UnityEngine;

public class CameraFollowMidpoint : MonoBehaviour
{
    // References to the two player cars
    public Transform player1;
    public Transform player2;

    // Offset from the midpoint (adjust to position the camera above/behind the action)
    public Vector3 offset = new Vector3(0, 10, -20);

    // How smoothly the camera follows the target point
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Safety check to ensure both players are assigned
        if (player1 == null || player2 == null) return;

        // Calculate the midpoint between the two players
        Vector3 midpoint = (player1.position + player2.position) / 2f;

        // Determine the desired camera position by adding the offset to the midpoint
        Vector3 desiredPosition = midpoint + offset;

        // Smoothly interpolate to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera position
        transform.position = smoothedPosition;

        // Have the camera look at the midpoint
        transform.LookAt(midpoint);
    }
}