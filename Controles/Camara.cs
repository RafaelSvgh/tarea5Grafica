using OpenTK;
using OpenTK.Input;

namespace Tarea5Graf.Controles;

public class Camara
{
    public Vector3 Posicion { get; private set; }
    public Vector3 Objetivo { get; private set; }
    public Vector3 Arriba { get; private set; }
    public float Distancia { get; private set; }
    public float AnguloX { get; private set; }
    public float AnguloY { get; private set; }

    private Vector2 _lastMousePos;
    public float MouseSensitivity { get; set; } = 5;
    public float ScrollSensitivity { get; set; } = 1;

    public Matrix4 Vista;
    public Matrix4 Proyeccion;

    public Camara(float anchoVentana, float altoVentana)
    {
        Distancia = 5.0f;
        AnguloX = 0.0f;
        AnguloY = 0.0f;
        Objetivo = Vector3.Zero;
        Arriba = Vector3.UnitY;

        ActualizarMatrices(anchoVentana, altoVentana);
    }

    public void ActualizarMatrices(float anchoVentana, float altoVentana)
    {
        Posicion = new Vector3(
            (float)(Distancia * Math.Sin(MathHelper.DegreesToRadians(AnguloY)) *
                    Math.Cos(MathHelper.DegreesToRadians(AnguloX))),
            (float)(Distancia * Math.Sin(MathHelper.DegreesToRadians(AnguloX))),
            (float)(Distancia * Math.Cos(MathHelper.DegreesToRadians(AnguloY)) *
                    Math.Cos(MathHelper.DegreesToRadians(AnguloX)))
        );

        Vista = Matrix4.LookAt(Posicion, Objetivo, Arriba);
        float aspectRatio = anchoVentana / altoVentana;
        Proyeccion = Matrix4.CreatePerspectiveFieldOfView(
            MathHelper.PiOver4, aspectRatio, 0.1f, 100.0f);
    }

    public void Rotar(float deltaAnguloX, float deltaAnguloY)
    {
        AnguloX += deltaAnguloX;
        AnguloY += deltaAnguloY;
    }

    public void AcercarAlejar(float deltaDistancia)
    {
        Distancia += deltaDistancia;
    }

    public void ProcesarMouse(MouseState mouse, MouseState lastMouse, float deltaTime)
    {
        if (mouse.IsButtonDown(MouseButton.Left))
        {
            var deltaX = lastMouse.X - mouse.X;
            var deltaY = lastMouse.Y - mouse.Y;

            Rotar(deltaY * MouseSensitivity * deltaTime,
                  deltaX * MouseSensitivity * deltaTime);
        }
        var scrollDelta = mouse.ScrollWheelValue - lastMouse.ScrollWheelValue;
        if (scrollDelta != 0)
        {
            AcercarAlejar(-scrollDelta * ScrollSensitivity);
        }
    }
}
