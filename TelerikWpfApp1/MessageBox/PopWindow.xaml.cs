using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBike.AppData;
using MahApps.Metro.Controls;
namespace TBike.MessageBox
{
    /// <summary>
    /// Interaction logic for PopWindow.xaml
    /// </summary>
    public partial class PopWindow : MetroWindow
    {
        CommonTools Common = new CommonTools();
        private ImageType CurrentImageType;
        public string HeaderText;
        public string Message;
        public string PositiveContentText;
        public string NegativeContentText;
        public bool Confirmed = false;
        public PopWindow(ImageType IncomingImage, string IncomingHeader, string IncomingMessage, string IncomingPositive)
        {
            CurrentImageType = IncomingImage;
            HeaderText = IncomingHeader;
            Message = IncomingMessage;
            PositiveContentText = IncomingPositive;
        
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            switch (CurrentImageType)
            {
                case ImageType.Information:
                    imgIcon.Source = Application.Current.Resources["SmallInfoIconImageSource"] as ImageSource;
                    break;
                case ImageType.Warning:
                    imgIcon.Source = Application.Current.Resources["SmallWarningIconImageSource"] as ImageSource;
                    break;
                case ImageType.Error:
                    imgIcon.Source = Application.Current.Resources["SmallErrorIconImageSource"] as ImageSource;
                    break;
                case ImageType.Question:
                    imgIcon.Source = Application.Current.Resources["SmallQuestionIconImageSource"] as ImageSource;
                    break;
                default:
                    imgIcon.Source = Application.Current.Resources["SmallInfonIconImageSource"] as ImageSource;
                    break;
            }
            this.Title = HeaderText;
            this.tbMessage.Text = Message;
            this.BTNYes.Content = PositiveContentText;
    

            //always the negative button got focus first
            this.BTNYes.Focus();
        }

        private void BTNYes_Click(object sender, RoutedEventArgs e)
        {
            Confirmed = true;
            this.Close();
            
        }

  

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
