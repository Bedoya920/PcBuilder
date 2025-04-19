using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    //Este script es de prueba, solo es para probar la función del disparo. Eliminar despúes de usar

    public Transform pivot; 
    private InputAction fireAction;
    public int ude;

    private void Awake()
    {
        fireAction = new InputAction("Fire", binding: "<Mouse>/leftButton");
        fireAction.performed += ctx => Shoot(); 
    }

    private void OnEnable()
    {
        fireAction.Enable(); 
    }

    private void OnDisable()
    {
        fireAction.Disable(); 
    }

    private void Shoot()
    {
        BulletPool.Instance.GetBullet(pivot, ude); 
    }
}