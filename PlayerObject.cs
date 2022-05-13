namespace jumperDude
{
    class PlayerObj : GameObject
    {
        
        private double x;
        private double y;

        private double runSpeedX = 5;
        private double runSpeedY = 7;

        private int coinCounter = 0;

        private bool gameEnd = false;
        private bool localplayer;

        public delegate void GameEndEventHandler(PlayerObj sender, int e);
        public event GameEndEventHandler GameEnd;

        public PlayerObj(double height, double width, double getLeft, double getTop)
        {
            GetLeft = getLeft;
            GetTop = getTop;
            Height = height;
            Width = width;            
        }

        public override double GetTop
        {
            get { return getTop; }
            set
            {
                if(value < 800)
                {
                    getTop = value; NotifyPropertyChanged();
                }
                else if(gameEnd == false)
                {        
                    OnGameEnd();
                    gameEnd = true;
                }              
            }
        }

        public bool CloseGame 
        { 
            set
            {
                OnGameEnd();
                gameEnd = true;
            } 
        }

        public double X
        {
            get { return x; }
            set { x = value; NotifyPropertyChanged(); }
        }
        public double Y
        {
            get { return y; }
            set { y = value; NotifyPropertyChanged(); }
        }
        public double RunSpeedX
        {
            get { return runSpeedX; }
            set { runSpeedX = value; }
        }
        public double RunSpeedY
        {
            get { return runSpeedY; }
            set { runSpeedY = value; }
        }
        public int CoinCounter
        {
            get { return coinCounter; }
            set { coinCounter = value; NotifyPropertyChanged(); }

        }
        public int time { get; set; }

        protected virtual void OnGameEnd()
        {
            if(GameEnd != null)
            {
                GameEnd(this, CoinCounter);
            }
        }


    









}
}
