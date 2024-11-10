using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    // �߻� �ӵ�(�ʴ� �� �� �߻� �������� ����)
    protected float fireRate = 1f;

    // ������ �߻� �ð��� ����ϴ� ����
    protected float lastFireTime = 0f;

    /// <summary>
    /// ���⸦ �߻��ϴ� �߻� �޼���
    /// </summary>
    public abstract void Fire();
}
