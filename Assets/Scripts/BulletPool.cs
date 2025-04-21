using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int initialPoolSize = 20;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject b = Instantiate(bulletPrefab, transform);
            b.SetActive(false);
            pool.Enqueue(b);
        }
    }

    public GameObject GetBullet(Transform spawnPoint, int id)
    {
        if (pool.Count == 0)
        {
            GameObject extra = Instantiate(bulletPrefab);
            extra.SetActive(false);
            pool.Enqueue(extra);
        }

        GameObject obj = pool.Dequeue();
        var bullet = obj.GetComponent<Bullet>();
        bullet.idPlayer = id;
        obj.transform.position = spawnPoint.position;
        obj.transform.rotation = spawnPoint.rotation;
        obj.transform.SetParent(null);

        var rend = obj.GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = (id == 1) ? Color.blue : Color.yellow;

        obj.SetActive(true);
        return obj;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.SetParent(transform);
        pool.Enqueue(bullet);
    }
}
