 using System;
 using System.Threading;


namespace ogarOdZera
{
    class VoidNorArg
    {
    public static string FILE_DIRECTORY = "files\\wyniki.txt";
    public static string INTRO_DIRECTORY = "files\\intro.txt";
    public static string hero1_DIRECTORY = "files\\hero1.txt";
    public static string hero2_DIRECTORY = "files\\hero2.txt";

    
     
       public static void animationHighScore(double score)
        {   
          string text = System.IO.File.ReadAllText(@hero2_DIRECTORY);
      
            //Console.BackgroundColor = ConsoleColor.DarkGray;
            System.Console.WriteLine(text);
            Console.SetCursorPosition(20,40);
            System.Console.WriteLine("Kolo, idzie Ci zajebiscie. Twoj aktualny score to: " + score.ToString());
            System.Console.WriteLine("Nacisnij przycisk, gdy bedziesz gotów.");
            Console.ReadKey();
            Console.ResetColor();
            VoidNorArg.ClearConsoleLineFrom(1);
        }
     
     public static void animationIntro()
        {   
          string text = System.IO.File.ReadAllText(@hero1_DIRECTORY);
            System.Console.WriteLine(text);
            //Thread.Sleep(5000);
            Console.ResetColor();
        }
    
    
    public static void animationIntroOLD()
        {   
          string text = System.IO.File.ReadAllText(@INTRO_DIRECTORY);
          string[] myIntroArr = text.Split("SEPARATOR");
          Random rnd3 = new Random();

            int myRndNumber = rnd3.Next(0,myIntroArr.Length-1);

            for (int i = 0; i < 1; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                System.Console.WriteLine(myIntroArr[myRndNumber]);
                Thread.Sleep(1000);
                Console.ResetColor();
            }
        }
        
    

    public static void readFile()
        {
            Console.WriteLine("current scores:");

            try
            {
            string text = System.IO.File.ReadAllText(@FILE_DIRECTORY);
            Console.WriteLine(text);
            }
            catch (System.Exception)
            {                
            throw;
            }
            finally
            {
            // Console.WriteLine("aby zagrac wcisnij enter");
            }

        }
   
    internal static void dmgDealtToPlayer()
        
        {               
            Console.BackgroundColor = ConsoleColor.DarkRed;
            //Console.Clear();
            Console.WriteLine(" otrzymałeś obrażenia! ");
            Thread.Sleep(580);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            //Console.Clear();
            VoidNorArg.ClearCurrentConsoleLine(1);
            //Console.WriteLine( "_______________________");         
        }

    internal static void dmgDealtToMonster()
        
        {               
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            //Console.Clear();
            Console.WriteLine(" ATAK UDANY!");
            Thread.Sleep(280);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            VoidNorArg.ClearCurrentConsoleLine(1);
            //Console.WriteLine( "_______________________");         
        }
    
    internal static void gameOver()
        {
            Console.BackgroundColor = ConsoleColor.Red;

            for (int i = 0; i < 2; i++)
            {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n                                           G A M E    O V E R !");
            Thread.Sleep(50);
            }
             Console.ResetColor();
        }

        internal static void ClearCurrentConsoleLine(int iloscLinijek)
        {
            //try catch
            try
            {
                Console.SetCursorPosition(0,Console.CursorTop);
                for (int i = 0; i < iloscLinijek; i++) 
                {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth)); 
                Console.SetCursorPosition(0, currentLineCursor);
                }  

            }
            catch (System.Exception)
            {

            }
            
        } 

        internal static void ClearConsoleLineFrom(int row)
        {
            //try catch
            try
            {
                int currentLineCursor = Console.CursorTop;
                int lastRow = Console.BufferHeight;
                Console.SetCursorPosition(0, row);
                for (int i = 0; i < currentLineCursor; i++) 
                {
                Console.SetCursorPosition(0, row - 1 +i);
                Console.Write(new string(' ', Console.WindowWidth)); 
                Console.SetCursorPosition(0, row);
                }  
            }
            catch (System.Exception)
            {

            }
        } 
    
        internal static string GetRandomLetter()
        {
            Random rnd2 = new Random();            
            int ascii_index2 = rnd2.Next(97, 123); //ASCII character codes 97-123
            char myRandomLowerCase = Convert.ToChar(ascii_index2); //produces any char a-z
            return myRandomLowerCase.ToString();
        }

        internal static void LowScoreNotification()
        {
            Console.WriteLine("Zostajesz zapomniany nawet przez najbliższych...");
            Thread.Sleep(1500);
            Console.WriteLine( "\n\n\n O PATRZ! \n\n\n");
            Thread.Sleep(2500);
            Console.Clear();
            Console.WriteLine("Write AGAIN to start again or QUIT to quit.\n_________________________________________________________________");
            Console.WriteLine( "\n\n\nTO sa prawdziwe sławy:\n");
            Thread.Sleep(1000);
        }
        internal static void MediumScoreNotification()
        {
            Console.Clear();
            Console.WriteLine("Write AGAIN to start again or QUIT to quit.\n_________________________________________________________________");
            Console.WriteLine("Rodzina niby Cię pamięta... Ale wzdycha do nich:");
            Thread.Sleep(1500);
        }
    
        internal static void HighScoreNotification()
        {
                Console.Clear();
                Console.WriteLine("Write AGAIN to start again or QUIT to quit.\n_________________________________________________________________");
                Console.WriteLine("Trafiłeś na liste ludzi spędzajcych sen z powiek zazdrosnych mężów... Nawet po śmierci:");
                Thread.Sleep(3000);
        }
    }
}

 
 
 
 