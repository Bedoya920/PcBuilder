using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public Transform pivot; // Transform desde donde se dispararán las balas
    private InputAction fireAction;
    public int ude;

    private void Awake()
    {
        // Crea una nueva acción de entrada para el clic izquierdo del mouse
        fireAction = new InputAction("Fire", binding: "<Mouse>/leftButton");
        fireAction.performed += ctx => Shoot(); // Suscribirse al evento de acción
    }

    private void OnEnable()
    {
        fireAction.Enable(); // Habilitar la acción
    }

    private void OnDisable()
    {
        fireAction.Disable(); // Deshabilitar la acción
    }

    private void Shoot()
    {
       
        BulletPool.Instance.GetBullet(pivot, ude); 
    }
}