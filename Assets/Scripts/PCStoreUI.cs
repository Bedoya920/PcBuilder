using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PcBuilder;

public class PCStoreUI : MonoBehaviour
{
    // Referencias a los componentes UI creados en el Canvas
    public Dropdown procesadorDropdown;
    public Dropdown graficaDropdown;
    public Button construirButton;

    // Director y builder del patrón
    private PcDirector director;
    private PcBuilderBase builder;

    void Start()
    {
        // Inicializamos el director y el builder (usa el builder que implementa tus componentes)
        director = new PcDirector();
        builder = new CustomPCBuilder();

        // Configurar los Dropdowns con las opciones disponibles
        // Estas opciones deben corresponder con los nombres de los prefabs en Resources.
        List<string> opcionesProcesador = new List<string> { "ProcesadorBaja", "ProcesadorMedia", "ProcesadorAlta" };
        List<string> opcionesGrafica = new List<string> { "GraficaBaja", "GraficaMedia", "GraficaAlta" };

        procesadorDropdown.ClearOptions();
        procesadorDropdown.AddOptions(opcionesProcesador);

        graficaDropdown.ClearOptions();
        graficaDropdown.AddOptions(opcionesGrafica);

        // Asociar la acción del botón para construir el PC
        construirButton.onClick.AddListener(ConstruirPC);
    }

    // Método que se ejecuta al presionar el botón
    void ConstruirPC()
    {
        // Obtener las selecciones actuales de los Dropdowns
        string procesadorSeleccionado = procesadorDropdown.options[procesadorDropdown.value].text;
        string graficaSeleccionada = graficaDropdown.options[graficaDropdown.value].text;

        // Usar el director para construir el PC con las especificaciones seleccionadas
        PC pc = director.BuildPC(builder, procesadorSeleccionado, graficaSeleccionada);
        Debug.Log("PC construido: " + procesadorSeleccionado + " y " + graficaSeleccionada);
    }
}
