using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace jumperDude
{
    static class LevelGenerator
    {
                   
        public static void GenerateLevel(Canvas gameground, int seed)
        {

            for (int i = 0; i <= 30000; i += 200)
            {
                Random rnd = new Random(i*seed);
                double rndPositionX = rnd.Next(i + 50, i + 200);
                double rndPositionY = rnd.Next(100, 500);
                double rndRectHeight = rnd.Next(20, 50);
                double rndRectWidth = rnd.Next(100, 500);
                int rndCoinTrue = rnd.Next(0, 2);

                if (rndCoinTrue == 1)
                {
                    int rndWidthint = System.Convert.ToInt32(rndRectWidth);
                    double tmpX = rndPositionX;
                    int times = rndWidthint / 40;

                    for (int a = 0; a < times; a++)
                    {
                        if (a>0 && a>1 && a == times / 2)
                        {
                            new CoinObject(gameground, tmpX + (40 * a), rndPositionY - 50, 50, 50);
                        }
                        else if (a > 0 && a > 1 && a == times / 3)
                        {
                            new CoinObject(gameground, tmpX + (40 * a), rndPositionY - 50, 60, 50);
                        }
                        else
                        {
                            new CoinObject(gameground, tmpX + (40 * a), rndPositionY - 40, 38, 38);
                        }
                    }
                }

                Rectangle rect = new Rectangle();
                rect.Height = rndRectHeight;
                rect.Width = rndRectWidth;
                rect.StrokeThickness = 1;
                rect.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/jumperDude;component/Resource/PNG/book.png", UriKind.Absolute))
                };
                rect.Stretch = Stretch.Fill;
                rect.RadiusX = 15;
                rect.RadiusY = 15;
                gameground.Children.Add(rect);
                Canvas.SetLeft(rect, rndPositionX);
                Canvas.SetTop(rect, rndPositionY);
            }
        }


    }
}
