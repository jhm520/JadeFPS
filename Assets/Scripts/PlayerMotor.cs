using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(CharacterController))]

public class PlayerMotor : NetworkBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    
    private bool _isGrounded;
    
    public float speed = 5.0f; // Speed of the player
    
    public float gravity = -9.8f; // Gravity applied to the player
    public float jumpHeight = 3.0f; // Height of the jump
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
        {
            Debug.LogError("CharacterController component not found on the player object.");
        }
        
        _playerVelocity = Vector3.zero; // Initialize player velocity
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsOwner);
            
        if (!IsOwner) return; // Only the owning player can control this object
        
        _isGrounded = _controller.isGrounded; // Check if the player is grounded
    }

    //receive the inputs from our input manager and apply them to the character controller
    public void ProcessMove(Vector2 input)
    {
        if (!IsOwner) return;
        
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        
        _playerVelocity.y += gravity * Time.deltaTime; // Apply gravity to the player velocity
        
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f; // Reset vertical velocity when grounded
        }
        
        _controller.Move( _playerVelocity * Time.deltaTime);
        Debug.Log(_playerVelocity.y);
    }

    public void Jump()
    {
        if (!IsOwner) return;

        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(jumpHeight  * -3.0f * gravity); // Jump with an initial velocity
            // 1.0f is the jump height, you can adjust it as needed
            Debug.Log("Jumping!");
        }
        else
        {
            Debug.Log("Cannot jump, not grounded.");
        }
    }
}
