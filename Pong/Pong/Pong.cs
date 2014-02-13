using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class Pong : PhysicsGame
{
    PhysicsObject pallo;
    public override void Begin()
    {
        LuodaKentta();
        AloitaPeli();
        // TODO: Kirjoita ohjelmakoodisi tähän
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        
    }
    void LuoMaila(double x, double y)
    {
      PhysicsObject maila = PhysicsObject.CreateStaticObject(20.0, 100.0);
        maila.Shape = Shape.Rectangle;
        maila.X = x;
        maila.Y = y;
        maila.Restitution = 1.0;
        Add(maila);
        maila.Color = Color.Aquamarine;  
        
        void AsetaOhjaimet ()
        {
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        }

    }

    void AloitaPeli()
    {
        Vector impulssi = new Vector(500.0, 0.0);
        pallo.Hit(impulssi);
    }

    void LuodaKentta()
    {
        pallo = new PhysicsObject(40.0, 40.0);              

        Add(pallo);
        pallo.Shape = Shape.Circle;
        pallo.Color = Color.Black;
        pallo.X = -200.0;
        pallo.Y = 0.0;

        LuoMaila(Level.Left + 20.0, 0.0);
        LuoMaila(Level.Right - 20.0, 0.0);
        


        Level.CreateBorders(1.0, false);
        Level.Background.Color = Color.DarkRed;
        Camera.ZoomToLevel ();
        
    }
}

