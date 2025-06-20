using FishNet.Object;
using UnityEngine;

public class PlayerCameraController : NetworkBehaviour
{
    public Camera playerCamera;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Start()
    {
        //TODO: this is probably causing the camera to disable in single player mode, fix that
        if (!base.Owner.IsLocalClient && playerCamera != null)
        {
            playerCamera.gameObject.SetActive(false);
        }
    }
}