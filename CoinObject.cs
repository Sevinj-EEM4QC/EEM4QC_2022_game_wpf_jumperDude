using System.Windows.Controls;
using System.Windows.Shapes;


namespace jumperDude
{
    class CoinObject : GameObject
    {
        Ellipse ellip = new Ellipse();
        Canvas playerground;
        public CoinObject(Canvas _playerground, double left, double top, double height, double width)
        {
            playerground = _playerground;

            Height = height;
            Width = width;

            ellip.Width = Width;
            ellip.Height = Height;
            

            playerground.Children.Add(ellip);

            Canvas.SetLeft(ellip, left);
            Canvas.SetTop(ellip, top);
        }
    }
}
