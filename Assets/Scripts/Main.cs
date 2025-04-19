using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PcBuilder;

public class Main : MonoBehaviour
{
    // Ejemplo de uso del patr�n Builder con el director y el builder.
    PcDirector director = new PcDirector();
    PcBuilderBase builderBaja = new CustomPCBuilder();

    public Transform pos;  // Posici�n para instanciar componentes, si es necesario

    void Start()
    {
    }
}
