using System.Collections.Generic;
using UnityEngine;
using TMPro;               
using UnityEngine.UI;
using PcBuilder;

public class PCStoreUI : MonoBehaviour
{
    // UI
    public TMP_Dropdown chasisDropdown;
    public TMP_Dropdown pantallaDropdown;
    public Button crearPCButton;

    //Builder
    private PcDirector director;
    private PcBuilderBase builder;

    [SerializeField] private Transform posChasis;
    [SerializeField] private Transform posPantalla;

    [SerializeField] private AudioSource compraSfx;

    void Start()
    {
        director = new PcDirector();
        builder = new CustomPCBuilder();

        // Configurar los TMP_Dropdown con las opciones disponibles.
        // La primera opci�n es un placeholder para forzar la selecci�n.
        List<string> opcionesChasis = new List<string> { "Selecciona Chasis", "Chasis Gamma Baja", "Chasis Gamma Media", "Chasis Gamma Alta" };
        List<string> opcionesPantalla = new List<string> { "Selecciona Pantalla", "Pantalla Gamma Baja", "Pantalla Gamma Media", "Pantalla Gamma Alta" };

        chasisDropdown.ClearOptions();
        chasisDropdown.AddOptions(opcionesChasis);

        pantallaDropdown.ClearOptions();
        pantallaDropdown.AddOptions(opcionesPantalla);

        // Agregar listeners para detectar cambios en los dropdown y verificar que se hayan seleccionado opciones v�lidas.
        chasisDropdown.onValueChanged.AddListener(delegate { CheckDropdownSelections(); });
        pantallaDropdown.onValueChanged.AddListener(delegate { CheckDropdownSelections(); });

        // Inicialmente, el bot�n de crear PC se oculta hasta que se marquen ambas opciones.
        crearPCButton.gameObject.SetActive(false);

        // Asociar la acci�n del bot�n para construir el PC.
        crearPCButton.onClick.AddListener(ConstruirPC);
    }

    // Verifica si ambos dropdowns tienen una opci�n v�lida seleccionada (�ndice mayor a 0).
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

    // Se ejecuta al presionar el bot�n para construir el PC.
    void ConstruirPC()
    {
        string chasisSeleccionado = chasisDropdown.options[chasisDropdown.value].text;
        string pantallaSeleccionada = pantallaDropdown.options[pantallaDropdown.value].text;

        // Usar el director para construir el PC con las especificaciones seleccionadas.
        PC pc = director.BuildPC(builder, chasisSeleccionado, pantallaSeleccionada, posChasis, posPantalla);
        compraSfx.Play();
        Debug.Log("PC construido: " + chasisSeleccionado + " y " + pantallaSeleccionada);
    }
}
