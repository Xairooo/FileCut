using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileCut;

internal class Program
{
    static void Main(string[] args)
    {
        // Check if command-line arguments are provided
        if (args.Length == 0)
        {
            Console.WriteLine("Drag and drop the file to cut on this app.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return;
        }

        // Get the file name from the command-line argument
        var fileName = args[0];
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"The file {fileName} does not exist");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine(fileName);
        Console.WriteLine("Cut position? (in %)");

        int splitP = 0;
        while (splitP == 0)
        {
            // Read and parse the user input for the cut position
            int.TryParse(Console.ReadLine(), out splitP);
            Console.WriteLine("Incorrect input!");
        }

        // Get information about the input file
        var fileInfo = new FileInfo(fileName);
        long fileLengthTarget = (fileInfo.Length / 100) * splitP;
        var fileExt = Path.GetExtension(fileName);
        var cnt = 1;
        string targetFileName = fileInfo.Name.Replace(fileExt, $"-{cnt}{fileExt}");

        // Ensure that the target file name is unique
        while (File.Exists(targetFileName))
        {
            targetFileName = fileInfo.Name.Replace(fileExt, $"-{cnt}{fileExt}");
            cnt++;
        }

        Console.WriteLine($"New File Name: {targetFileName}");

        // Open the input and output file streams for copying data
        using (var fsRead = new FileStream(fileName, FileMode.Open))
        using (var fsWrite = new FileStream(targetFileName, FileMode.Create))
        {
            while (fsRead.Position < fileLengthTarget)
            {
                // Copy data byte by byte from the input to the output file
                fsWrite.WriteByte((byte)fsRead.ReadByte());
            }

            // Close the file streams
            fsWrite.Close();
            fsRead.Close();

            // Display success message with the size of the cut file
            Console.WriteLine($"Success {helper.ConvertBytesToPrettyString(fileLengthTarget)} written.");
            Console.ReadKey();
        }
    }
}