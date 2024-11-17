using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AirplaneBase : MonoBehaviour
{
    [Header("HP")]
    public int maxHealth = 10; // 플레이어 최대 HP를 설정
    protected int currenHealth; // 현재 체력을 저장

    // maxHealth 값을 currenHealth로 설정하여 최대 체력으로 시작
    protected virtual void Start()
    {
        currenHealth = maxHealth;
    }

    /// <summary>
    /// 비행기가 데미지를 받을 때 호출
    /// </summary>
    /// <param name="damege">받을 데미지 양</param>
    public void TakeDamage(int damege)
    {
        currenHealth -= damege; // 데미지를 입으면 체력을 감소
        if (currenHealth < 0)
        {
            currenHealth = 0;
            OnDeath();
        }
    }

    /// <summary>
    /// 체력이 0이 될 시 실행
    /// 추상메서드로 상속 클래스()에서 정의
    /// </summary>
    protected abstract void OnDeath();
}
