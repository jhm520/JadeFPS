using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float _xRotation = 0f; // Variable to store the current x rotation

    public float xSensitivity = 30.0f;
    public float ySensitivity = 30.0f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        
        //calculate camera rotation for looking up and down
        _xRotation -= mouseY * ySensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -89f, 89f); // Clamp the x rotation to prevent flipping
        
        //apply this to the camera transform
        cam.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        
        //rotate player to look left and right
        transform.Rotate(Vector3.up * mouseX * xSensitivity * Time.deltaTime);
    }
}
