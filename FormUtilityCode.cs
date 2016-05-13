using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderMaker_v2
{
    static class FormUtilityCode    {
        

        public static bool RestrictBoxChars(this TextBox box, int maxCharacters, int minCharacters = 0)
        {
            string text = box.Text;
            int countLetters = text.Length;

            if (countLetters > maxCharacters)
            {
                box.Text = text.Substring(0, maxCharacters);
                box.SelectionStart = maxCharacters;
                return true;
            }

            if (countLetters < minCharacters)
            {
                box.Undo();
                box.SelectionStart = minCharacters;
                return true;
            }
            return false;
        }

        public static void SetColumns(this ListView viewBox, string[] colHeaders, int colWidth = 200)
        {
            int levels = colHeaders.Length;
            viewBox.Columns.Clear();
            for (int i = 0; i < levels; i++)
            {
                viewBox.Columns.Add(colHeaders[i]);
                viewBox.Columns[i].Width = colWidth;
            }
        }

        public static void SelectTab(this TabControl tabCtrl, TabPage tabToSelect)
        {
            for (int i = 0; i < tabCtrl.TabPages.Count; i++)
            {
                if (tabCtrl.TabPages[i] == tabToSelect)
                {
                    tabCtrl.SelectedIndex = i;
                    return;
                }
            }
        }

        public static bool ContainsOnlySpaces(this TextBox box)
        {            
            string text = box.Text;
            int total = text.Length;
            if (total == 0) return false;

            int spaces = text.Count(s => s == ' '); //Lambda expression to return all the spaces

            if (spaces >= total) return true;
            return false;
        }

        public static bool LeadOrTrailSpaces(this TextBox box)
        {
            string text = box.Text;
            int total = text.Length;
            if (total == 0) return false;
            if (text[0] == ' ') return true;
            if (text[total - 1] == ' ') return true;
            return false;

        }


        


        // TODO make this code work so that it:
        // - splits columns to fit the minimum data width, then, if too small, so it fits the header
        // then finally uses this code, adapted to split it evenly across the box
        // ? what if minimum width is wider than the holding box, what do we do then?
        /// <summary>
        /// Sets all columns in a ListView box to the same width
        /// </summary>
        /// <param name="viewBox"></param>
        public static void EqualColumns(this ListView viewBox)
        {            
            int colCount =  viewBox.Columns.Count;
            if (viewBox != null)
            {
                for (int i = 0; i < colCount; i++)
			    {
                    double colPercentage = 1 / (double)colCount;
                    viewBox.Columns[i].Width = (int)(colPercentage * viewBox.ClientRectangle.Width);
                }
            }            
        }

        /// <summary>
        /// TODO this overload is not yet done
        /// Sets columns in a ListView box to fit on the ratio supplied
        /// If ratio array does not match number of columns all columns matched as same
        /// </summary>
        /// <param name="viewBox"></param>
        public static void EqualColumns(this ListView viewBox, int[] colRatios)
        {
            int colCount = viewBox.Columns.Count;
            if (viewBox != null)
            {
                for (int i = 0; i < colCount; i++)
                {
                    double colPercentage = 1 / (double)colCount;
                    viewBox.Columns[i].Width = (int)(colPercentage * viewBox.ClientRectangle.Width);
                }
            }
        }


        public static bool MaxLinesInTextBox(this TextBox box, int maxLines = 1)
        {
            int lineCount = box.Lines.Count();
            
            if (lineCount > maxLines)
            {
                string[]tmp = box.Lines;
                Array.Resize(ref tmp, maxLines);
                box.Lines = tmp;
                box.SelectionStart = box.Text.Length;
                return true;
            }
            return false;
        }

        

/////////---END---------------------------------------------------------------------------------------------------------------------------------------
    }
}
