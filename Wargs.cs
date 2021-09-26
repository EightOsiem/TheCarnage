using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace ogarOdZera
{

    class wArgs
    {
        public static string FACE_DIRECTORY = "files\\monstersFaces.txt";
        public static string BODY_DIRECTORY = "files\\monstersBodies.txt";
        public static string NAME_DIRECTORY = "files\\monstersNames.txt";
        public static string FILE_DIRECTORY = "files\\wyniki.txt";
        
       public static void SaveToFile(string MonName, string nickname, double Score)
        {
            using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@FILE_DIRECTORY, true))
            {
                file.WriteLine((Score.ToString() + " - " + nickname + "                         ").Substring(0,25) + " Zabity przez: " + MonName); 
            }
        }


        internal static string Intro()
        {

            Console.SetCursorPosition(15,30);
            Console.WriteLine("Welcome! Bold of you to come into this dark place. Brace yourself for monster-slaying carnage!");
            // Console.WriteLine( "Square root = \u221A" );
            Console.CursorTop = 50;
            Console.ResetColor();
            Console.WriteLine("__________________________________________________________________");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("Choose your name:");
            Console.ResetColor();
            string nickname = Console.ReadLine();
            VoidNorArg.ClearConsoleLineFrom(1);
            Console.WriteLine("Welcome, o'mighty "+ nickname);
            Thread.Sleep(1500);
            VoidNorArg.ClearCurrentConsoleLine(1);
            Console.WriteLine("Try not to die... ");
            Thread.Sleep(1000);
            Console.WriteLine("                 ... at least not too soon..");
            Thread.Sleep(2000);
            Console.Clear();
            return nickname;
        }
    

        internal static void ShowHealthBars(string MonName, string nickname, double score, double playersHealth, double ZyciePotwora)

        {  
            for (int i = 0; i <1; i++) 
            {
                Console.SetCursorPosition(0,i);
                Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            }  
           Console.SetCursorPosition(0,0);
           Console.Write("score:" + score + " " + nickname + ": ");
           for (int i = 1; i <= playersHealth; i++) Console.Write("[] ");
         
           Console.Write("   " + MonName +" : ");
           if (ZyciePotwora<=10) {
                for (int i = 1; i <= ZyciePotwora; i++) Console.Write("[] ");
           }
           else
           
             for (int i = 1; i <= ZyciePotwora; i++) Console.Write("[]");
            
            Console.WriteLine("\n___________________________________________________________________________________________________");
        }
    
    
        internal static void MonstersDeathAnimation(string potwor)
        {
                Console.Clear();
                //wybuch 1
                Console.WriteLine(potwor.Replace("#","*"));
                Thread.Sleep(100);
                Console.Clear();
                //wybuch 2
                Console.WriteLine(potwor.Replace("#",".").Replace("@","-").Replace("/","'").Replace("%","/").Replace("$","|").Replace("x","-").Replace("X","-"));
                Thread.Sleep(70);
                Console.Clear();
                //wybuch 3
                Console.WriteLine(potwor.Replace("#"," ").Replace("@"," ").Replace("/"," ").Replace("\\","'").Replace("x",".").Replace("X",".").Replace("$","'").Replace("|","'").Replace("(","'").Replace(")","'").Replace("_",".").Replace("%",","));
                Thread.Sleep(70);
                Console.Clear();
                //wybuch 4
                Console.WriteLine(potwor);
                Thread.Sleep(20);
                Console.Clear();
                Console.WriteLine(potwor.Replace("        "," ").Replace(" ","  "));
                Thread.Sleep(30);
                Console.Clear();
                Console.WriteLine(potwor.Replace("        "," ").Replace(" ","  ").Replace("#"," ").Replace("@"," ").Replace("x","-").Replace("X","-").Replace("$","'").Replace("/"," ").Replace("\\","'").Replace("|","'").Replace("(","'").Replace(")","'").Replace("_",".").Replace("%",","));
                Thread.Sleep(30);
                Console.Clear();
                Thread.Sleep(500);
        }
    
        internal static string MonstersShapeGenerator(string monstersShape)
        {
            string n = "\n";
            string text = System.IO.File.ReadAllText(@FACE_DIRECTORY);
            string[] monsterFaceArr = text.Split("NewFacePlaceHolder");
            int indexOfArray = new Random().Next(0,monsterFaceArr.Length-1);
            monstersShape =monsterFaceArr[indexOfArray].Replace("\r\n","");

            text = System.IO.File.ReadAllText(@BODY_DIRECTORY);
            string[] monsterBodyArr =  text.Split("NewBodyPlaceHolder");
            indexOfArray = new Random().Next(0,monsterBodyArr.Length-1);

            monstersShape = monstersShape + n + monsterBodyArr[indexOfArray].Replace("\r\n","");
            monstersShape = monstersShape.Replace("NewLinePlaceHolder", Environment.NewLine);
            // System.Console.WriteLine(monstersShape);
            return monstersShape;
        }
    
        internal static string MonstersNameGenerator()
        {
            
            Random losowy = new Random();
            //int wierszTablicy = losowy.Next(0,2);
            string text = System.IO.File.ReadAllText(@NAME_DIRECTORY);
            // string[] namePart1out3 = text.Split("NewPartSeparator")(0).Split("SEP");
            string[] namePoolPart1out3 = text.Split("NewPartSeparator")[0].Split("SEP");
            string[] namePoolPart2out3 = text.Split("NewPartSeparator")[1].Split("SEP");
            string[] namePoolPart3out3 = text.Split("NewPartSeparator")[2].Split("SEP");

            int randomNumber = losowy.Next(0,namePoolPart1out3.Length-1); //debug info
            // string przymiotnikPotwora = (namePart1out3[0,losowy.Next(0,35)]);
            string monstersName = namePoolPart1out3[randomNumber];
            monstersName = monstersName + namePoolPart2out3[losowy.Next(0,namePoolPart2out3.Length-1)];
            monstersName = monstersName + namePoolPart3out3[losowy.Next(0,namePoolPart3out3.Length-1)];
            return monstersName;
        }
    
        internal static string dmgDealtToMonster(string monsterShape)
        {      
               
        monsterShape = monsterShape.Replace("#","/").Replace("@","o").Replace("/","|").Replace("%","/").Replace("$","S").Replace("x","-").Replace("X","-");       
        return monsterShape;
        }

        internal static void endAnimation(string monsterName)
        {             
        string endComment = "\n \n    NIOM! NIOM! NIOM! \n                        Zabija Cie: "+monsterName+" \n \n \n   GAME OVER!  \n \n \n";
        VoidNorArg.ClearConsoleLineFrom(0);
        Console.WriteLine("\n           ~~~~~~~~~~                  " + "\n" + "       ## /  \\  /   \\ #     " + "\n" + "        #&|  o ^^o   |$#         " + "\n" + "           \\   @@  //             " + "\n" + "           /#\\## / _#__                " + "\n" + "      (:o)/\\\\ E&# \\##\\          " + "\n" + "          ?  |##|\\## |#|       " + "\n" + "          *   \\#/#\\###/       " + "\n" + "         /     #oo##---       " + "\n" + "        /    ### ' ##         " + "\n" + "          ####      ###,     " + "\n \n \n");
        Console.WriteLine(endComment);
        Thread.Sleep(200);
        VoidNorArg.ClearConsoleLineFrom(0);
        Console.WriteLine("\n           ~~~~~~~~~~                  " + "\n" + "       ## /  \\  /   \\ #     " + "\n" + "        #&|  o ^^o   |$#         " + "\n" + "           \\  .--. //             " + "\n" + "           /#\\## / _#__                " + "\n" + "      (:o)/\\\\ E&# \\##\\          " + "\n" + "          ?  |##|\\## |#|       " + "\n" + "          *   \\#/#\\###/       " + "\n" + "         /     #oo##---       " + "\n" + "        /    ### ' ##         " + "\n" + "          ####      ###,     " + "\n \n \n");
        Console.WriteLine(endComment);
        Thread.Sleep(200);
        VoidNorArg.ClearConsoleLineFrom(0);
        }
        

    
    }
}

