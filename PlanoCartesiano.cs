using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
namespace Tarea5Graf;

public class PlanoCartesiano
{
    public double escala;
    public double width;

    public PlanoCartesiano(double escala = 1, double width = 10)
    {
        this.escala = escala;
        this.width = width;
    }

    public PlanoCartesiano() { }

    public void Dibujar()
    {
        PrimitiveType tipo = PrimitiveType.LineLoop;

        GL.Begin(tipo);
        GL.Color4(Color4.Red);
        GL.Vertex3(4.0, 0.0, 0.0);
        GL.Vertex3(-4.0, 0.0, 0.0);
        GL.End();

        for (double i = -4.0; i <= 4.0; i += escala)
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(Color4.Red);
            GL.Vertex3(i, -width, 0.0);
            GL.Vertex3(i, width, 0.0);
            GL.End();
        }

        GL.Begin(tipo);
        GL.Color4(Color4.Green);
        GL.Vertex3(0.0, 4.0, 0.0);
        GL.Vertex3(0.0, -4.0, 0.0);
        GL.End();

        for (double i = -4.0; i <= 4.0; i += escala)
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(Color4.Green);
            GL.Vertex3(-width, i, 0.0);
            GL.Vertex3(width, i, 0.0);
            GL.End();
        }

        GL.Begin(tipo);
        GL.Color4(Color4.Blue);
        GL.Vertex3(0.0, 0.0, 4.0);
        GL.Vertex3(0.0, 0.0, -4.0);
        GL.End();

        for (double i = -4.0; i <= 4.0; i += escala)
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(Color4.Blue);
            GL.Vertex3(0.0, -width, i);
            GL.Vertex3(0.0, width, i);
            GL.End();
        }
    }
}
