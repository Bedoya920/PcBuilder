using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PcComponents;

namespace PcBuilder
{
    public class PC
    {
        public Chasis Chasis { get; set; }
        public Pantalla Pantalla { get; set; }

        public void DestroyComponents()
        {
            Chasis?.Destroy();
            Pantalla?.Destroy();
        }

    }

    public class PcDirector
    {
        public PC BuildPC(PcBuilderBase builder, string chasis, string pantalla, Transform posChasis, Transform posPantalla)
        {
            builder.Reset();
            builder.SetChasis(chasis, posChasis);
            builder.SetPantalla(pantalla, posPantalla);
            return builder.GetResult();
        }
    }

    public abstract class PcBuilderBase 
    {
        protected PC pc;
        public void Reset()
        {
            if(pc != null)
            {
                pc.DestroyComponents();
            }
            pc = new PC();
        } 
        public abstract void SetChasis(string tipo, Transform pos);
        public abstract void SetPantalla(string tipo, Transform pos);
        public PC GetResult() => pc;
    }

    public class CustomPCBuilder : PcBuilderBase
    {
        public override void SetChasis(string tipo, Transform pos) => pc.Chasis = new Chasis(tipo, pos);
        public override void SetPantalla(string tipo, Transform pos) => pc.Pantalla = new Pantalla(tipo, pos);
    
    }

}
