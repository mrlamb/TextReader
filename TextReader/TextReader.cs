using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MRLamb
{
    public class TextReader
    {
        public List<String> text = new List<String>();
        private int currentLine = 0;
        /// <summary>
        /// Instantiate class with the path name of the file to be read in.
        /// </summary>
        /// <param name="path">Path to the file. Relative to executable or full path.</param>
        public TextReader(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        text.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        /// <summary>
        /// Returns the next line from the text. If no more lines are available, returns an empty string.
        /// </summary>
        /// <returns>String</returns>
        public string GetNextLine()
        {
            currentLine++;
            if (currentLine <= text.Count)
            {
                return text[currentLine - 1];
            }
            else
            {
                throw new Exception("No more lines to be read.");
            }
            
        }

        /// <summary>
        /// If using GetNextLine, resets the line you were on and returns the first line over again
        /// </summary>
        /// <returns>String</returns>
        public string StartOver()
        {
            currentLine = 1;
            return text[currentLine - 1];
        }

        /// <summary>
        /// Returns the total number of lines in your text file
        /// </summary>
        /// <returns>Int</returns>
        public int GetTotalLines()
        {
            return text.Count;
        }
        

        /// <summary>
        /// Allows you to skip forward or backward through the file. Any number 
        /// < 0 will reset to the start of the file, any number greater then the 
        /// total number of lines will prepare to send the last line.
        /// </summary>
        /// <param name="line">int lineNumber</param>
        public void SkipTo(int line)
        {
            if (line < 0)
            {
                currentLine = 0;
            }
            else if (line <= text.Count)
            {
                currentLine = line;
            }
            else
            {
                currentLine = text.Count - 1;
            }
        }



    }

}
