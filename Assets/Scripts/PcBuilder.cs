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
        public PC BuildPC(PcBuilderBase builder)
        {
            builder.Reset();
            builder.SetProcesador();
            builder.SetGrafica();
            return builder.GetResult();
        }
    }

    public abstract class PcBuilderBase 
    {
        protected PC pc;
        public void Reset() => pc = new PC();
        public PC GetResult() => pc;
        
        public abstract void SetProcesador();
        public abstract void SetGrafica();
    }

    public class BajaPCBuilder : PcBuilderBase
    {
        public override void SetProcesador() => pc.Procesador = new Procesador("ProcesadorBaja");
        public override void SetGrafica() => pc.Grafica = new Grafica("GraficaBaja");
    
    }
}
