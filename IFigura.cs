using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea5Graf
{
    public interface IFigura
    {
        Vertice Centro { get; set; }
        public void Dibujar();
        public void Rotar(float angX, float angY, float angZ, Vertice? vertice = null);
        public void Trasladar(float deltaX, float deltaY, float deltaZ);
        public void Escalar(float factor, Vertice? vertice = null);
        public void Reflejar(Vertice plano);
    }
}
