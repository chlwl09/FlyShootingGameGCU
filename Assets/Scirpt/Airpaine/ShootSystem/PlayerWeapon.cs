using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : BaseWeapon
{
    public GameObject bulletPrefab;

    private void Start()
    {
        fireRate = 10f; // 발사 속도를 설정
    }

    private void Update()
    {
        // 스페이스바를 눌렀을 때 Fire() 메서드 호출
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    /// <summary>
    /// 플레이어가 무기를 발사하는 메서드
    /// 발사 간격을 조절하여 탄환을 생성
    /// </summary>
    public override void Fire()
    {
        if (Time.time >= lastFireTime + (1f / fireRate))
        {
            if (PoolManager.Instance == null)
            {
                Debug.LogError("PoolManager.Instance가 null입니다. PoolManager가 씬에 존재하는지 확인.");
                return;
            }

            Debug.Log("탄환 생성");
            PoolManager.Instance.SpawnFromPool(transform.position, transform.rotation);
            lastFireTime = Time.time;
        }
    }
}
