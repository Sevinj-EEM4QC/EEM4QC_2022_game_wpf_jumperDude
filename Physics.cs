using System.Windows.Controls;
namespace jumperDude
{
    static class Physics
    {
        public static void Gravity(Canvas gameground, PlayerObj playerobj)
        {
            if (Collision.CollisionDetectTop(gameground, playerobj,false) == false)
            {
                playerobj.Y += 0.12;
            }
            else
            {
                playerobj.Y = 0.12;
            }  
        }

    }
}
