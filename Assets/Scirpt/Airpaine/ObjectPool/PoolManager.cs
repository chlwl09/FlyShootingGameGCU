using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    public GameObject prefab;
    public int defaultCapacity = 20;
    public int maxPoolSize = 50;

    // ObjectPool<GameObject> ���
    private IObjectPool<GameObject> objectPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� ����
        }
        else
        {
            Debug.LogError("PoolManager�� �ߺ��� �ν��Ͻ��� �߰ߵǾ����ϴ�.");
            Destroy(gameObject);
            return;
        }

        if (prefab == null)
        {
            Debug.LogError("PoolManager�� prefab�� �������� �ʾҽ��ϴ�.");
            return;
        }

        // ObjectPool �ʱ�ȭ
        objectPool = new ObjectPool<GameObject>(
            CreatePooledItem,     // ��ü�� �����ϴ� �޼���
            OnTakeFromPool,       // ��ü�� Ǯ���� ���� �޼���
            OnReturnedToPool,     // ��ü�� Ǯ�� ���������� �޼���
            OnDestroyPoolObject,  // ��ü�� Ǯ���� �����ϴ� �޼���
            true,                 // �ڵ� Ȯ�� ����
            defaultCapacity,      // �⺻ Ǯ ũ��
            maxPoolSize           // �ִ� Ǯ ũ��
        );
    }

    // Ǯ���� ����� ��ü ����
    private GameObject CreatePooledItem()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        return obj;
    }

    // Ǯ���� ��ü�� ����� �� ȣ��Ǵ� �޼���
    private void OnTakeFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    // Ǯ�� ��ü�� ��ȯ�� �� ȣ��Ǵ� �޼���
    private void OnReturnedToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    // Ǯ���� ��ü�� ������ �� ȣ��Ǵ� �޼���
    private void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);
    }

    // Ǯ���� ��ü�� ���� ��ȯ
    public GameObject SpawnFromPool(Vector3 position, Quaternion rotation)
    {
        GameObject obj = objectPool.Get(); // Ǯ���� ��ü�� ������
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }

    // ��ü�� Ǯ�� ��ȯ
    public void ReturnToPool(GameObject obj)
    {
        objectPool.Release(obj); // Ǯ�� ��ü ��ȯ
    }
}
