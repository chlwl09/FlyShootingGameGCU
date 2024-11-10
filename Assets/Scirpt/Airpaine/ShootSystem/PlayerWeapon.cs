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

    /// <summary>
    /// �÷��̾ ���⸦ �߻��ϴ� �޼���
    /// �߻� ������ �����Ͽ� źȯ�� ����
    /// </summary>
    public override void Fire()
    {
        if (Time.time >= lastFireTime + (1f / fireRate))
        {
            // ������ ��ġ�� ȸ�� �������� źȯ�� �����մϴ�.
            Instantiate(bulletPrefab, transform.position, transform.rotation);

            // ������ �߻� �ð��� ���� �ð����� ������Ʈ�մϴ�.
            lastFireTime = Time.time;
        }
    }
}
