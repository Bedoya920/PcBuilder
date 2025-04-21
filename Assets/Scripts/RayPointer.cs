using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RayPointer : MonoBehaviour
{
    [Tooltip("Transform desde donde sale el rayo (weaponPivot)")]
    public Transform origin;
    [Tooltip("Longitud del rayo")]
    public float length = 20f;

    private LineRenderer lr;

    private void Awake()
    {
        // Añade y configura el LineRenderer
        lr = gameObject.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.widthMultiplier = 0.02f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = lr.endColor = Color.red;
    }

    private void Update()
    {
        Vector3 start = origin.position;
        Vector3 end   = start + origin.forward * length;

        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
}
