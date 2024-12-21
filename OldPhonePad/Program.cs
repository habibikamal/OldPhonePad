using System.Text;

namespace OldPhonePad
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("33# : "+OldPhonePad("33#"));
            Console.WriteLine("227*#= : " + OldPhonePad("227*#"));
            Console.WriteLine("4433555 555666# : " + OldPhonePad("4433555 555666#"));
            Console.WriteLine("8 88777444666 * 664# : " + OldPhonePad("8 88777444666 * 664#"));
        }

        public static string OldPhonePad(string input)
        {
            if (input[input.Length-1]!='#')
            {
                return "String is not valid.";
            }

            List<string> mapKeys = new List<string>
            {
                null,       // Index 0
                null,       // Index 1
                "ABC",      // Index 2
                "DEF",      // Index 3
                "GHI",      // Index 4
                "JKL",      // Index 5
                "MNO",      // Index 6
                "PQRS",     // Index 7
                "TUV",      // Index 8
                "WXYZ",     // Index 9
                
            };
            string output = "";
            int numberSameKey = 1;
            for (int i = 0; i < input.Length; i++)
            {
                //var temp= input[i];
                if (input[i]=='#')
                {
                    break;
                }

                if (input[i] == '*')
                {
                    if (output.Length>0)
                    {
                        output= output.Remove(output.Length - 1);
                        i++;
                    }
                    continue;
                }

                if (input[i]==' ')
                {
                    numberSameKey = 1;
                }
                else if (input[i]== input[i+1])
                {
                    numberSameKey++;
                }
                else
                {
                    //int number = int.Parse(input[i].ToString());
                    var map = mapKeys[int.Parse(input[i].ToString())];
                    output +=  map.Substring(numberSameKey-1, 1);
                    numberSameKey = 1;
                }
            }

            return output;
        }
    }
}
