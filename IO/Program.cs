using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = AtbashEncrypt(input);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "secret.txt");
            File.AppendAllText(filePath, output);
            string fileText = File.ReadAllText(filePath);
            string fileOut = AtbashEncrypt(fileText);
            Console.WriteLine(fileOut);
        }
        static string AtbashEncrypt(string input)
        {
            string result = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        result += (char)('Z' - (c - 'A'));
                    }
                    else // lowercase
                    {
                        result += (char)('z' - (c - 'a'));
                    }
                }
                else
                {
                    result += c; // משאיר תווים לא־אותיים כמו שהם
                }
            }

            return result;
        }
    }
}
