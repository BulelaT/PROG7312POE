using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10119567_Bulela_Tyelela
{
    class SortingAlgorithm
    {
        public List<String> sortedList(List<String> DDSList)
        {
            //Selection Sorting Alogrithm
            for (int i = 1; i < DDSList.Count; i++)
            {
                int flag = 0;
                String key = DDSList[i];
                int compare = 0;

                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    compare = DDSList[j].CompareTo(key);
                    if (compare == 1)
                    {
                        DDSList[j + 1] = DDSList[j];
                        j--;
                        DDSList[j + 1] = key;
                    }
                    else
                    {
                        flag = 1;
                    }

                }
            }

            return DDSList;
        }
    }
}
