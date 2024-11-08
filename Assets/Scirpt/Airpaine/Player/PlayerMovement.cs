using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        float rotationX = Input.GetKey(KeyCode.W) ? -1f : (Input.GetKey(KeyCode.S) ? 1f : 0f);
        float rotationY = Input.GetKey(KeyCode.A) ? -1f : (Input.GetKey(KeyCode.D) ? 1f : 0f);
        
        /*
        float rotationX = 0f;
        float rotationY = 0f;

        if (Input.GetKey(KeyCode.W))
            rotationX = -1f;
        else if (Input.GetKey(KeyCode.S))
            rotationX = 1f;

        if (Input.GetKey(KeyCode.A))
            rotationY = -1f;
        else if (Input.GetKey(KeyCode.D))
            rotationY = 1f;
        */

        Vector3 rotation = new Vector3(rotationX, rotationY, 0f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }
}
