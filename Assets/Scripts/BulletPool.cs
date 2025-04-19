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
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab,transform);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(Transform spawnPoint, int id)
    {
        if (pool.Count == 0)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }

        GameObject obj = pool.Dequeue();
        obj.GetComponent<Bullet>().idPlayer = id;
        obj.transform.position = spawnPoint.position;
        obj.transform.rotation = spawnPoint.rotation;
        obj.transform.SetParent(null);

        Renderer bulletRenderer = obj.GetComponent<Renderer>();
        if (bulletRenderer != null)
        {
            if (id == 1)
            {
                bulletRenderer.material.color = Color.blue; 
            }
            else if (id == 2)
            {
                bulletRenderer.material.color = Color.yellow; 
            }
        }
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
