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

        bool isNotNumber_Bool = !int.TryParse(Console.ReadLine(), out int dimension_Int);

        while (isNotNumber_Bool | DimensionIsFalse_SubFunction(dimension_Int))
        {

            System.Console.WriteLine("Enter A Number Between 1 And 100");

            isNotNumber_Bool = !int.TryParse(Console.ReadLine(), out dimension_Int);
            
        }

        Console.Clear();

        System.Console.WriteLine(dimension_Int);
        
        static bool DimensionIsFalse_SubFunction(int dimension_Int)
        {

            if(99<dimension_Int)
            {
                
                Console.Clear();

                System.Console.WriteLine("Dimension Should Be Smaller Than 100");

                return true;
                
            }

            if(dimension_Int<2)
            {

                Console.Clear();                

                System.Console.WriteLine("Dimension Can't Be Smaller Than 2");

                return true;
                
            }

            return false;

        }        

        mapEniviornment_IntArray2D = new int[dimension_Int][];

        for (int row_Int = 0; row_Int < dimension_Int; row_Int++)
        {

            Console.Clear();            

            mapEniviornment_IntArray2D[row_Int] = new int[dimension_Int];     

            string? userLine_String;

            int exitCode_Int = RandomNumberGenerator.GetInt32(65535);

            while(SubFunction(row_Int,exitCode_Int,out int exit_Int,out userLine_String))
            {

                if(exitCode_Int == exit_Int) return;

                exitCode_Int = RandomNumberGenerator.GetInt32(65535);
                
            }

            bool SubFunction(int row_Int,int exitCode_Int,out int exit_Int,out string? userLine_String)
            {

                bool result_Bool = false;

                row_Int++;

                System.Console.WriteLine($"Enter Row {row_Int} (Enter \"exit\" To Close Program)");

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

                    result_Bool = true;

                    System.Console.Write("1:Length Of The String Should Be Equal To The Dimension You Picked. ");
                    
                }

                if(!ProblemRule_GeneratedRegex().IsMatch(userLine_String))
                {                    
                
                    System.Console.WriteLine("2:The Line Must Only Contain [c,b,-]");

                    result_Bool = true;
                
                }

                if(!GoalStartRule_GeneratedRegex().IsMatch(userLine_String))
                {                    
                
                    System.Console.WriteLine("3:The Line Must Only Contain One [c,b]");

                    result_Bool = true;
                
                }

                return result_Bool;

            }

            userLine_String??="";

            if(goal_Bool & userLine_String.Contains('c'))
            {

                System.Console.WriteLine("Found More Than One Goal, Exiting");
                
                return;
                
            }

            if(start_Bool & userLine_String.Contains('b'))
            {

                System.Console.WriteLine("Found More Than One Start, Exiting");
                
                return;
                
            }

            if(userLine_String.Contains('b')) start_Bool = true;

            if(userLine_String.Contains('c')) goal_Bool = true; 

            if(goal_Bool & !start_Bool)lowerStart_Bool = true;

            mapEniviornment_IntArray2D[row_Int] = [.. userLine_String.Replace("-","0").Replace("b","1").Replace("c","1")];

            System.Console.WriteLine("Row Added");

            Thread.Sleep(500);

        }

        if(!goal_Bool | !start_Bool)
        {

            System.Console.WriteLine("The Goal and/or Start Is Missing! Exiting Program");

            return;

        }

        Bot myBot_BotClass = new(mapEniviornment_IntArray2D);

        myBot_BotClass.Solve_Function(lowerStart_Bool);
                
    }

    [GeneratedRegex("^[c|b|-]*$")]
    private static partial Regex ProblemRule_GeneratedRegex();
    
    [GeneratedRegex("^(-*b?-*c?-*|-*c?-*-*b?-*)$")]
    private static partial Regex GoalStartRule_GeneratedRegex();

}