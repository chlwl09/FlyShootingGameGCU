using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 20.0f;
    public float maxDistance = 100f; // �ִ� �̵� �Ÿ�
    public int bulletDamage = 10;    // źȯ�� ������

    private Vector3 initialPosition;

    void OnEnable()
    {
        initialPosition = transform.position; // Ȱ��ȭ�� �� �ʱ� ��ġ ����
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        // źȯ�� �ִ� �Ÿ� �̻� �̵��ߴ��� Ȯ��
        if (Vector3.Distance(initialPosition, transform.position) >= maxDistance)
        {
            Deactivate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ApplyDamageOnCollision(other);
        PoolManager.Instance.ReturnToPool(gameObject); // źȯ�� Ǯ�� ��ȯ
    }

    private void ApplyDamageOnCollision(Collider other)
    {
        // �浹�� ��ü�� AirplaneBase�� ����ϴ��� Ȯ��
        AirplaneBase target = other.GetComponent<AirplaneBase>();
        if (target != null)
        {
            target.TakeDamage(bulletDamage); // ������ ����
        }
    }

    private void Deactivate()
    {
        PoolManager.Instance.ReturnToPool(gameObject); // �ִ� �̵� �� ��Ȱ��ȭ
    }
}
