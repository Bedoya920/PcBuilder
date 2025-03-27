using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PcComponents 
{
    public class Procesador
    {
        private string name;
        private GameObject goProcesador;
        private Vector3 pos = new Vector3(0,1,0);

        public Procesador(string n) 
        { 
            name = n; 
            goProcesador = Resources.Load<GameObject>(n);

            if (goProcesador != null)
            {
                GameObject.Instantiate(goProcesador, pos, Quaternion.identity);
            }
        }
    }

    public class Grafica 
    {
        private string name;
        private GameObject goGrafica;
        private Vector3 pos = new Vector3(0,0.2f,0);

        public Grafica(string n) 
        { 
            name = n; 
            goGrafica = Resources.Load<GameObject>(n);

            if (goGrafica != null)
            {
                GameObject.Instantiate(goGrafica, pos, Quaternion.identity);
            } else {
                Debug.LogError("Aja y el prefab que papi?");
            }
        }
    }
}
