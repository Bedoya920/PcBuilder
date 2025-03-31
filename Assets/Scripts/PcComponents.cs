using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PcComponents 
{
    public class Chasis
    {
        private string name;
        private GameObject goChasis;
        internal GameObject ins;

        public Chasis(string n, Transform pos) 
        { 
            name = n; 
            goChasis = Resources.Load<GameObject>(n);

            if (goChasis != null)
            {
                ins = GameObject.Instantiate(goChasis, pos.position, pos.rotation);
            } else {
                Debug.LogError("Aja y el prefab que papi?");
            }
        }

        public void Destroy()
        {
            if (ins != null)
            {
                GameObject.Destroy(ins);
            }
        }
    }

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
                ins = GameObject.Instantiate(goPantalla, pos.position, pos.rotation);
            } else {
                Debug.LogError("Aja y el prefab que papi?");
            }
        }

        public void Destroy()
        {
            if (ins != null)
            {
                GameObject.Destroy(ins);
            }
        }
    }
}
