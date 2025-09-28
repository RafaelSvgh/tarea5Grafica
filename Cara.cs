using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Tarea5Graf;

public class Cara : IFigura
{
    public Dictionary<string, Vertice> Vertices { get; set; } = new Dictionary<string, Vertice>();
    public Vertice Centro { get; set; } = new Vertice();
    public Color4 Color { get; set; }

    public Cara() { }

    public Cara(Dictionary<string, Vertice> vertices, Color4 color)
    {
        Vertices = vertices;
        Color = color;
    }

    public void AddVertice(string key, Vertice vertice)
    {
        Vertices.Add(key, vertice);
    }

    public void RemoveVertice(string key)
    {
        Vertices.Remove(key);
    }

    public Vertice GetVertice(string key)
    {
        return Vertices[key];
    }

    public void Dibujar()
    {
        GL.Begin(PrimitiveType.Polygon);
        GL.Color4(Color);
        foreach (var vertice in Vertices.Values)
        {
            GL.Vertex3(vertice.X, vertice.Y, vertice.Z);
        }
        GL.End();
    }

    public void Trasladar(float posX, float posY, float posZ)
    {
        Matrix4 traslacion = Matrix4.CreateTranslation(posX, posY, posZ);
        TransformarPuntos(traslacion);
        CalcularCentro();
    }

    public void Escalar(float factor, Vertice vertice)
    {
        Vector3 centro = new(vertice.X, vertice.Y, vertice.Z);
        Matrix4 transformacion =
            Matrix4.CreateTranslation(-centro) *
            Matrix4.CreateScale(factor) *
            Matrix4.CreateTranslation(centro);
        TransformarPuntos(transformacion);
    }

    public void Rotar(float angX, float angY, float angZ, Vertice vertice)
    {
        Vector3 centro = new(vertice.X, vertice.Y, vertice.Z);
        Matrix4 rotacion = Matrix4.CreateTranslation(-centro) *
            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(angZ)) *
            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(angY)) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angX)) *
            Matrix4.CreateTranslation(centro);
        TransformarPuntos(rotacion);
    }

    public void TransformarPuntos(Matrix4 matrix)
    {
        foreach(var key in Vertices.Keys.ToList())
        {
            Vertice v = Vertices[key];
            Vector4 vertice = Vector4.Transform(new Vector4(v.X, v.Y,v.Z,1), matrix);
            Vertices[key] = new Vertice(vertice.X, vertice.Y, vertice.Z);
        }
    }

    public void CalcularCentro()
    {
        Centro = new Vertice(
            Vertices.Values.Average(v=> v.X),
            Vertices.Values.Average(v=> v.Y),
            Vertices.Values.Average(v=> v.Z)
        );
    }

    public void Reflejar(Vertice plano)
    {
        //obj.reflejar(0,0,0.02f)
        Vector3 escala = new(
            plano.X != 0 ? -1 : 1,
            plano.Y != 0 ? -1 : 1,
            plano.Z != 0 ? -1 : 1
        );
        Vector3 traslacion = new(plano.X, plano.Y, plano.Z);
        var reflexion = Matrix4.CreateTranslation(-traslacion)
                       * Matrix4.CreateScale(escala)
                       * Matrix4.CreateTranslation(traslacion);
        TransformarPuntos(reflexion);
        CalcularCentro();
    }


}
