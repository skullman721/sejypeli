using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;


public class Pong : PhysicsGame
{
    Vector nopeusYlos = new Vector (0, 200);
    Vector nopeusAlas = new Vector(0, -200);

    PhysicsObject pallo;

    PhysicsObject maila1;
    PhysicsObject maila2;

    IntMeter pelaajan1Pisteet;
    IntMeter pelaajan2Pisteet;


    public override void Begin()
    {
        LuodaKentta();
        AsetaOhjaimet();
        AloitaPeli();
        LisaaLaskurit();
        // TODO: Kirjoita ohje
        
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");

    }
    PhysicsObject LuoMaila(double x, double y)
    {
        PhysicsObject maila = PhysicsObject.CreateStaticObject(20.0, 100.0);
        maila.Shape = Shape.Rectangle;
        maila.X = x;
        maila.Y = y;
        maila.Restitution = 1.0;
        Add(maila);
        maila.Color = Color.Aquamarine;
        return maila;



    }
    void LisaaLaskurit()
    {
        pelaajan1Pisteet = LuoPisteLaskuri (Screen.Left + 100.0, Screen.Top - 100.0);
        pelaajan2Pisteet = LuoPisteLaskuri(Screen.Right - 100.0, Screen.Top - 100.0);
    }
    IntMeter LuoPisteLaskuri(double x, double y)
    {
        IntMeter laskuri = new IntMeter(0);
        laskuri.MaxValue = 10;
        return laskuri;
        Label naytto = new Label();
        naytto.BindTo(laskuri);
        naytto.X = x;
        naytto.Y = y;
        naytto.TextColor = Color.White;
        naytto.BorderColor = Level.Background.Color;
        naytto.Color = Level.Background.Color;
        Add(naytto);

    }
    void AsetaOhjaimet()
    {
        Keyboard.Listen(Key.A, ButtonState.Down, AsetaNopeus, "Pelaaja 1: Liikuta mailaa ylös", maila1, nopeusYlos);
        Keyboard.Listen(Key.A, ButtonState.Released, AsetaNopeus, null, maila1, Vector.Zero);
        Keyboard.Listen(Key.Z, ButtonState.Down, AsetaNopeus, "Pelaaja 1: Liikuta mailaa alas", maila1, nopeusAlas);
        Keyboard.Listen(Key.Z, ButtonState.Released, AsetaNopeus, null, maila1, Vector.Zero);

        Keyboard.Listen(Key.Up, ButtonState.Down, AsetaNopeus, "Pelaaja 2: Liikuta mailaa ylös", maila2, nopeusYlos);
        Keyboard.Listen(Key.Up, ButtonState.Released, AsetaNopeus, null, maila2, Vector.Zero);
        Keyboard.Listen(Key.Down, ButtonState.Down, AsetaNopeus, "Pelaaja 2: Liikuta mailaa alas", maila2, nopeusAlas);
        Keyboard.Listen(Key.Down, ButtonState.Released, AsetaNopeus, null, maila2, Vector.Zero);

        Keyboard.Listen(Key.F1, ButtonState.Pressed, ShowControlHelp, "Näytä ohjeet");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        
    }
    void AloitaPeli()
    {
        Vector impulssi = new Vector(500.0, 0.0);
        pallo.Hit(impulssi);
    }
    void AsetaNopeus(PhysicsObject maila, Vector nopeus)
    {
        if ((nopeus.Y < 0) && (maila.Bottom < Level.Bottom))
        {
            maila.Velocity = Vector.Zero;
            return;
        }
        if ((nopeus.Y > 0) && (maila.Top > Level.Top))
        {

            maila.Velocity = Vector.Zero;
            return;
            
        }
      maila.Velocity = nopeus;
    }

    void LuodaKentta()
    {
        pallo = new PhysicsObject(40.0, 40.0);

        Add(pallo);
        pallo.Shape = Shape.Circle;
        pallo.Color = Color.Black;
        pallo.X = -200.0;
        pallo.Y = 0.0;
        pallo.CanRotate = false;
        pallo.Restitution = 1.0;

        maila1 = LuoMaila(Level.Left + 20.0, 0.0);
        maila2 = LuoMaila(Level.Right - 20.0, 0.0);



        Level.CreateBorders(1.0, false);
        Level.Background.Color = Color.DarkRed;
        Camera.ZoomToLevel();

    }
}

