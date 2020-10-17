using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace HW3JavatoCS
{
    class Run
    {
        private static void printUsage()
        {
            Console.WriteLine("Usage is \n" +
            "dotnet run C inputfile outputfile\n\n" +
            "Where:" +
            "  C is the column number to fit to\n" +
            "  inputfile is the input text file \n" +
            "  outputfile is the new output file base name containing the wrapped text.\n" +
            "e.g. dotnet run 72 myfile.txt myfile_wrapped.txt");
        }

        public static void Main(string[] args)
        {
            int C = 72;
            string inputFilename;
            string outputFilename = "output.txt";
            StreamReader scanner;
            IQueue<string> words = new LinkedQueue<string>();

            if(args.Length != 3)
            {
                printUsage();
                Environment.Exit(1); 
            }
            try
            {
                C = Int32.Parse(args[0]);
                inputFilename = args[1];
                outputFilename = args[2];
                scanner = new StreamReader(inputFilename);
                
               
                while(scanner.Peek() > 0)
                {
                    foreach(var word in scanner.ReadLine().Split(" "))
                    {
                        words.Push(word);
                    }
                }
                
                
                
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Could not find the input file");
                Environment.Exit(1);
            }
            catch(Exception)
            {
                Console.WriteLine("Something is wrong with the input");
                printUsage();
                Environment.Exit(1);
            }

            int spaceRemaining = WrapSimply(words, C, outputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spaceRemaining);  

        }

        private static int WrapSimply(IQueue<string> words, int columnLength, string outputFilename)
        {
            StreamWriter outy;

            try
            {
                outy = new StreamWriter(outputFilename);

                
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Cannot create or open " + outputFilename +
                        " for writing.  Using standard output instead.");
                outy = new StreamWriter(Console.OpenStandardOutput());
                outy.AutoFlush = true;
            }
            int col = 1;
            int spaceRemaining = 0;
            while(!words.IsEmpty())
            {
                string str = words.Peek();
                int length = str.Length;

                if(col == 1)
                {
                    outy.Write(str);
                    col += length;
                    words.Pop();
                }
                else if((col + length) >= columnLength)
                {
                    outy.WriteLine();
                    spaceRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {
                    outy.Write(" ");
                    outy.Write(str);
                    col += (length + 1);
                    words.Pop();
                }
               
                
            }
            outy.WriteLine();
            outy.Flush();
            outy.Close();
            return spaceRemaining;
        }
    }
}
