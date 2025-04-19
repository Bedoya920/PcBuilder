using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PcComponents;

namespace PcBuilder
{
    // Clase que representa el PC a construir, compuesto de un chasis y una pantalla.
    public class PC
    {
        public Chasis Chasis { get; set; }
        public Pantalla Pantalla { get; set; }

        // Método para destruir los componentes existentes (útil al reiniciar la construcción)
        public void DestroyComponents()
        {
            Chasis?.Destroy();
            Pantalla?.Destroy();
        }
    }

    // El Director es responsable de definir el orden de construcción.
    // Recibe un builder concreto y le pasa las especificaciones junto con las posiciones donde instanciar.
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

    // Clase abstracta que define la interfaz del Builder.
    // Aquí se especifican los métodos para crear cada componente del PC.
    public abstract class PcBuilderBase
    {
        protected PC pc;

        // Reinicia el builder. Si ya hay un PC en construcción, destruye sus componentes.
        public void Reset()
        {
            if (pc != null)
            {
                pc.DestroyComponents();
            }
            pc = new PC();
        }

        // Métodos abstractos que deberán implementarse en el builder concreto.
        public abstract void SetChasis(string tipo, Transform pos);
        public abstract void SetPantalla(string tipo, Transform pos);

        // Retorna el PC construido.
        public PC GetResult() => pc;
    }

    // Implementación concreta del builder.
    // Se encarga de crear el chasis y la pantalla utilizando los prefabs correspondientes.
    public class CustomPCBuilder : PcBuilderBase
    {
        public override void SetChasis(string tipo, Transform pos) => pc.Chasis = new Chasis(tipo, pos);
        public override void SetPantalla(string tipo, Transform pos) => pc.Pantalla = new Pantalla(tipo, pos);
    }
}
