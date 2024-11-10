using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    // ����� �ӵ�
    public float FlySpeed = 5;

    // ����� ȸ�� �ӵ�
    public float YawAmount = 120;

    // ���� Yaw ����
    private float Yaw;

    void Update()
    {
        // �ڵ� ����
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        // Ű �Է�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Yaw ȸ���� ���� �Է¿� ���� ���� �Ǵ� �����Ͽ� ������ �¿�� ȸ���ϰ� ����ϴ�.
        Yaw += horizontalInput * YawAmount * Time.deltaTime;

        // Pitch(���� ����) 0~20��
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);

        // Roll(�¿� ����) 0~30������
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        // Yaw, Pitch, Roll ���� �����Ͽ� ȸ������ ����
        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);
    }
}

