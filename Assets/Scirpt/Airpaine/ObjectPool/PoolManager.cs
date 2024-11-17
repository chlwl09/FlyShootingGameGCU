using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    public GameObject prefab;
    public int defaultCapacity = 20;
    public int maxPoolSize = 50;

    // ObjectPool<GameObject> 사용
    private IObjectPool<GameObject> objectPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지
        }
        else
        {
            Debug.LogError("PoolManager의 중복된 인스턴스가 발견되었습니다.");
            Destroy(gameObject);
            return;
        }

        if (prefab == null)
        {
            Debug.LogError("PoolManager의 prefab이 설정되지 않았습니다.");
            return;
        }

        // ObjectPool 초기화
        objectPool = new ObjectPool<GameObject>(
            CreatePooledItem,     // 객체를 생성하는 메서드
            OnTakeFromPool,       // 객체를 풀에서 빼는 메서드
            OnReturnedToPool,     // 객체를 풀로 돌려보내는 메서드
            OnDestroyPoolObject,  // 객체를 풀에서 삭제하는 메서드
            true,                 // 자동 확장 여부
            defaultCapacity,      // 기본 풀 크기
            maxPoolSize           // 최대 풀 크기
        );
    }

    // 풀에서 사용할 객체 생성
    private GameObject CreatePooledItem()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        return obj;
    }

    // 풀에서 객체를 사용할 때 호출되는 메서드
    private void OnTakeFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    // 풀로 객체를 반환할 때 호출되는 메서드
    private void OnReturnedToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    // 풀에서 객체를 삭제할 때 호출되는 메서드
    private void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);
    }

    // 풀에서 객체를 빼서 반환
    public GameObject SpawnFromPool(Vector3 position, Quaternion rotation)
    {
        GameObject obj = objectPool.Get(); // 풀에서 객체를 가져옴
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }

    // 객체를 풀로 반환
    public void ReturnToPool(GameObject obj)
    {
        objectPool.Release(obj); // 풀로 객체 반환
    }
}
