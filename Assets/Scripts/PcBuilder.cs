using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PcComponents;

namespace PcBuilder
{
    public class PC
    {
        public Procesador Procesador { get; set; }
        public Grafica Grafica { get; set; }

    }

    public class PcDirector
    {
        public PC BuildPC(PcBuilderBase builder, string proces, string graf)
        {
            builder.Reset();
            builder.SetProcesador(proces);
            builder.SetGrafica(graf);
            return builder.GetResult();
        }
    }

    public abstract class PcBuilderBase 
    {
        protected PC pc;
        public void Reset() => pc = new PC();
        public PC GetResult() => pc;
        
        public abstract void SetProcesador(string tipo);
        public abstract void SetGrafica(string tipo);
    }

    public class CustomPCBuilder : PcBuilderBase
    {
        public override void SetProcesador(string tipo) => pc.Procesador = new Procesador(tipo);
        public override void SetGrafica(string tipo) => pc.Grafica = new Grafica(tipo);
    
    }
}
