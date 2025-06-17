using FishNet.Object;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public Camera playerCamera;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Start()
    {
        if (!base.Owner.IsLocalClient && playerCamera != null)
        {
            playerCamera.gameObject.SetActive(false);
        }
    }
}