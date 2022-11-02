using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10119567_Bulela_Tyelela
{
    
    public class Computer
    {
        //dictates how many randomly generated numbers there should be
        public static int mylength = 10;
        public Computer()
        { }
        //Random Generator for user to sort
        public static List<String> randomDDSNGenerator()
        {
            List<String> DDS = new List<String>();
            String random = "";
            Random rnd = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < Computer.mylength; i++)
            {
                random = rnd.Next(0, 100).ToString();
                Double r = Convert.ToDouble(random);
                if(r < 10)
                {
                    random = "00" + random;
                }
                else if(r >= 10 && r <= 99)
                {
                    random = "0" + random;
                }
                else
                { }

                random += ".";
                for (int j = 0; j < 2; j++)
                {
                    random += rnd.Next(0, 10);
                }

                random += " ";
                for (int j = 0; j < 3; j++)
                {
                    random += chars[rnd.Next(chars.Length)];
                }

                DDS.Add(random);
                
                random = "";
            }
            
            //return the sorted list
            return DDS;
        }

        
    }
}
