using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : BaseWeapon
{
    public GameObject bulletPrefab;

    private void Start()
    {
        fireRate = 1f; // ���÷� �߻� �ӵ��� ����
    }

    private void Update()
    {
        Fire();
    }

    /// <summary>
    /// �÷��̾ ���⸦ �߻��ϴ� �޼���
    /// �߻� ������ �����Ͽ� źȯ�� ����
    /// </summary>
    public override void Fire()
    {
        if (Time.time >= lastFireTime + (1f / fireRate))
        {
            Debug.Log("źȯ ����");
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            lastFireTime = Time.time;
        }
    }
}
