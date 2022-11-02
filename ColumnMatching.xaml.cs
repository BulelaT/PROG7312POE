using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PROG7312_POE_ST10119567_Bulela_Tyelela
{
    /// <summary>
    /// Interaction logic for ColumnMatching.xaml
    /// </summary>
    public partial class ColumnMatching : Window
    {
        Dictionary<String, String> userDictionary = new Dictionary<String, String>();
        DeweyClassification gameStart = new DeweyClassification();
        List<String> cn;
        List<String> d;
        List<String> answers = new List<String>();
        String keyValuePairs1 = "";
        String keyValuePairs2 = "";
        int score = 0;
        public ColumnMatching()
        {
            InitializeComponent();

            initializingGame();
        }

        private void switchBtn_Click(object sender, RoutedEventArgs e)
        {
            userDictionary = null;
            userDictionary = new Dictionary<String, String>();

            if (firstlabeltxb.Text.Equals("Call Numbers"))
            {
                firstlabeltxb.Text = "Description";
                secondlabeltxb.Text = "Call Numbers";
                listBoxA.Items.Clear();
                listBoxB.Items.Clear();
                initializingGame();
            }
            else if(firstlabeltxb.Text.Equals("Description"))
            {
                firstlabeltxb.Text = "Call Numbers";
                secondlabeltxb.Text = "Description";
                listBoxA.Items.Clear();
                listBoxB.Items.Clear();
                initializingGame();
            }
            else
            {
                MessageBox.Show("Hmmm");
            }

        }

        private void matchBtn_Click(object sender, RoutedEventArgs e)
        {
            String leftCol = ""; 
            String rightCol = "";

            leftCol = listBoxA.SelectedItem.ToString();
            rightCol = listBoxB.SelectedItem.ToString();


            userDictionary.Add(leftCol, rightCol);
            
            
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            keyValuePairs1 = "";
            keyValuePairs2 = "";
            foreach (var item in userDictionary)
            {
                keyValuePairs1 += $"{item.Key} - {item.Value} \n";
                
            }

            foreach (var item in gameStart.callNumberDescription)
            {
                keyValuePairs2 += $"{item.Key} - {item.Value} \n";

            }
            MessageBox.Show("These are your answers: \n"+keyValuePairs1+ "\n" +
                "These are orginal call Numbers and their description: \n" +keyValuePairs2);

            if (firstlabeltxb.Text.Equals("Call Numbers"))
            {
                foreach (var item in userDictionary)
                {
                    if (gameStart.callNumberDescription.ContainsKey(item.Key))
                    {
                        gameStart.callNumberDescription.TryGetValue(item.Key, out String val);
                        if (val.Equals(item.Value))
                        {
                            score++;
                        }
                        else
                        {

                        }


                    }
                }
            }
            else
            {
                foreach (var item in userDictionary)
                {
                    if (gameStart.callNumberDescription.ContainsKey(item.Value))
                    {
                        //gameStart.callNumberDescription.TryGetValue(item.Key, out String val);
                        var key = gameStart.callNumberDescription.FirstOrDefault(x => x.Key == item.Value).Key;
                        if (key.Equals(item.Value))
                        {
                            score++;
                        }
                        else
                        {

                        }
                    }
                }
            }
                
            MessageBox.Show("Your score is: " + score);     
        }

        //(Sharp, 2013)
        public void initializingGame()
        {
            userDictionary.Clear();
            if(firstlabeltxb.Text.Equals("Call Numbers"))
            {
                cn = gameStart.randonNumberGen();

                for (int i = 0; i < 4; i++)
                {
                    listBoxA.Items.Add(cn[i]);
                }
                
                d = gameStart.descriptionInitialization();

                if(listBoxB.Items.Count == 0)
                {
                    correctAnswers(cn, true);
                    
                }
                else 
                {
                    listBoxB.Items.Clear();
                    correctAnswers(cn, true);
                    
                }
                
            }
            else if(firstlabeltxb.Text.Equals("Description"))
            {
                
                d = gameStart.descriptionInitialization();

                for (int i = 0; i < 4; i++)
                {
                    listBoxA.Items.Add(d[i]);
                }

                cn = gameStart.callNumberIntialization();
                correctAnswers(cn, false);
                
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
                
            

        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            //(Arsenyeva and Solovey, 2019)
            listBoxB.Items.Clear();
            listBoxA.Items.Clear();
            userDictionary = null;
            userDictionary = new Dictionary<String, String>();
            score = 0;
            gameStart.callNumbers.Clear();
            gameStart.description.Clear();
            initializingGame();
        }

        public void correctAnswers(List<String> callN, bool sw)
        {
            
            List<String> myAnswers = new List<String>();

            for (int i = 0; i < callN.Count(); i++)
            {
                if(sw)
                {
                    gameStart.callNumberDescription.TryGetValue(callN[i], out String val);
                    myAnswers.Add(val);
                }
                else
                {

                    if (gameStart.callNumberDescription.ContainsKey(callN[i]))
                    {
                        Debug.WriteLine(myAnswers.Count());
                        var key = gameStart.callNumberDescription.FirstOrDefault(y => y.Key == (callN[i])).Key;
                        myAnswers.Add(callN[i]);
                    }       
                }
                
            }
            

            int x = 0;
            Random rand = new Random();
            //(Nakov and Kolev, 2013)
            while (x < 3)
            {
                if(sw)
                {
                    int gameDictionary = rand.Next(0, gameStart.callNumberDescription.Count());

                    if (!myAnswers.Contains(gameStart.callNumberDescription.ElementAt(gameDictionary).Value))
                    {
                        myAnswers.Add(gameStart.callNumberDescription.ElementAt(gameDictionary).Value);
                        x++;
                    }
                    else
                    {

                    }
                }
                else
                {
                    x++;
                    
                }
                
                
            }

            
            myAnswers = gameStart.shuffleList(myAnswers);

            for (int j = 0; j < myAnswers.Count; j++)
            {
                listBoxB.Items.Add(myAnswers[j]);
            }
        }
    }

    
}
