using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script is responsible for 
/// rotating the objects that it
/// is attached too
/// </summary>
public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 2f;

    /// <summary>
    /// This script will be used to rotate objects along the z axis
    /// wanted to try something different than using animations
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame
    /// in this update method it rotates
    /// the gameObject this script is 
    /// attached to
    /// </summary>
    void Update()
    {
        transform.Rotate(0, 0, 360 * rotationSpeed * Time.deltaTime);
    }
}
