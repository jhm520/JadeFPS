using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;

    private PlayerInput.OnFootActions _onFoot;

    private PlayerMotor _motor;
    private PlayerLook _look;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;
        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();
        _look.cam = Camera.main; // Assign the main camera to the PlayerLook script
        _onFoot.Jump.performed += ctx => _motor.Jump(); // Subscribe to the Jump action
    }   

    private void LateUpdate()
    {
        _look.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the player motor to move using the value from our movement action
        _motor.ProcessMove(_onFoot.Movement.ReadValue<Vector2>());
    }
    
    private void OnEnable()
    {
        // Enable the input actions when the script is enabled
        _onFoot.Enable();
    }
    
    private void OnDisable()
    {
        // Disable the input actions when the script is disabled
        _onFoot.Disable();
    }
}
