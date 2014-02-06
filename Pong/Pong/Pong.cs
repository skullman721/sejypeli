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
        // TODO: Kirjoita ohjelmakoodisi tähän
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
    void LuodaKentta()
    {
        pallo = new PhysicsObject(40.0, 40.0);              
            Add(pallo);
        pallo.Shape = Shape.Circle;
        pallo.X = -200.0;
        pallo.Y = 0.0;
        Vector impulssi = new Vector(500.0, 0.0);
        pallo.Hit(impulssi);

        PhysicsObject maila = PhysicsObject.CreateStaticObject(20.0, 100.0);
        Level.CreateBorders(1.0, false);
        Level.Background.Color = Color.Aqua;
        Camera.ZoomToLevel();
        
    }
}
