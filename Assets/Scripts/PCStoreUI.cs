using System.Collections.Generic;
using UnityEngine;
using TMPro;               // Para usar TMP_Dropdown
using UnityEngine.UI;
using PcBuilder;

public class PCStoreUI : MonoBehaviour
{
    // Referencias a los componentes UI creados en el Canvas usando TextMesh Pro para los dropdown
    public TMP_Dropdown chasisDropdown;
    public TMP_Dropdown pantallaDropdown;
    public Button crearPCButton;

    // Director y builder del patrón
    private PcDirector director;
    private PcBuilderBase builder;

    void Start()
    {
        // Inicializamos el director y el builder (asegúrate de que estos métodos se hayan actualizado para chasis y pantalla)
        director = new PcDirector();
        builder = new CustomPCBuilder();

        // Configurar los TMP_Dropdown con las opciones disponibles.
        // La primera opción es un placeholder para forzar la selección.
        List<string> opcionesChasis = new List<string> { "Selecciona Chasis", "Chasis Gamma Baja", "Chasis Gamma Media", "Chasis Gamma Alta" };
        List<string> opcionesPantalla = new List<string> { "Selecciona Pantalla", "Pantalla Gamma Baja", "Pantalla Gamma Media", "Pantalla Gamma Alta" };

        chasisDropdown.ClearOptions();
        chasisDropdown.AddOptions(opcionesChasis);

        pantallaDropdown.ClearOptions();
        pantallaDropdown.AddOptions(opcionesPantalla);

        // Agregar listeners para detectar cambios en los dropdown y verificar que se hayan seleccionado opciones válidas.
        chasisDropdown.onValueChanged.AddListener(delegate { CheckDropdownSelections(); });
        pantallaDropdown.onValueChanged.AddListener(delegate { CheckDropdownSelections(); });

        // Inicialmente, el botón de crear PC se oculta hasta que se marquen ambas opciones.
        crearPCButton.gameObject.SetActive(false);

        // Asociar la acción del botón para construir el PC.
        crearPCButton.onClick.AddListener(ConstruirPC);
    }

    // Verifica si ambos dropdowns tienen una opción válida seleccionada (índice mayor a 0).
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

    // Se ejecuta al presionar el botón para construir el PC.
    void ConstruirPC()
    {
        string chasisSeleccionado = chasisDropdown.options[chasisDropdown.value].text;
        string pantallaSeleccionada = pantallaDropdown.options[pantallaDropdown.value].text;

        // Usar el director para construir el PC con las especificaciones seleccionadas.
        PC pc = director.BuildPC(builder, chasisSeleccionado, pantallaSeleccionada);
        Debug.Log("PC construido: " + chasisSeleccionado + " y " + pantallaSeleccionada);
    }
}
