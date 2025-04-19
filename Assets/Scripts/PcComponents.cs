using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PcComponents
{
    // Clase que representa el chasis del PC.
    // Carga el prefab desde Resources y lo instancia en la posición y rotación que recibe.
    public class Chasis
    {
        private string name;
        private GameObject goChasis;
        internal GameObject ins;  // Referencia a la instancia creada en la escena

        public Chasis(string n, Transform pos)
        {
            name = n;
            goChasis = Resources.Load<GameObject>(n);

            if (goChasis != null)
            {
                // Instancia el prefab en la posición y rotación del Transform pasado
                ins = GameObject.Instantiate(goChasis, pos.position, pos.rotation);
            }
            else
            {
                Debug.LogError("Aja y el prefab que papi?");
            }
        }

        // Método para destruir la instancia en la escena
        public void Destroy()
        {
            if (ins != null)
            {
                GameObject.Destroy(ins);
            }
        }
    }

    // Clase que representa la pantalla del PC.
    // Funciona de manera similar al chasis, cargando e instanciando el prefab.
    public class Pantalla
    {
        private string name;
        private GameObject goPantalla;
        internal GameObject ins;

        public Pantalla(string n, Transform pos)
        {
            name = n;
            goPantalla = Resources.Load<GameObject>(n);

            if (goPantalla != null)
            {
                // Instancia el prefab en la posición y rotación del Transform recibido
                ins = GameObject.Instantiate(goPantalla, pos.position, pos.rotation);
            }
            else
            {
                Debug.LogError("Aja y el prefab que papi?");
            }
        }

        // Destruye la instancia de la pantalla en la escena
        public void Destroy()
        {
            if (ins != null)
            {
                GameObject.Destroy(ins);
            }
        }
    }
}
