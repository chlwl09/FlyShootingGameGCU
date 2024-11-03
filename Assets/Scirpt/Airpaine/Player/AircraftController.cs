using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftController : PlayerManager
{
    void FixedUpdate()
    {
        MoveAircraft();
        RotateAircraft();
    }

    public void MoveAircraft()
    {
        float moveInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * moveInput;
        Instance.Move(moveDirection);
    }

    public void RotateAircraft()
    {
        float rotateInput = Input.GetAxis("Horizontal");
        Vector3 rotation = Vector3.up * rotateInput;
        Instance.Rotate(rotation);
    }
}
