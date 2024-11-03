using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;

    protected Rigidbody rb;

    protected virtual void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }

    public void Rotate(Vector3 rotation)
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation * rotationSpeed * Time.deltaTime));
    }
}
