using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    // 발사 속도(초당 몇 번 발사 가능한지 설정)
    protected float fireRate = 1f;

    // 마지막 발사 시간을 기록하는 변수
    protected float lastFireTime = 0f;

    /// <summary>
    /// 무기를 발사하는 추상 메서드
    /// </summary>
    public abstract void Fire();
}
