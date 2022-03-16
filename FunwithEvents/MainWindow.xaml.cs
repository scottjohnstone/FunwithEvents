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
    // ref: https://stackoverflow.com/questions/10173978/read-return-value-from-delegate


    public partial class MainWindow : Window
    {

        public delegate Task<List<string>> GenericMethod(List<string> s);
        // change <int> to process & percentage complete to show which process is what % complete
        // to list all the processes that are taking place and their completion level

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListBoxStatus.Items.Clear();
            ListBoxStatus.Items.Add("Listbox ready");
            Status.Text = "You clicked me - Hooray! Retrieving file...";
            heavyLifting();
        }
        async private Task heavyLifting()
        {
            double percentageComplete = 0.00;
            List<string> process = new List<string>();

            Files fileHandler = new Files(); // instantiate class
            GenericMethod fileprocesor1;
            GenericMethod fileprocesor2;
            GenericMethod fileprocesor3;

            fileprocesor1 = fileHandler.query1;
            fileprocesor2 = fileHandler.query2;
            fileprocesor3 = fileprocesor1 + fileprocesor2;

            ListBoxStatus.Items.Clear();

            // goal: to monitor the status of a long running task, update the user to it's progress, and then move on when done

            int counter = 0;
            for (int i = 1; i < 5; i++)
            {
                percentageComplete = ((double)i / (double)4) *100d;
                Status.Text = "starting processes";
                
                Task<List<string>> processz = fileprocesor3(process);
                while (processz.Result.Count<2)
                {
                    Status.Text = "still waiting! " + counter.ToString();
                    counter++;
                }
                //Task processz = fileprocesor3(process);
                //process = await fileprocesor3(process);
                foreach (var item in fileprocesor3.GetInvocationList())
                {
                    Status.Text = item.Method.Name + " % complete:" + percentageComplete.ToString();
                    ListBoxStatus.Items.Add(Status.Text);
                }
                Status.Text = "done";
            }
        }
        public class Files
        {
            async public Task<List<string>> query1(List<string> s)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                s.Add("query1");
                return s;
            }

            async public Task<List<string>> query2(List<string> s)
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
                s.Add("query2");
                return s;
            }
        }
    }
}
