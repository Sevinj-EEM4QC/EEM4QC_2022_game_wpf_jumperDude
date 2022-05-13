using System.Windows;
using System.Windows.Controls;


namespace jumperDude
{
    
    public partial class TitleScreen : Page
    {
        int click_counter = 0;


        public TitleScreen()
        {
            InitializeComponent();
            
            UIEffects.TitleScreenBackground(background1, background2, background3, background4, background5,background11,background21,background31,background41,background51, 1);
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (click_counter == 0)
            {
                UIEffects.StartTransition<PlayGround>(titlescreen_canvas, Titlescreen_Page);
                //Titlescreen_Page.NavigationService.Navigate( new PlayGround());
                click_counter++;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
    }

