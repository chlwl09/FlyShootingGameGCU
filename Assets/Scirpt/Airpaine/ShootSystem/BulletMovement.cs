using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 20.0f;
    public float maxDistance = 100f; // 최대 이동
    public float maxTime = 10;

    void Start()
    {
        maxTime = maxDistance / bulletSpeed;

        Destroy(gameObject, maxTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
