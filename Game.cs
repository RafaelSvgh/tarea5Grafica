using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using Tarea5Graf.Controles;
using Tarea5Graf.Serializacion;

namespace Tarea5Graf;

public class Game : GameWindow
{
    private Camara camara = null!;
    private MouseState _lastMouseState;
    private PlanoCartesiano PlanoCartesiano { get; set; } = new PlanoCartesiano(0.4, 0.10);
    private Escenario escenario = new();
    private IFigura figura = null!;
    private ControladorTeclado controladorTeclado = null!;

    public Game() : base(1000, 1000, GraphicsMode.Default, "Tarea 5 Gráfica"){}

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        camara = new Camara(Width, Height);
        GL.Enable(EnableCap.DepthTest);
        Serializador serializador = new Serializador();
        escenario = serializador.Deserializar<Escenario>("escenario") ?? new Escenario();
        figura = escenario;
        controladorTeclado = new ControladorTeclado(escenario, figura);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref camara.Proyeccion);
        GL.MatrixMode(MatrixMode.Modelview);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.LoadMatrix(ref camara.Vista);
        PlanoCartesiano.Dibujar();
        escenario.Dibujar();
        SwapBuffers();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Width, Height);
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        camara.ProcesarMouse(Mouse.GetState(), _lastMouseState, (float)e.Time);
        camara.ActualizarMatrices(Width, Height);
        _lastMouseState = Mouse.GetState();
        controladorTeclado.ProcesarTeclado(Keyboard.GetState());
    }
}
