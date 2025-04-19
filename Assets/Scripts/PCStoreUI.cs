using System.Collections.Generic;
using UnityEngine;
using TMPro;               // Usamos TextMesh Pro para los dropdowns
using UnityEngine.UI;
using PcBuilder;

public class PCStoreUI : MonoBehaviour
{
    // Referencias a los elementos de la UI (dropdowns y botón)
    public TMP_Dropdown chasisDropdown;
    public TMP_Dropdown pantallaDropdown;
    public Button crearPCButton;

    // Variables del patrón Builder
    private PcDirector director;
    private PcBuilderBase builder;

    // Posiciones donde se instanciarán los componentes en la escena
    [SerializeField] private Transform posChasis;
    [SerializeField] private Transform posPantalla;

    // Audio de confirmación de compra
    [SerializeField] private AudioSource compraSfx;

    void Start()
    {
        // Inicializamos el director y el builder
        director = new PcDirector();
        builder = new CustomPCBuilder();

        // Configuración de las opciones de los dropdowns
        // El primer elemento es un placeholder para forzar una selección válida.
        List<string> opcionesChasis = new List<string> { "Selecciona Chasis", "Chasis Gamma Baja", "Chasis Gamma Media", "Chasis Gamma Alta" };
        List<string> opcionesPantalla = new List<string> { "Selecciona Pantalla", "Pantalla Gamma Baja", "Pantalla Gamma Media", "Pantalla Gamma Alta" };

        chasisDropdown.ClearOptions();
        chasisDropdown.AddOptions(opcionesChasis);

        pantallaDropdown.ClearOptions();
        pantallaDropdown.AddOptions(opcionesPantalla);

        // Se agregan listeners para detectar cambios en las opciones y mostrar/ocultar el botón
        chasisDropdown.onValueChanged.AddListener(delegate { CheckDropdownSelections(); });
        pantallaDropdown.onValueChanged.AddListener(delegate { CheckDropdownSelections(); });

        // Ocultamos el botón hasta que se seleccionen opciones válidas
        crearPCButton.gameObject.SetActive(false);

        // Asociamos la acción de crear el PC al botón
        crearPCButton.onClick.AddListener(ConstruirPC);
    }

    // Comprueba si ambos dropdowns tienen una selección válida (índice mayor a 0)
    void CheckDropdownSelections()
    {
        if (chasisDropdown.value > 0 && pantallaDropdown.value > 0)
        {
            crearPCButton.gameObject.SetActive(true);
        }
        else
        {
            crearPCButton.gameObject.SetActive(false);
        }
    }

    // Método que se ejecuta al pulsar el botón para construir el PC
    void ConstruirPC()
    {
        // Se obtienen las opciones seleccionadas
        string chasisSeleccionado = chasisDropdown.options[chasisDropdown.value].text;
        string pantallaSeleccionada = pantallaDropdown.options[pantallaDropdown.value].text;

        // Se utiliza el director del patrón Builder para construir el PC
        // El director orquesta la llamada a los métodos del builder en el orden correcto
        PC pc = director.BuildPC(builder, chasisSeleccionado, pantallaSeleccionada, posChasis, posPantalla);

        // Reproduce un sonido de confirmación
        compraSfx.Play();
        Debug.Log("PC construido: " + chasisSeleccionado + " y " + pantallaSeleccionada);
    }
}
