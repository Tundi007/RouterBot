namespace BotBattery;

public class Program
{

    public static void Main(string[] args)
    {

        string[][] mapEniviornment_StringArray2D =[];

        System.Console.WriteLine("Enter A Number Between 1 And 100");

        while(!int.TryParse(Console.ReadLine(), out int dimension_Int) | DimensionCheck_SubFunction(dimension_Int))
        {

            System.Console.WriteLine("Enter A Number Between 1 And 100");

            Console.Clear();
            
        }

        bool DimensionCheck_SubFunction(int dimension_Int)
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

}