using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [Header("Configuración de disparo")]
    [SerializeField] private Transform pivot;
    [SerializeField, Tooltip("1 o 2")]        private int playerId;
    [SerializeField, Tooltip("Ej: \"<Mouse>/leftButton\"")] 
    private string bindingPath;

    private InputAction fireAction;

    private void Awake()
    {
        fireAction = new InputAction($"Fire_P{playerId}", binding: bindingPath);
        fireAction.performed += _ => Shoot();
    }

    private void OnEnable()  => fireAction.Enable();
    private void OnDisable() => fireAction.Disable();

    private void Shoot()
    {
        BulletPool.Instance.GetBullet(pivot, playerId);
    }
}
