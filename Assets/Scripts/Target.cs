using UnityEngine;

[DisallowMultipleComponent]
public class Target : MonoBehaviour
{
    public int CurrentOwner { get; private set; } = 0;
    private Renderer rend;

    private void Awake()
    {
        // Solo corre en objetos de la escena (no en assets/materiales)
        if (!gameObject.scene.IsValid()) return;

        // 1) Collider trigger
        var col = GetComponent<Collider>() ?? gameObject.AddComponent<BoxCollider>();
        col.isTrigger = true;

        // 2) Rigidbody kinematic
        var rb = GetComponent<Rigidbody>() ?? gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        // 3) Renderer e instanciación de material
        rend = GetComponent<Renderer>() ?? GetComponentInChildren<Renderer>();
        if (rend != null)
            rend.material = new Material(rend.sharedMaterial);
    }

    private void OnTriggerEnter(Collider other)
    {
        var b = other.GetComponent<Bullet>();
        if (b == null) return;

        CurrentOwner = b.idPlayer;
        if (rend != null)
            rend.material.color = (CurrentOwner == 1) ? Color.blue : Color.yellow;

        Debug.Log($"{name} now owned by Player {CurrentOwner}");
    }
}
