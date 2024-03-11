namespace BotBattery;
public class Bot(int[][] inputEniviornment_IntArray2D)
{

    private readonly int[,] routeCoords_IntArray = new int[2,2];

    private readonly int matrixDimension_Int = inputEniviornment_IntArray2D.Length;

    private readonly int[][] mappedEniviornment_IntArray2D = inputEniviornment_IntArray2D;

    public void Solve_Function(bool lowerStart_Bool)
    {

        int coords_Int = 0;        

        for (int row_Int = 0; row_Int<matrixDimension_Int; row_Int++)
        {

            for (int column_Int = 0; column_Int<matrixDimension_Int ;column_Int++)
            {

                mappedEniviornment_IntArray2D[row_Int][column_Int] -= 48;
                
            }
            
        }

        for (int row_int = 0; row_int < mappedEniviornment_IntArray2D.Length; row_int++)
        {

            if(mappedEniviornment_IntArray2D[row_int].Contains(1))
            {

                routeCoords_IntArray[coords_Int,0] = row_int;

                routeCoords_IntArray[coords_Int,1] = Array.IndexOf(mappedEniviornment_IntArray2D,1);

                coords_Int++;

                if(coords_Int>2)
                {

                    System.Console.WriteLine("Detected Multipl Starts and/or Goals! Exiting Program");

                    Thread.Sleep(1000);

                    return;

                }
                
            }
            
        }

        RouteCoords_IntArray(lowerStart_Bool);        

    }

    void RouteCoords_IntArray(bool lowerStart_Bool)
    {

        List<string>routeHeight_StringArray = [];

        List<string>routeWidth_StringArray = [];

        List<string>routeSum_StringArray = [];

        string row_String = "";

        string column_String = "";

        int columnDifference_Int;

        int rowDif_Int = routeCoords_IntArray[0,1]-routeCoords_IntArray[1,1];

        if(rowDif_Int<0) rowDif_Int=-rowDif_Int ;

        if(lowerStart_Bool)
        {

            row_String = "UP";

            columnDifference_Int = routeCoords_IntArray[0,2]-routeCoords_IntArray[1,2];

            if(columnDifference_Int<0)
            {

                columnDifference_Int = -columnDifference_Int;

                column_String = "Left";

            }else
            {

                column_String = "Right";

            }

        }else
        {

            row_String = "Down";

            columnDifference_Int = routeCoords_IntArray[0,2]-routeCoords_IntArray[1,2];

            if(columnDifference_Int<0)
            {

                columnDifference_Int = -columnDifference_Int;

                column_String = "Right";

            }else
            {

                column_String = "Left";

            }

        }

        for (int y = 0; y < rowDif_Int; y++)
        {

            System.Console.WriteLine(row_String);
            
        }

        for (int i = 0; i < columnDifference_Int; i++)
        {

            System.Console.WriteLine(column_String);
            
        }

    }

}