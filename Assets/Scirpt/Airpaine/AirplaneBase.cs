using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AirplaneBase : MonoBehaviour
{
    [Header("HP")]
    public int maxHealth = 10; // �÷��̾� �ִ� HP�� ����
    protected int currenHealth; // ���� ü���� ����

    // maxHealth ���� currenHealth�� �����Ͽ� �ִ� ü������ ����
    protected virtual void Start()
    {
        currenHealth = maxHealth;
    }

    /// <summary>
    /// ����Ⱑ �������� ���� �� ȣ��
    /// </summary>
    /// <param name="damege">���� ������ ��</param>
    public void TakeDamage(int damege)
    {
        currenHealth -= damege; // �������� ������ ü���� ����
        if (currenHealth < 0)
        {
            currenHealth = 0;
            OnDeath();
        }
    }

    /// <summary>
    /// ü���� 0�� �� �� ����
    /// �߻�޼���� ��� Ŭ����()���� ����
    /// </summary>
    protected abstract void OnDeath();
}
