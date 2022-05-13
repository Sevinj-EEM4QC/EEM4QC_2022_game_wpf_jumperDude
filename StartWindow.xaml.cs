using System.Windows;

namespace jumperDude
{

    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new TitleScreen());

        }

    }
}
