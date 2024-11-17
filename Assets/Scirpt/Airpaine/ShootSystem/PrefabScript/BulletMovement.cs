using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 20.0f;
    public float maxDistance = 100f; // 최대 이동 거리
    public int bulletDamage = 10;    // 탄환의 데미지

    private Vector3 initialPosition;

    void OnEnable()
    {
        initialPosition = transform.position; // 활성화될 때 초기 위치 저장
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        // 탄환이 최대 거리 이상 이동했는지 확인
        if (Vector3.Distance(initialPosition, transform.position) >= maxDistance)
        {
            Deactivate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ApplyDamageOnCollision(other);
        PoolManager.Instance.ReturnToPool(gameObject); // 탄환을 풀로 반환
    }

    private void ApplyDamageOnCollision(Collider other)
    {
        // 충돌한 객체가 AirplaneBase를 상속하는지 확인
        AirplaneBase target = other.GetComponent<AirplaneBase>();
        if (target != null)
        {
            target.TakeDamage(bulletDamage); // 데미지 적용
        }
    }

    private void Deactivate()
    {
        PoolManager.Instance.ReturnToPool(gameObject); // 최대 이동 시 비활성화
    }
}
