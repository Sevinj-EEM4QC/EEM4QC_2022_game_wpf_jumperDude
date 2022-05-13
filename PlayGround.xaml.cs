using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace jumperDude
{
    partial class PlayGround : Page
    {

        PlayerObj playerobj = new PlayerObj(74,42,10,10);

        AnimationClass animation = new AnimationClass();
     

        Task task1;
        Task task2;
        Task task3;
        Task task4;

        DispatcherTimer GameTimer = new DispatcherTimer();

        DispatcherTimer _timer;
        TimeSpan _time;
        public PlayGround()
        {
          

            DataContext = playerobj;
            
            InitializeComponent();
            playerobj.GameEnd += OnGameEnd;


            //debug.Show();
       
            LevelGenerator.GenerateLevel(Background_Canvas, 1);

            UIEffects.EndTransiton(Background_Canvas, PlayGrounds_Page);
            var PhysicsTimer = new DispatcherTimer();
            PhysicsTimer.Tick += PhysicsTimerTick;
            PhysicsTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            task1 = new Task(PhysicsTimer.Start);


            var AnimationTimer = new DispatcherTimer();
            AnimationTimer.Tick += AnimationTimerTick;
            AnimationTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            task2 = new Task(AnimationTimer.Start);

            var CoinTimer = new DispatcherTimer();
            CoinTimer.Tick += CoinTimerTick;
            CoinTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            task3 = new Task(CoinTimer.Start);

            
            GameTimer.Tick += GameTimerTick;
            GameTimer.Interval = new TimeSpan(0, 0, 0, 60, 0);
            task4 = new Task(GameTimer.Start);


            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();

            _time = TimeSpan.FromSeconds(60);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                timer.Text = _time.ToString("ss");
                playerobj.time = 60 - _time.Seconds;
                if (_time == TimeSpan.Zero) _timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();

        }

        private void GameTimerTick(object sender, EventArgs e)
        {
            GameTimer.Tick -= GameTimerTick;
            //playerobj.GameEnd += OnGameEnd;
            OnGameEnd(playerobj, playerobj.CoinCounter);
        }

        private void PhysicsTimerTick(object sender, EventArgs e)
        {
            PlayerMovement.PlayerMove(Background_Canvas, playerobj,true);
            Physics.Gravity(Background_Canvas, playerobj);
            ScreenMovement.ScreenFollow(playerobj, Scroller, 250);
            UIEffects.IngameScreenBackground_5(background1, background2, background3, background4, background5, background11, background21, background31, background41, background51, 1, playerobj.X, PlayGrounds_Page.ActualWidth, Collision.CollisonDetectLeft(Background_Canvas, playerobj,false), Collision.CollisionDetectRight(Background_Canvas, playerobj,false));
        }
        private void AnimationTimerTick(object sender, EventArgs e)
        {
            animation.PlayerAnimation(Player_Canvas, playerobj);
            
        }

        public void CoinTimerTick(object sender, EventArgs e)
        {
            animation.CoinAnimation(Background_Canvas,playerobj,600);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            playerobj.X = PlayerMovement.PlayerDirectionX(sender, e, playerobj.X, playerobj.RunSpeedX);
            playerobj.Y = PlayerMovement.PlayerDirectionY(sender, e, playerobj.Y, playerobj.RunSpeedY, Collision.CollisionDetectTop(Background_Canvas, playerobj,false));

            if(e.Key == Key.Escape)
            {
                this.NavigationService.Navigate(new TitleScreen());
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            playerobj.X = PlayerMovement.KeyResetX(sender, e, playerobj.X);
            playerobj.Y = PlayerMovement.KeyResetY(sender, e, playerobj.Y);
        }

        private void OnGameEnd(PlayerObj sender, int e)
        {
            if (NavigationService != null && e != null && sender != null)
            {
                //playerobj.GetTop = 0;
                //PlayerMovement.PlayerMove(Background_Canvas, playerobj, true);
                NavigationService.Navigate(new GameEndScreen(e, playerobj.time));
            }
        }

    }
}




