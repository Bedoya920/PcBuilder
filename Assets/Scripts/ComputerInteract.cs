using UnityEngine;

public class ComputerInteract : MonoBehaviour
{
    // Asigna en el Inspector el Canvas que contiene la UI de la "página de compras"
    public GameObject pcCanvas;

    // Tecla para interactuar (por defecto, E)
    public KeyCode interactKey = KeyCode.E;

    // Bandera para saber si el jugador está en rango
    private bool playerInRange = false;

    // Se llama al entrar en el collider trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Jugador en rango. Presiona E para interactuar.");
        }
    }

    // Se llama al salir del collider trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Jugador fuera de rango.");
            // Si el Canvas está activo, lo cerramos al salir
            if (pcCanvas.activeSelf)
            {
                ToggleUI();
            }
        }
    }

    // Se revisa constantemente si se presiona la tecla de interacción
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            ToggleUI();
        }
    }

    // Método para alternar la UI, pausa el juego y controla el cursor
    void ToggleUI()
    {
        bool uiActive = pcCanvas.activeSelf;
        pcCanvas.SetActive(!uiActive);

        if (!uiActive)
        {
            // Se activa la UI: pausa el juego y libera el cursor para interactuar
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Se desactiva la UI: reanuda el juego y bloquea el cursor para el control del jugador
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
