using OpenTK.Graphics;

namespace Tarea5Graf;

public class Parte : IFigura
{
    public Dictionary<string, Cara> Caras { get; set; } = new Dictionary<string, Cara>();
    public Vertice Centro { get; set; } = new Vertice();
    public Color4 Color { get; set; }

    public Parte() { }

    public Parte(Dictionary<string, Cara> caras)
    {
        Caras = caras;
        Centro = CalcularCentro();
    }

    public void AddCara(string key, Cara cara)
    {
        Caras.Add(key, cara);
    }

    public void RemoveCara(string key)
    {
        Caras.Remove(key);
    }

    public Cara GetCara(string key)
    {
        return Caras[key];
    }

    public void Dibujar()
    {
        foreach (Cara cara in Caras.Values)
            cara.Dibujar();
    }

    public void Rotar(float angX, float angY, float angZ, Vertice? vertice = null)
    {
        Centro = vertice ?? CalcularCentro();
        foreach (var cara in Caras.Values)
            ((IFigura)cara).Rotar(angX, angY, angZ, Centro);
    }

    public void Trasladar(float deltaX, float deltaY, float deltaZ)
    {
        foreach (var cara in Caras.Values)
            cara.Trasladar(deltaX, deltaY, deltaZ);
    }

    public void Escalar(float factor, Vertice? vertice = null)
    {
        Centro = vertice ?? CalcularCentro();
        foreach (var cara in Caras.Values)
            cara.Escalar(factor, Centro);

    }

    public void Reflejar(Vertice plano)
    {
        foreach (var cara in Caras.Values)
            cara.Reflejar(plano);
    }

    private Vertice CalcularCentro()
    {
        var vertices = Caras.Values.SelectMany(c => c.Vertices.Values).ToList();
        return new Vertice(vertices.Average(v => v.X), vertices.Average(v => v.Y), vertices.Average(v => v.Z));
    }

}
