using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea5Graf;

public class Objeto :IFigura
{
    public Dictionary<string, Parte> Partes { get; set; } = new Dictionary<string, Parte>();
    public Vertice Centro { get; set; } = new Vertice();
    public Color4 Color { get; set; }

    public Objeto(Dictionary<string, Parte> partes, Vertice centro)
    {
        Partes = partes;
        Centro = CalcularCentro();
    }
    public Objeto() { }

    public void AddParte(string key, Parte parte)
    {
        Partes.Add(key, parte);
    }

    public void RemoveParte(string key)
    {
        Partes.Remove(key);
    }

    public Parte GetParte(string key)
    {
        return Partes[key];
    }

    public void Dibujar()
    {
        foreach (Parte parte in Partes.Values)
            parte.Dibujar();
    }

    public void Rotar(float angX, float angY, float angZ, Vertice? centro = null)
    {
        Centro = centro ?? CalcularCentro();
        foreach (var parte in Partes.Values)
            parte.Rotar(angX, angY, angZ, Centro);
    }

    public void Trasladar(float deltaX, float deltaY, float deltaZ)
    {
        foreach (var parte in Partes.Values)
            parte.Trasladar(deltaX, deltaY, deltaZ);
    }

    public void Escalar(float factor, Vertice? vertice = null)
    {
        Centro = vertice ?? CalcularCentro();
        foreach (var parte in Partes.Values)
            parte.Escalar(factor, Centro);
    }

    public void Reflejar(Vertice plano)
    {
        foreach (var parte in Partes.Values)
            parte.Reflejar(plano);
    }

    public Vertice CalcularCentro()
    {
        var vertices = Partes.Values.SelectMany(p => p.Caras.Values)
                                    .SelectMany(c => c.Vertices.Values).ToList();
        return new Vertice(vertices.Average(v => v.X), vertices.Average(v => v.Y), vertices.Average(v => v.Z));
    }
}
