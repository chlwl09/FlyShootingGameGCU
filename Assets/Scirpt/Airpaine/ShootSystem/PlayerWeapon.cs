using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : BaseWeapon
{
    public GameObject bulletPrefab;

    private void Start()
    {
        fireRate = 1f; // 예시로 발사 속도를 설정
    }

    private void Update()
    {
        Fire();
    }

    /// <summary>
    /// 플레이어가 무기를 발사하는 메서드
    /// 발사 간격을 조절하여 탄환을 생성
    /// </summary>
    public override void Fire()
    {
        if (Time.time >= lastFireTime + (1f / fireRate))
        {
            Debug.Log("탄환 생성");
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            lastFireTime = Time.time;
        }
    }
}
