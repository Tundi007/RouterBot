using System.Speech.Synthesis;

namespace BotBattery;
public class Bot(int[][] inputEniviornment_IntArray2D)
{

    private readonly int[,] routeCoords_IntArray = new int[2,2];

    private readonly int matrixDimension_Int = inputEniviornment_IntArray2D.Length;

    private readonly int[][] mappedEniviornment_IntArray2D = inputEniviornment_IntArray2D;

    public void Solve_Function(bool lowerStart_Bool,bool shorterStart_Bool)
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

                int columnt_Int=0;

                foreach(int element_Int in mappedEniviornment_IntArray2D[row_int])
                {

                    if(element_Int==1)
                    {

                        if(coords_Int==1)routeCoords_IntArray[coords_Int,0] = row_int;

                        routeCoords_IntArray[coords_Int,1] = columnt_Int;

                        coords_Int++;
                        
                    }

                    columnt_Int++;

                }
                
            }
            
        }

        RouteCoords_IntArray(lowerStart_Bool,shorterStart_Bool);        

    }

    void RouteCoords_IntArray(bool lowerStart_Bool,bool shorterStart_Bool)
    {
        
        string row_String = "Down";
        
        string column_String = "Left";

        int rowDifference_Int = routeCoords_IntArray[0,0]-routeCoords_IntArray[1,0];

        int columnDifference_Int = routeCoords_IntArray[0, 1] - routeCoords_IntArray[1, 1];

        if(rowDifference_Int<0) rowDifference_Int=-rowDifference_Int;

        if(columnDifference_Int<0) columnDifference_Int=-columnDifference_Int;

        if(shorterStart_Bool)
        {

            column_String = "Right";

        }

        if (lowerStart_Bool)
        {

            row_String = "UP";
            
        }

        Console.Clear();
        
        System.Console.WriteLine("Finished");

        System.Console.WriteLine();

        string b="";

        for(int y = 0; y < rowDifference_Int; y++)
        {

            b+=row_String+" ";                
            
        }

        for(int i = 0; i < columnDifference_Int;i++)
        {

            b+=column_String+" ";
            
        }

        SpeechSynthesizer speechToWav_SpeechSynthesizer = new();

        speechToWav_SpeechSynthesizer.Rate=1;

        speechToWav_SpeechSynthesizer.SelectVoiceByHints(VoiceGender.Female,VoiceAge.Adult);

        speechToWav_SpeechSynthesizer.SetOutputToWaveFile("speech.wav");

        speechToWav_SpeechSynthesizer.Speak(b);

        StreamWriter write_Stream = new("output.txt");

        write_Stream.WriteLine(b);

        write_Stream.Dispose();

        System.Console.WriteLine("Press Any Key To Close");

        Console.ReadKey();
    
    }

}