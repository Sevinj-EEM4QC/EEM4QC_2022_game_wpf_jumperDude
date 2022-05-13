using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace jumperDude
{

    static class Collision
    {
        public static bool CollisionDetectTop(Canvas ShapeCanvas, PlayerObj playerobj, bool coindetect)
        {
            int i;
            bool top;
            LinkedList<Shape> removelist = new LinkedList<Shape>();

            i = 0;
            foreach (Shape element in ShapeCanvas.Children)
            {
                if (playerobj.GetLeft >= 
                    Canvas.GetLeft(element) -  playerobj.Width &&  playerobj.GetLeft <= 
                    Canvas.GetLeft(element) + element.Width && playerobj.GetTop > 
                    Canvas.GetTop(element) - playerobj.Height && playerobj.GetTop < 
                    Canvas.GetTop(element) - playerobj.Height + 10)
                {
                    if (coindetect == true && Equals(element.GetType(), typeof(Ellipse)))
                    {
                        i++;
                        removelist.AddLast(element);
                        if (element.Height == 50)
                        {
                            playerobj.CoinCounter = playerobj.CoinCounter + 5;
                        }
                        else if (element.Height == 60)
                        {
                            //ScreenMovement.ScreenFollow(playerobj, Scroller, 250);
                            playerobj.CloseGame = true; //= playerobj.CoinCounter + 5;
                        }
                        else
                        {
                            playerobj.CoinCounter++;
                        }
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape element in removelist)
                    ShapeCanvas.Children.Remove(element);         
            }
            if (i == ShapeCanvas.Children.Count)
            {
                top = false;
                return top;
            }
            else
            {
                top = true;
                return top;
            }

        }
        public static bool CollisonDetectBottom(Canvas ShapeCanvas, PlayerObj playerobj, bool coindetect)
        {
            int i;
            bool bottom;
            LinkedList<Shape> removelist = new LinkedList<Shape>();


            i = 0;

            foreach (Shape element in ShapeCanvas.Children)
            {
                if (playerobj.GetLeft >= Canvas.GetLeft(element) - playerobj.Width && playerobj.GetLeft <= Canvas.GetLeft(element) + element.Width && playerobj.GetTop > Canvas.GetTop(element) + element.Height && playerobj.GetTop < Canvas.GetTop(element) + element.Height + 10)
                {
                    if (coindetect == true && Equals(element.GetType(), typeof(Ellipse)))
                    {
                        i++;
                        removelist.AddLast(element);
                        if (element.Height == 50)
                        {
                            playerobj.CoinCounter = playerobj.CoinCounter + 5;
                        }
                        else if (element.Height == 60)
                        {
                            playerobj.CloseGame = true; //= playerobj.CoinCounter + 5;
                        }
                        else
                        {
                            playerobj.CoinCounter++;
                        }
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape element in removelist)
                {
                    ShapeCanvas.Children.Remove(element);
                }
            }
            if (i == ShapeCanvas.Children.Count)
            {
                bottom = false;
                return bottom;
            }
            else
            {
                bottom = true;
                return bottom;
            }
        }
        public static bool CollisionDetectRight(Canvas ShapeCanvas, 
            PlayerObj playerobj, 
            bool coindetect)
        {
            int i;
            bool right;
            LinkedList<Shape> removelist = new LinkedList<Shape>();

            i = 0;
            foreach (Shape element in ShapeCanvas.Children)
            {

                if (playerobj.GetTop >= Canvas.GetTop(element) - playerobj.Height && playerobj.GetTop <= Canvas.GetTop(element) + element.Height && playerobj.GetLeft > Canvas.GetLeft(element) + element.Width && playerobj.GetLeft < Canvas.GetLeft(element) + element.Width + 10)
                {
                    if (coindetect == true && Equals(element.GetType(), typeof(Ellipse)))
                    {
                        i++;
                        removelist.AddLast(element);
                        if (element.Height == 50)
                        {
                            playerobj.CoinCounter = playerobj.CoinCounter + 5;
                        }
                        else if (element.Height == 60)
                        {
                            playerobj.CloseGame = true; //= playerobj.CoinCounter + 5;
                        }
                        else
                        {
                            playerobj.CoinCounter++;
                        }
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape element in removelist)
                {
                    ShapeCanvas.Children.Remove(element);
                }
            }
            if (i == ShapeCanvas.Children.Count)
            {
                right = false;
                return right;
            }
            else
            {
                right = true;
                return right;
            }
        }
        public static bool CollisonDetectLeft(Canvas ShapeCanvas, PlayerObj playerobj, bool coindetect)
        {
            int i;
            bool left;
            LinkedList<Shape> removelist = new LinkedList<Shape>();


            i = 0;
            foreach (Shape element in ShapeCanvas.Children)
            {

                if (playerobj.GetTop >= Canvas.GetTop(element) - playerobj.Height && playerobj.GetTop <= Canvas.GetTop(element) + element.Height && playerobj.GetLeft > Canvas.GetLeft(element) - playerobj.Width && playerobj.GetLeft < Canvas.GetLeft(element) - playerobj.Width + 10)
                {
                    if (coindetect == true && Equals(element.GetType(), typeof(Ellipse)))
                    {
                        i++;
                        removelist.AddLast(element);
                        if (element.Height == 50)
                        {
                            playerobj.CoinCounter = playerobj.CoinCounter + 5;
                        }
                        else if (element.Height == 60)
                        {
                            playerobj.CloseGame = true; //= playerobj.CoinCounter + 5;
                        }
                        else
                        {
                            playerobj.CoinCounter++;
                        }
                    }
                }
                else
                {
                    i++;
                }
            }
            if(coindetect == true)
            {
                foreach (Shape element in removelist)
                {
                    
                    ShapeCanvas.Children.Remove(element);
                }
            }


            if (i == ShapeCanvas.Children.Count)
            {
                left = false;
                return left;
            }
            else
            {
                left = true;
                return left;
            }
        }
        public static void CollisonDetectAll(Canvas ShapeCanvas, PlayerObj playerobj, bool coindetect)
        {
            CollisionDetectTop(ShapeCanvas, playerobj, coindetect);
            CollisonDetectBottom(ShapeCanvas, playerobj, coindetect);
            CollisonDetectLeft(ShapeCanvas, playerobj, coindetect);
            CollisionDetectRight(ShapeCanvas, playerobj, coindetect);
        }

        private static void CoinDelete(Shape element, LinkedList<Shape> list)
        {
            // Coin Detect 
            if (Equals(element.GetType(), typeof(Ellipse)))
            {
                element.Opacity = 0;
                list.Remove(element);
            }
        }

    }
}
