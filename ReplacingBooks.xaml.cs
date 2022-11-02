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
using System.Linq;

namespace PROG7312_POE_ST10119567_Bulela_Tyelela
{
    /// <summary>
    /// Interaction logic for ReplacingBooks.xaml
    /// </summary>
    public partial class ReplacingBooks : Window
    {
        List<String> DDSnumber;
        int score = Computer.mylength;

        public ReplacingBooks()
        {
            InitializeComponent();

            MessageBox.Show("Here are the rules:" + "\n" +
                "You have to select an item on the left" + "\n" +
                "Click on 'Move' to have it on the right " + "\n" +
                "Do this a total of "+ Computer.mylength +" times" + "\n" +
                "The column on the right must be in ascending order (Smallet to Biggest, Top to Bottom)" + "\n" +
                "You will lose a point if the sequence is not in the correct order (You start at " + Computer.mylength + " points) " + "\n" +
                "Clicking 'Submit' will order the list on the left and compare to your list to it" + "\n" +
                "If the coloumns match, you win" + "\n" +
                "If they don't match you lose " + "\n \n" +
                "If you Click 'Submit' and your list is unordered, you'll lose 1 point" + "\n" +
                "If you Click 'Submit' and your list is unordered, and you don't have " + Computer.mylength + " items in the right side box, you'll lose 2 point" + "\n" +
                "Have fun");



            lblScore.Content = "Your Score: " + score;

            DDSnumber = Computer.randomDDSNGenerator();
            for (int i = 0; i < Computer.mylength; i++)
            {
                //Show randomly generated numbers in listbox
                listBoxRandomNumbers.Items.Add(DDSnumber[i]);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(score > 0)
            {
                try
                {
                    listBoxRandomNumbers.Items.Clear();
                    SortingAlgorithm sa = new SortingAlgorithm();

                    if (score > 0)
                    {

                    }

                    if (listBoxUser.Items.Count < Computer.mylength)
                    {
                        MessageBox.Show("You are missing some catergoies on the right hand side");
                        --score;
                        for (int i = 0; i < Computer.mylength; i++)
                        {
                            listBoxRandomNumbers.Items.Add(DDSnumber[i]);
                        }
                    }
                    else
                    {
                        //call selection sorting method
                        lblLeftTag.Content = "Sorted Catergories";
                        DDSnumber = sa.sortedList(DDSnumber);
                        for (int i = 0; i < Computer.mylength; i++)
                        {
                            listBoxRandomNumbers.Items.Add(DDSnumber[i]);
                        }
                    }




                    if (listBoxUser.Items.Count == Computer.mylength)
                    {
                        for (int i = 0; i < Computer.mylength; i++)
                        {

                            if (!listBoxRandomNumbers.Items[i].Equals(listBoxUser.Items[i]))
                            {
                                score--;
                                lblScore.Content = "Your Score " + score;
                                MessageBox.Show("Your items are not in order, you lose");
                                listBoxUser.Items.Clear();
                                return;
                            }

                            if (listBoxRandomNumbers.Items[i].Equals(listBoxUser.Items[i]))
                            {
                                if (i == Computer.mylength - 1)
                                {
                                    MessageBox.Show("Congratulations, You sorted the catergories correctly \n" +
                                        "Your total score is: " + score + " out of " + Computer.mylength);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must have " + Computer.mylength + " items on the right side box");
                        score--;
                        lblScore.Content = "Your Score " + score;
                        listBoxUser.Items.Clear();

                    }
                }
                catch (Exception w)
                {
                    MessageBox.Show(w.Message + "\n There must be items on the right side box");
                }
            }
            else
            {
                MessageBox.Show("Your Score is below 1, you lose");
            }
            
            
        }

        private void btnMove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxUser.Items.Count == 0)
                {
                    listBoxUser.Items.Add(listBoxRandomNumbers.SelectedItem);
                }
                else
                {
                    for (int i = 0; i < listBoxUser.Items.Count; i++)
                    {
                        if (listBoxUser.Items[i].Equals(listBoxRandomNumbers.SelectedItem))
                        {
                            //Ensuring no user can put duplicate numbers on right listbox
                            MessageBox.Show("This Catergory already exists");
                            return;
                        }
                    }
                    listBoxUser.Items.Add(listBoxRandomNumbers.SelectedItem);
                }
            }
            catch(NullReferenceException w)
            {
                MessageBox.Show(w.Message);
            }
            
        }
    }
}
