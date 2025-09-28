using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea5Graf.Controles;

public class ControladorTeclado
{
    private IFigura figura;
    private Escenario escenario1;
    private bool modoRotacion, modoEscalacion, modoTraslacion, modoReflexion;

    public ControladorTeclado(Escenario escenario1,IFigura figura)
    {
        this.escenario1 = escenario1;
        this.figura = figura;
    }

    public void ProcesarTeclado(KeyboardState keyboard)
    {
        if (keyboard.IsKeyDown(Key.R))
        {
            modoRotacion = true;
            modoEscalacion = false;
            modoTraslacion = false;
            modoReflexion = false;
            System.Threading.Thread.Sleep(200);
        }
        if (keyboard.IsKeyDown(Key.E))
        {
            modoEscalacion = true;
            modoRotacion = false;
            modoTraslacion = false;
            modoReflexion = false;
            System.Threading.Thread.Sleep(200);
        }
        if (keyboard.IsKeyDown(Key.T))
        {
            modoEscalacion = false;
            modoRotacion = false;
            modoTraslacion = true;
            modoReflexion = false;
            System.Threading.Thread.Sleep(200);
        }
        if (keyboard.IsKeyDown(Key.F))
        {
            modoEscalacion = false;
            modoRotacion = false;
            modoTraslacion = false;
            modoReflexion= true;
            System.Threading.Thread.Sleep(200);
        }

        if (keyboard[Key.Number0])
            figura = escenario1;
        if (keyboard[Key.Number1])
            figura = escenario1.GetObjeto("monitor")!;
        if (keyboard[Key.Number2])
            figura = escenario1.GetObjeto("teclado")!;
        if (keyboard[Key.Number3])
            figura = escenario1.GetObjeto("gabinete");
        if (keyboard[Key.Number4])
            figura = escenario1.GetObjeto("monitor")!.GetParte("monitor")!;
        if (keyboard[Key.Number5])
            figura = escenario1.GetObjeto("monitor")!.GetParte("baseMonitor")!;
        if (keyboard[Key.Number6])
            figura = escenario1.GetObjeto("monitor")!.GetParte("baseMonitor2")!;
        if (keyboard[Key.Number7])
            figura = escenario1.GetObjeto("teclado")!.GetParte("teclado")!;
        if (keyboard[Key.Number8])
            figura = escenario1.GetObjeto("teclado")!.GetParte("reposador")!;
        if (keyboard[Key.Number9])
            figura = escenario1.GetObjeto("gabinete")!.GetParte("gabinete")!;

        if (modoRotacion)
        {
            if (keyboard[Key.Down]) figura.Rotar(1, 0, 0);
            if (keyboard[Key.Up]) figura.Rotar(-1, 0, 0);
            if (keyboard[Key.Right]) figura.Rotar(0, 1, 0);
            if (keyboard[Key.Left]) figura.Rotar(0, -1, 0);
            if (keyboard[Key.X]) figura.Rotar(0, 0, 1);
            if (keyboard[Key.Z]) figura.Rotar(0, 0, -1);
        }

        if (modoEscalacion)
        {
            if (keyboard[Key.Up]) figura.Escalar(1.01f);
            if (keyboard[Key.Down]) figura.Escalar(0.99f);
        }

        if (modoTraslacion)
        {
            if (keyboard[Key.Up]) figura.Trasladar(0, 0.01f, 0);
            if (keyboard[Key.Down]) figura.Trasladar(0, -0.01f, 0);
            if (keyboard[Key.Left]) figura.Trasladar(-0.01f, 0, 0);
            if (keyboard[Key.Right]) figura.Trasladar(0.01f, 0, 0);
            if (keyboard[Key.Z]) figura.Trasladar(0, 0, -0.01f);
            if (keyboard[Key.X]) figura.Trasladar(0, 0, 0.01f);
        }

        if (modoReflexion)
        {
            if (keyboard.IsKeyDown(Key.Up))
            {
                figura.Reflejar(new Vertice(0.03f, 0, 0));
                System.Threading.Thread.Sleep(200);
            }
            if (keyboard.IsKeyDown(Key.Down))
            {
                figura.Reflejar(new Vertice(0, 0.03f, 0));
                System.Threading.Thread.Sleep(200);
            }
            if (keyboard.IsKeyDown(Key.Right))
            {
                figura.Reflejar(new Vertice(0, 0, 0.03f));
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}
