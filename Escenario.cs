using OpenTK.Graphics;

namespace Tarea5Graf;

public class Escenario : IFigura
{
    public Dictionary<string, Objeto> Objetos { get; set; } = new Dictionary<string, Objeto>();
    public Vertice Centro { get; set; } = new Vertice();
    public Color4 ColorDeFondo { get; set; } = Color4.Black;
    public Escenario() { }

    public Escenario(Color4 colorDeFondo)
    {
        ColorDeFondo = colorDeFondo;
        Centro = new Vertice(0, 0, 0);
    }

    public void AddObjeto(string key, Objeto objeto)
    {
        Objetos.Add(key, objeto);
    }

    public void RemoveObjeto(string key)
    {
        Objetos.Remove(key);
    }

    public Objeto GetObjeto(string key)
    {
        return Objetos[key];
    }

    public void Dibujar()
    {
        foreach (Objeto objeto in Objetos.Values)
            objeto.Dibujar();
    }

    public void Rotar(float angX, float angY, float angZ, Vertice? vertice = null)
    {
        Centro = vertice ?? CalcularCentroDeMasa();
        foreach (var obj in Objetos.Values)
            obj.Rotar(angX, angY, angZ, Centro);
    }

    public void Trasladar(float deltaX, float deltaY, float deltaZ)
    {
        foreach (var obj in Objetos.Values)
            obj.Trasladar(deltaX, deltaY, deltaZ);
    }

    public void Escalar(float factor, Vertice? vertice = null)
    {
        Centro = vertice ?? CalcularCentroDeMasa();
        foreach (var obj in Objetos.Values)
            obj.Escalar(factor, Centro);
    }

    public void Reflejar(Vertice plano)
    {
        foreach (var obj in Objetos.Values)
            obj.Reflejar(plano);
    }

    public Vertice CalcularCentroDeMasa()
    {
        float xProm = Objetos.Values.Average(obj => obj.CalcularCentro().X);
        float yProm = Objetos.Values.Average(obj => obj.CalcularCentro().Y);
        float zProm = Objetos.Values.Average(obj => obj.CalcularCentro().Z);
        return new Vertice(xProm, yProm, zProm);
    }

}
