using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderMaker_v2
{
    static class StringUtilityClass
    {
        /// <summary>
        /// Removes either ALL trailing slashes (default) or a maximum number
        /// as defined in the argument (NB if max number exceeds number of slashes
        /// then ALL slashes will be removed
        /// </summary>
        /// <param name="toRemoveFrom"></param>
        /// <param name="numberToRemove">how many to remove, if blank removes all</param>
        /// <returns></returns>
        public static string RemoveTrailingSlashes(this string toRemoveFrom, int numberToRemove = 0)
        {
            int i = 0;
            string tmp = toRemoveFrom;            
            
            while (tmp.Substring(tmp.Length - 1) == "\\")
            {
                tmp = tmp.Substring(0, tmp.Length - 1);
                if (numberToRemove > 0)
                {
                    i++;
                    if (i >= numberToRemove) break;
                }
            }            
            return tmp;
        }
    
    }
}
