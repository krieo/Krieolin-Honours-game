using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for the camera control
/// </summary>
public class CameraController : MonoBehaviour
{
    public Transform PlayerTransform;
    public float Yaxis = 4;
    private Camera mainCamera; // Reference to the main camera component
    public float cameraSizeStep = 1f; // The amount to increase or decrease the camera size by
    public float scrollWheelIncrement = 0.1f; // The increment for camera size change with mouse scroll wheel

    /// <summary>
    /// This is called before the first update frame
    /// </summary>
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    /// <summary>
    /// Update is called once per frame
    /// It updates the camera's position on the player and 
    /// allows for mouse wheel movement
    /// </summary>
    void Update()
    {
        transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + Yaxis, transform.position.z);

        // Increase camera size if the "+" key is pressed or mouse scroll wheel is scrolled up
        if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus) || Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            IncreaseCameraSize();
        }

        // Decrease camera size if the "-" key is pressed or mouse scroll wheel is scrolled down
        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus) || Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            DecreaseCameraSize();
        }
    }

    /// <summary>
    /// This method zooms the camera in
    /// </summary>
    public void IncreaseCameraSize()
    {
        mainCamera.orthographicSize += cameraSizeStep;
    }

    /// <summary>
    /// This method zooms the camera out
    /// </summary>
    public void DecreaseCameraSize()
    {
        if (mainCamera.orthographicSize > cameraSizeStep)
        {
            mainCamera.orthographicSize -= cameraSizeStep;
        }
    }
}
