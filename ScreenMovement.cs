using System.Windows.Controls;


namespace jumperDude
{
    static class ScreenMovement
    {
        public static void ScreenFollow(PlayerObj playerobj, ScrollViewer scroller, double offset)
        {
            scroller
                .ScrollToHorizontalOffset(playerobj.GetLeft - offset);
            scroller
                .ScrollToVerticalOffset(playerobj.GetTop - offset);
        }

    }
}
