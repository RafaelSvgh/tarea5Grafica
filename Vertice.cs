using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea5Graf;

public class Vertice
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vertice(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    public Vertice() { }

}