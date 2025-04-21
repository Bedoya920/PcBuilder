using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public int idPlayer;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        BulletPool.Instance.ReturnBullet(gameObject);
    }
}
