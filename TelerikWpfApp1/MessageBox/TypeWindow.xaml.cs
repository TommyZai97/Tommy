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
using MahApps.Metro.Controls;
using Telerik.Windows.Controls;
using TBike.AppData;

namespace TBike.MessageBox
{
    /// <summary>
    /// Interaction logic for ConfirmWindow.xaml
    /// </summary>
    public partial class TypeWindow : MetroWindow, IDisposable
    {
        CommonTools Common = new CommonTools();
        private ImageType CurrentImageType;
        public string HeaderText;
        public string Message;
        public string PositiveContentText;
        public string NegativeContentText;
        public int Month;
        public bool Confirmed = false;
        public TypeWindow(ImageType IncomingImage, string IncomingHeader, string IncomingMessage, string IncomingPositive, string IncomingNegative)
        {
            CurrentImageType = IncomingImage;
            HeaderText = IncomingHeader;
            Message = IncomingMessage;
            PositiveContentText = IncomingPositive; 
            NegativeContentText = IncomingNegative;
          
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
                    imgIcon.Source = Application.Current.Resources["SmallInfoIconImageSource"] as ImageSource;
                    break;
            }
            this.Title = HeaderText;
            this.tbMessage.Text = Message;
            
            this.BTNYes.Content = PositiveContentText;
            this.BTNNo.Content = NegativeContentText;

            //always the negative button got focus first
            this.BTNNo.Focus();
        }

        private void BTNYes_Click(object sender, RoutedEventArgs e)
        {
            ChangeString();
            Confirmed = true;
            this.Close();
        }

        private void BTNNo_Click(object sender, RoutedEventArgs e)
        {
            Confirmed = false;
            this.Close();
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public void ChangeString()
        {
            if (tbType.Text == "January")
            {
                Month = 1;
            }
            else if (tbType.Text == "February")
            {
                Month = 2;
            }
            else if (tbType.Text == "March")
            {
                Month = 3;
            }
            else if (tbType.Text == "April")
            {
                Month = 4;
            }
            else if (tbType.Text == "May")
            {
                Month = 5;
            }
            else if (tbType.Text == "June")
            {
                Month = 6;
            }
            else if (tbType.Text == "July")
            {
                Month = 7;
            }
            else if (tbType.Text == "August")
            {
                Month = 8;
            }
            else if (tbType.Text == "September")
            {
                Month = 9;
            }
            else if (tbType.Text == "October")
            {
                Month = 10;
            }
            else if (tbType.Text == "November")
            {
                Month = 11;
            }
            else if (tbType.Text == "December")
            {
                Month = 12;
            }


        }
    }
}
