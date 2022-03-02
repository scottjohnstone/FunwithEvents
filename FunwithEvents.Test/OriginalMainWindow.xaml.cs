//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace FunwithEvents
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    /// 
//    // ref: https://docs.microsoft.com/en-us/dotnet/api/system.delegate?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(System.Delegate);k(DevLang-csharp)%26rd%3Dtrue&view=net-6.0

//    public partial class MainWindow : Window
//    {

//        public delegate Task GenericMethod();

//        public MainWindow()
//        {
//            InitializeComponent();
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            Status.Text = "You clicked me - Hooray! Retrieving file...";
//            heavyLifting();
//        }
//        async private Task heavyLifting()
//        {
//            double percentageComplete = 0.00;

//            Files fileHandler = new Files(); // instantiate class
//            GenericMethod fileProcessor = fileHandler.query1;
//        https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/how-to-combine-delegates-multicast-delegates
//            //GenericMethod fp2 = fileHandler.query2;
//            fileProcessor = fileProcessor+fileHandler.query2;
            
//            for (int i = 1; i < 5; i++)
//            {
//                percentageComplete = ((double)i / (double)4) *100d;
//                await fileProcessor();
//                Status.Text = "% complete:" + percentageComplete.ToString(); // update the result in UI
//            }
//        }
//        public class Files
//        {
//            async public Task query1()
//            {
//                await Task.Delay(TimeSpan.FromSeconds(1));

//            }

//            async public Task query2()
//            {
//                await Task.Delay(TimeSpan.FromSeconds(1));

//            }
//        }
//    }
//}
