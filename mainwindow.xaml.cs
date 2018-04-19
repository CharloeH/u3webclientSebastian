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

namespace u3HemanSebastian
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string WordUsed = "";
        string Output = null;
        Random random = new Random(1);
        System.IO.StreamReader ChooseWord = new System.IO.StreamReader("Words.txt");
        System.IO.StreamWriter StreamWriter = new System.IO.StreamWriter("SelectedWord.txt");
        
        public MainWindow()
        {
            
            InitializeComponent();
            string[] Word = new string[15];
            string[] Guessed = new string[10];
            Random random = new Random();
        }
         private void BeginGame(object sender, RoutedEventArgs e)
        {
            FindWord();
        }
        private void CheckLetter(object sender, RoutedEventArgs e)
        {
            if (WordUsed.Contains(txtInput.Text))
            {
                
            }
        }
       
            
        private void FindWord()
        {
            try
            {
                int RNG = random.Next(1, 9);
                while (!ChooseWord.EndOfStream)
                {
                    string line = ChooseWord.ReadLine();
                    if (line.Contains(RNG.ToString()))
                    {
                         this.WordUsed = line.Substring(line.IndexOf(RNG.ToString()) + 2);
                        StreamWriter.WriteLine(WordUsed);
                       
                    }

                }
                ChooseWord.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                StreamWriter.Flush();
                StreamWriter.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error");
            }
        }

        
    }
}


