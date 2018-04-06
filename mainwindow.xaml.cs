/* Sebastian Horton
 * April 3, 2018
 * This progam reads from a web page and writes the data to a file.
 * */
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace u3WebClientSebastian
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //WebClient to get info
            System.Net.WebClient theInterWebs = new System.Net.WebClient();
            theInterWebs.BaseAddress = "https://raw.githubusercontent.com/IanMcT/WebClientReader/master/teams.txt";
            System.IO.StreamReader streamReader = new System.IO.StreamReader(theInterWebs.OpenRead("https://raw.githubusercontent.com/IanMcT/WebClientReader/master/teams.txt"));
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("teams.txt");
            try
            {
                //variable
                string substring = "";
                string AllTeams = "";
                while(!streamReader.EndOfStream)
                {   
                    string line = streamReader.ReadLine();
                    if (line.Contains("\"key\""))
                    {
                        // MessageBox.Show(line);
                        //add the team to the variable with a new line
                        int StartIndex = 12;
                        int Length = 7;
                        substring = line.Substring(StartIndex, Length);
                        AllTeams = AllTeams + substring + "\r";
                        //MessageBox.Show(substring);
                        streamWriter.WriteLine(line);
                        if (substring.Contains = ("\""))
                        {

                        }
                    }
                     
                }
                MessageBox.Show(AllTeams);
                //message box to show the variable
                streamWriter.Flush();
                streamWriter.Close();
                streamReader.Close();
                MessageBox.Show("\n" + "    Here in my garage, just bought this new Lamborghini here. It’s fun to drive up here in the Hollywood hills. But you know what I like more than materialistic things? Knowledge.");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
            }

        }
    }
}
