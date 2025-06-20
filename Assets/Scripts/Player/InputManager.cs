using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    private PlayerInputActions.OnFootActions _onFoot;

    private PlayerMotor _motor;
    private PlayerLook _look;
    
    public void Start()
    {
        if (!GameInstanceManager.PlayerGameInstanceTagContainer.HasTagByName( "GameplayTag/JadeFPS/Game/PlaySolo"))
        {
            // If the PlaySolo tag is present, disable this script
            enabled = false;
            return;
        }
        
        InitializeInput();
    }

    void InitializeInput()
    {
        
        enabled = true; // Enable the script if the player is the owner
        
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
        _onFoot = _playerInputActions.OnFoot;
        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();
        _look.cam = GetComponentInChildren<Camera>(); // Assign the main camera to the PlayerLook script
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
        
        if (_playerInputActions == null) return; // Check if _playerInput is not null
        _onFoot.Enable();
    }
    
    private void OnDisable()
    {
        // Disable the input actions when the script is disabled
        if (_playerInputActions == null) return; // Check if _playerInput is not null
        _onFoot.Disable();
    }
}
