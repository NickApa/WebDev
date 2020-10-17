using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HW3JavatoCS
{
    class Run
    {
        private static void printUsage()
        {
            Console.WriteLine("Usage is \n" +
            "tjava Main C inputfile outputfile\n\n" +
            "Where:" +
            "  C is the column number to fit to\n" +
            "  inputfile is the input text file \n" +
            "  outputfile is the new output file base name containing the wrapped text.\n" +
            "e.g. java Main 72 myfile.txt myfile_wrapped.txt");
        }

        public static void Main(string[] args)
        {
            int C = 72;
            string inputFilename;
            string outputFilename = "output.txt";
            var scanner = new StreamReader(new File());


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
                var scanner = new StreamReader(inputFilename);
                Console.WriteLine(scanner.ReadToEnd());
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Could not find the input file");
                Environment.Exit(1);
            }
            catch(Exception e)
            {
                Console.WriteLine("Something is wrong with the input");
                printUsage();
                Environment.Exit(1);
            }

            IQueue<string> words = new LinkedQueue<string>();
            words.Push(scanner)

        }
    }
}
