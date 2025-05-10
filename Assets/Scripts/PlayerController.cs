using Unity.Netcode;
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
        if (!IsOwner && playerCamera != null)
        {
            playerCamera.gameObject.SetActive(false);
        }
    }
}