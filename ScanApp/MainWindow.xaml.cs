using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Collections.ObjectModel;

namespace ScanApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            ObservableCollection<Member> memberData = new ObservableCollection<Member>();
            memberData.Add(new Member()
            {
                TDate = "周五\r\n02-24",
                Amt = 23.20,
                Num = 2.30,
                Fee = 11.02,
                Msg = "微信：金额0.02元 笔数0 手续费0.00\r\n支付宝：金额0.02元 笔数0 手续费0.00"
             });
            memberData.Add(new Member()
            {
                TDate = "周五\r\n02-24",
                Amt = 23.20,
                Num = 2.30,
                Fee = 11.02,
                Msg = "微信：金额0.02元 笔数0 手续费0.00\r\n支付宝：金额0.02元 笔数0 手续费0.00"
            });
             dataGrid.DataContext = memberData;
        }
        

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //canvas1.Visibility = Visibility.Visible;
            canvas1.Visibility = Visibility.Collapsed;
            canvas2.Visibility = Visibility.Visible;
            this.Title = "众马支付";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void frame1_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            canvas3.Visibility = Visibility.Visible;
            canvas4.Visibility = Visibility.Collapsed;
            canvas_child.Visibility = Visibility.Collapsed;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            canvas3.Visibility = Visibility.Collapsed;
            canvas4.Visibility = Visibility.Visible;
            canvas_child.Visibility = Visibility.Collapsed;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

        }

        ///*********** 数字键盘 Start! **********************///
         private void LayoutRoot_Click(object sender, RoutedEventArgs e)
        {
            Button bt = e.OriginalSource as Button;
            if(bt!=null)
            {
                string intext = bt.Content.ToString();
                input_Pasting(intext);
            }
        }
         //输入从整数
         private void input_Pasting(string StrInput)
         {

             if (StrInput == "<-")
             {
                 if (input.Content != null)
                 {
                     if (!string.IsNullOrEmpty(input.Content.ToString()))
                     {
                         input.Content = Convert.ToString(input.Content).Substring(0, Convert.ToString(input.Content).Length - 1);

                     }
                 }
             }
             else if (StrInput == "清除")
             {
                 // input.Clear();
             }
             else if (StrInput == "确定")
             {
                 //不处理
             }
             else if (StrInput == ".")
             {
                 if (input.Content != null)
                 {
                     int pos = (input.Content.ToString()).IndexOf(".");
                     // Console.WriteLine(pos);
                     int len = (input.Content.ToString()).Length;
                     if (pos <= 0 && len <= 0)
                     {
                         input.Content = "0.";
                         return;
                     }
                     if (((input.Content.ToString()).Contains(".")))
                     {
                         // Console.WriteLine(len);
                         return;
                     }
                 }
                 else
                 {
                     input.Content = "0.";
                     return;
                 }
                 //Console.WriteLine(22);
                 input.Content += StrInput;

             }
             else 
             {
                 if (input.Content != null)
                 {
                     int len = (input.Content.ToString()).Length;
                     int pos = (input.Content.ToString()).LastIndexOf(".");
                     //限制8位
                     if ((pos == -1) && (len - pos) > 8)
                     {
                         return;
                     }
                     //限制小数点后两位
                     if (((input.Content.ToString()).Contains(".")))
                     {
                      
                         if (pos != -1 && (len - pos) > 2)
                         {
                             return;
                         }
                     }
                     //为零时不能输入
                     if(len == 1)
                     {
                         if (((input.Content.ToString()).Contains("0")) && StrInput == "0")
                         {
                             return;                          
                         }
                         else if (((input.Content.ToString()).Contains("0")) && StrInput != "0" )
                         {
                             //首位为"0"时，不显示、
                             input.Content = StrInput;
                             return;
                         }
                     }
                 }
                 input.Content += StrInput;
             }
         }

         //输入从小数

         private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
         {
             string str = e.Text;
             //Console.WriteLine(str);
             if (str == "\b")
             {
                 str = "<-";
             }
            // Console.WriteLine(str);
             if (isNumberic(str) || str == "." ||  str == "<-")
             {
                 input_Pasting(str);
             }
         }
         //isDigit是否是数字
         private static bool isNumberic(string _string)
         {
             if (string.IsNullOrEmpty(_string))
                 return false;
             foreach (char c in _string)
             {
                 if (!char.IsDigit(c))
                     //if(c<'0' c="">'9')//最好的方法,在下面测试数据中再加一个0，然后这种方法效率会搞10毫秒左右
                     return false;
             }
             return true;
         }
         ///*********** 数字键盘  End!********************///
         private void button5_Click_1(object sender, RoutedEventArgs e)
         {
            // var startdate = datePickerE.ToString();
             //var startv = datePickerS.Equals(datePickerS);
             var dts = datePickerS.DisplayDate;
             var dte = datePickerE.DisplayDate;
             //var i = dts.CompareTo(dte);
             //Console.WriteLine(dts);
             //Console.WriteLine(dte);
             //Console.WriteLine(i);
             if (dts.CompareTo(dte) > 0)
             {
                 MessageBox.Show("开始日期不能早于结束日期!");
                 return;
             }
             else
             {
               //  MessageBox.Show("!!!!!!!!!!!!");
             }
         }

         private void datePickerS_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
         {
             if (e.Source is DatePicker)
             {
                 var dtSelect = datePickerS.SelectedDate;
                 datePickerS.DisplayDate = DateTime.Parse(dtSelect.ToString());
                 //Console.WriteLine(dtSelect);
             }
         }

         private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             canvas3.Visibility = Visibility.Collapsed;
             canvas4.Visibility = Visibility.Collapsed;
             canvas_child.Visibility = Visibility.Visible;
             Console.WriteLine("!!!!!!!!!!!!");
         }

         private void button6_Click(object sender, RoutedEventArgs e)
         {
             canvas3.Visibility = Visibility.Collapsed;
             canvas4.Visibility = Visibility.Visible;
             canvas_child.Visibility = Visibility.Collapsed;
         }

          
    }

    public class Member
    {
        public string TDate { get; set; }
        public double Amt { get; set; }
        public double Num { get; set; }
        public double Fee { get; set; }
        public string Msg { get; set; }
    }
}
