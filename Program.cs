using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace BotBattery;

public partial class Program
{

    public static void Main(string[] args)
    {

        int[][] mapEniviornment_IntArray2D =[];

        (bool start_Bool,bool goal_Bool,bool lowerStart_Bool)=(false,false,false);

        System.Console.WriteLine("Enter A Number Between 1 And 100");

        int dimension_Int;

        while(!int.TryParse(Console.ReadLine(), out dimension_Int) | DimensionCheck_SubFunction(dimension_Int))
        {

            System.Console.WriteLine("Enter A Number Between 1 And 100");

            Console.Clear();
            
        }

        mapEniviornment_IntArray2D = new int[dimension_Int][];

        for (int row_Int = 0; row_Int < dimension_Int; row_Int++)
        {

            mapEniviornment_IntArray2D[row_Int] = new int[dimension_Int];     

            string? userLine_String;

            int exitCode_Int = RandomNumberGenerator.GetInt32(65535);

            while (SubFunction(exitCode_Int,out int exit_Int,out userLine_String))
            {

                if(exitCode_Int == exit_Int) return;

                exitCode_Int = RandomNumberGenerator.GetInt32(65535);
                
            }

            bool SubFunction(int exitCode_Int,out int exit_Int,out string? userLine_String)
            {

                bool result_Bool = true;

                System.Console.WriteLine("Enter The Row Of Elements (Enter \"exit\" To Close Program)");

                userLine_String = System.Console.ReadLine();

                userLine_String??="";

                if(userLine_String.Contains("exit"))
                {

                    exit_Int = exitCode_Int;

                    return true;

                }

                exit_Int = -1;

                if(userLine_String.Length != dimension_Int)
                {

                    result_Bool = false;

                    System.Console.Write("1:Length Of The String Should Be Equal To The Dimension You Picked. ");
                    
                }

                if(ProblemRule_GeneratedRegex().IsMatch(userLine_String))
                {                    
                
                    System.Console.WriteLine("2:The Line Must Only Contain [a,b,-]");

                    result_Bool = false;
                
                }                
                return result_Bool;

            }

            userLine_String??="";

            if(goal_Bool & userLine_String.Contains('c'))return;

            if(start_Bool & userLine_String.Contains('b'))return;

            if(userLine_String.Contains('b')) start_Bool = true;

            if(userLine_String.Contains('c')) goal_Bool = true; 

            if(goal_Bool & !start_Bool)lowerStart_Bool = true;

            mapEniviornment_IntArray2D[row_Int] = [.. userLine_String.Replace("-","0").Replace("b","1").Replace("c","1")];

        }

        if(!goal_Bool | !start_Bool)return;

        static bool DimensionCheck_SubFunction(int dimension_Int)
        {

            if(99<dimension_Int)
            {

                System.Console.WriteLine("Dimension Should Be Smaller Than 100");

                Thread.Sleep(500);
                
                return true;
                
            }

            if(dimension_Int<2)
            {

                System.Console.WriteLine("Dimension Can't Be Smaller Than 2");

                Thread.Sleep(500);
                
                return true;
                
            }

            return false;

        }        
                
    }

    [GeneratedRegex("^[c|b|-]*$")]
    private static partial Regex ProblemRule_GeneratedRegex();

}