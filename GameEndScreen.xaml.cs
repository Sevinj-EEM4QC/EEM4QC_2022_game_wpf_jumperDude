using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace jumperDude
{
    
    public partial class GameEndScreen : Page
    {
        int coins = 0;
        StringBuilder coinstring = new StringBuilder();
        static int lastTarget;


        public GameEndScreen(int _coins,int time)
        {
            coins = _coins;
            DataContext = this;
            if(coins < 50)
            {
                coinstring.AppendLine("You Failed with: " + System.Convert.ToString(coins) + " Notes in " + time + " Seconds.");
                coinstring.AppendLine("");
                coinstring.AppendLine("Your Last : " + System.Convert.ToString(lastTarget));
                lastTarget = coins;
                InitializeComponent();
            }
            else
            {
                coinstring.AppendLine("You Passed with: " + System.Convert.ToString(coins) + " Notes in " + time + " Seconds.");
                coinstring.AppendLine("");
                coinstring.AppendLine("Last Note : " + System.Convert.ToString(lastTarget));
                lastTarget = coins;
                InitializeComponent();
            }
            
        }

        public int Coins
        {
            get { return coins; }
            set { coins = value;}
        }

        public string CoinString
        {
            get { return coinstring.ToString(); }
            //set { coinstring = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TitleScreen());
        }
    }
}
