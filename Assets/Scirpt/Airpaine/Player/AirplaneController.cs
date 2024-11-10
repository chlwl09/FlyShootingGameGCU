using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    // 비행기 속도
    public float FlySpeed = 5;

    // 비행기 회전 속도
    public float YawAmount = 120;

    // 현재 Yaw 각도
    private float Yaw;

    void Update()
    {
        // 자동 전진
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        // 키 입력
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Yaw 회전은 수평 입력에 따라 증가 또는 감소하여 방향을 좌우로 회전하게 만듭니다.
        Yaw += horizontalInput * YawAmount * Time.deltaTime;

        // Pitch(상하 기울기) 0~20도
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);

        // Roll(좌우 기울기) 0~30도까지
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        // Yaw, Pitch, Roll 값을 종합하여 회전값을 설정
        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);
    }
}

