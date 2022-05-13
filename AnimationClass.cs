using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace jumperDude
{
    class AnimationClass
    {
        List<string> idle = new List<string>
        
{
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle1.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle2.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle3.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle4.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle5.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle6.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle7.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle8.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle9.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle10.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle11.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Idle/idle12.png",
};


        List<string> run =  new List<string>
    {
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Run/run1.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Run/run2.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Run/run3.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Run/run4.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Run/run5.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Run/run6.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Run/run7.png",
        "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Run/run8.png",
    };

        List<string> coinAnimation = new List<string>
        {     "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Coin/coin1.png",
              "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Coin/coin2.png",
              "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Coin/coin3.png",
              "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Coin/coin4.png",
              "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Coin/coin5.png",
              "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Coin/coin6.png",
              "pack://application:,,,/jumperDude;component/Resource/Animation/Animation_Run/run8.png",
};

        int playerCounter = 0;
        int coinCounter = 0;

        public void PlayerAnimation(Rectangle Player_Canvas, PlayerObj playerobj)
        {

            if (playerobj.X == 0)
            {
                if (playerCounter >= idle.Count)
                {
                    playerCounter = 0;
                }
                Player_Canvas.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(idle[playerCounter], UriKind.Absolute))
                };
                playerCounter++;
            }
            else
            {
                if (playerobj.X < 0)
                {
                    Player_Canvas.LayoutTransform = new ScaleTransform(1, 1, 0, 0);
                }
                else
                {
                    Player_Canvas.LayoutTransform = new ScaleTransform(-1, 1, 0, 0);
                }

                if (playerCounter >= run.Count)
                {
                    playerCounter = 0;
                }
                Player_Canvas.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(run[playerCounter], UriKind.Absolute))
                };
                playerCounter++;
            }

        }
        public void CoinAnimation(Canvas gameground, PlayerObj playerobj, double visibleOffset)
        {

            if (coinCounter >= coinAnimation.Count-1)
            {
                coinCounter = 0;
            }
            foreach (Shape element in gameground.Children)
            {
                if (Equals(element.GetType(), typeof(Ellipse)) && (Canvas.GetLeft(element) > playerobj.GetLeft - visibleOffset && Canvas.GetLeft(element) < playerobj.GetLeft + visibleOffset))
                {

                    if(element.Height==60)
                    {

                        element.Fill = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri("pack://application:,,,/jumperDude;component/Resource/PNG/book.png", UriKind.Absolute))
                        };
                    }
                    else
                    {
                        element.Fill = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri(coinAnimation[coinCounter], UriKind.Absolute))
                        };
                    }

                    
                }

            }
            coinCounter++;

        }

    }
}
