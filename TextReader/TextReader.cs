using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MRLamb
{
    /// <summary>
    /// Class which reads a text file and inserts each line into a List called text.
    /// </summary>
    public class TextReader : List<String>
    {
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
                        this.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        /// <summary>
        /// Base Constructor. Would need to initialize
        /// </summary>
        public TextReader()
        {

        }

        /// <summary>
        /// Loads a file into the list, but empties the list first.
        /// </summary>
        /// <param name="path"></param>
        public void LoadFile(string path)
        {
            Empty();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        this.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Adds a file to the existing list, use Empty to remove everything before adding, or LoadFile to do both.
        /// </summary>
        /// <param name="path"></param>
        public void AppendFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        this.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Empties the list of all entries. LoadFile does this before adding to the list.
        /// </summary>
        public void Empty()
        {
            if (this.Count > 0)
            {
                this.RemoveRange(0, this.Count);
            }
        }
    }
}
