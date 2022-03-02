using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunwithEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    // ref: https://docs.microsoft.com/en-us/dotnet/api/system.delegate?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(System.Delegate);k(DevLang-csharp)%26rd%3Dtrue&view=net-6.0
    // ref: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/how-to-combine-delegates-multicast-delegates
    public partial class MainWindow : Window
    {

        public delegate Task<List<string>> GenericMethod();
        // change <int> to process & percentage complete to show which process is what % complete
        // to list all the processes that are taking place and their completion level

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "You clicked me - Hooray! Retrieving file...";
            heavyLifting();
        }
        async private Task heavyLifting()
        {
            double percentageComplete = 0.00;
            List<string> process = new List<string>();

            Files fileHandler = new Files(); // instantiate class
            List<string> fileProcessor = new GenericMethod();
            List<string> GenericMethod fileProcessor;
            fileProcessor = fileHandler.query1();
            fileProcessor += fileHandler.query2();

            

            for (int i = 1; i < 5; i++)
            {
                percentageComplete = ((double)i / (double)4) *100d;
                process = await fileProcessor();
                Status.Text = process +  " % complete:" + percentageComplete.ToString(); // update the result in UI
            }
        }
        public class Files
        {
            List<string> allResults = new List<string>();

            async public Task<List<string>> query1()
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                allResults.Add("query1");
                return allResults;
            }

            async public Task<List<string>> query2()
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                allResults.Add("query2");
                return allResults;
            }
        }
    }
}
