using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : BaseWeapon
{
    public GameObject bulletPrefab;

    private void Start()
    {
        fireRate = 10f; // �߻� �ӵ��� ����
    }

    private void Update()
    {
        // �����̽��ٸ� ������ �� Fire() �޼��� ȣ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    /// <summary>
    /// �÷��̾ ���⸦ �߻��ϴ� �޼���
    /// �߻� ������ �����Ͽ� źȯ�� ����
    /// </summary>
    public override void Fire()
    {
        if (Time.time >= lastFireTime + (1f / fireRate))
        {
            if (PoolManager.Instance == null)
            {
                Debug.LogError("PoolManager.Instance�� null�Դϴ�. PoolManager�� ���� �����ϴ��� Ȯ��.");
                return;
            }

            Debug.Log("źȯ ����");
            PoolManager.Instance.SpawnFromPool(transform.position, transform.rotation);
            lastFireTime = Time.time;
        }
    }
}
