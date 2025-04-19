using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public int idPlayer;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        print("Hola");
        BulletPool.Instance.ReturnBullet(this.gameObject);
    }
}
