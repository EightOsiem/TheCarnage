using System;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using System.Linq;
using System.Collections.Generic;
namespace ogarOdZera
{

    class Program1
    {
        public static int playersHealth = 3;
        public static int monstersHealth = 3;
        public static string nickname;
        public static List<string> possibleControls = new List<string>(){"a","s","d","j","k","l"};
        // public static string FILE_DIRECTORY = System.IO.Directory.GetCurrentDirectory() + "\\wyniki.txt";
        // public static string FILE_DIRECTORY = "wyniki.txt";
        
        public static double score = 0;

        public static double mutliplier = 0.9;
        
        static void Main()
        {   
            Console.SetWindowSize(120,40);
            
            VoidNorArg.animationIntro();
            
            nickname = wArgs.Intro();
            
            score = 0;
            playersHealth = 3;
            monstersHealth = 3;

            graWlasciwa();
        }

        
        public static void graWlasciwa()
        {
            string monstersShape="";
            for (int i = 0; i < 30 ; i++)
            {
                monstersShape = wArgs.MonstersShapeGenerator(monstersShape);
                walka(monstersShape,i);
                Thread.Sleep(100);
                wArgs.MonstersDeathAnimation(monstersShape);
            }  
        }

      
        public static void walka(string monstersShape, int monsterLevel)
        {
            double czas = 0;
            int PozostalyCzas = 0;
            monsterLevel = monsterLevel + 1;
     
            double timeToReact = 4;
            string controlToDealDmg = "";
            string monstersName = wArgs.MonstersNameGenerator();
            monstersHealth = (monsterLevel);
            int dmgToMonster = 1;
            

            int pktMod = monstersHealth;
            Console.WriteLine("\n\n\n\n\n          Atakuje Cie: " + monstersName + " o sile " + monstersHealth.ToString() + " [LVL: " +  monsterLevel.ToString() + "]");
            Thread.Sleep(3000);
            
            string result = "";
            
            if (monsterLevel % 10 == 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                System.Console.WriteLine("Otrzymujesz dodatkowe zycie! Jaki fart xD");
                playersHealth = playersHealth + 1;
                Thread.Sleep(2000);
                Console.ResetColor();
            }

            if (monsterLevel % 4 == 0)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                System.Console.WriteLine("Zadajesz PODWÓJNE obrażenia! O matko!");
                dmgToMonster = 2;
                Thread.Sleep(2000);
                Console.ResetColor();
            }

            if (monsterLevel % 6 == 0)
            {
                VoidNorArg.animationHighScore(score);
            }

            switch (monsterLevel)
            {
                case < 2:
                timeToReact = 4;
                break;
                case < 5:
                timeToReact = 3;
                possibleControls.Add(VoidNorArg.GetRandomLetter());
                
                break;
                default:
                timeToReact = timeToReact - ((double)monsterLevel/7);
                possibleControls.Add(VoidNorArg.GetRandomLetter());
                break;
            }
            
            for (int m=0;m< monstersHealth ;m++)
            {
                Console.Clear();
                wArgs.ShowHealthBars(monstersName, nickname, score, playersHealth, monstersHealth);
                
                Console.WriteLine(monstersShape);
                // num = new Random().Next(0,26);
                // char litera = (char)('a' + num);
                // controlToDealDmg = Char.ToString(litera);

                int losowa = new Random().Next(0,possibleControls.Count-1);

                controlToDealDmg = (possibleControls[losowa]);
                
                DateTime beginWait = DateTime.Now;
                //     // Use up any remaining key presses
                // while (Console.KeyAvailable)
                // {
                //     // Read a single key
                //     Console.ReadKey(true);
                // }
                while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalSeconds < timeToReact)
                {
                    czas = DateTime.Now.Subtract(beginWait).TotalSeconds;
                    Console.WriteLine( "_______________________");
                    PozostalyCzas = Convert.ToInt32((timeToReact - czas)* 10);
                    Console.WriteLine( "WCISNIJ:    _" + controlToDealDmg.ToUpper() + "_    " + Math.Ceiling((timeToReact - czas) * 10)/10);
                    result = new String('-', PozostalyCzas);
                    Console.Write("ZGON:" + result);
                    Thread.Sleep(100);
                    VoidNorArg.ClearCurrentConsoleLine(2);
                }
                Thread.Sleep(250);
                if (!Console.KeyAvailable) //gracz nie wcisnął kontrolki.
                {               
                    VoidNorArg.dmgDealtToPlayer();
                    // wArgs.ShowHealthBars(monstersName, nickname, score, playersHealth, monstersHealth);
                    //Console.WriteLine(monstersShape);
                    Console.WriteLine( "_______________________");
                    Console.WriteLine(monstersName + " zadał Ci obrażenia! Nie zdążyłeś go jebnąć!");
                    Thread.Sleep(550);
                    playersHealth = playersHealth - 1;
                    timeToReact = timeToReact / mutliplier;
                    Console.ResetColor();
                    //Console.Clear();
                    m = m - 1;                   
                }
                else
                {
                    var  input = Console.ReadKey();
                    // chinput = Convert.ToChar(input);
                    if ((input.KeyChar).ToString() == controlToDealDmg) //gracz wcisnał wlasciwa kontrolke
                    {
                        VoidNorArg.dmgDealtToMonster();
                        VoidNorArg.ClearConsoleLineFrom(3);
                        Console.WriteLine(wArgs.dmgDealtToMonster(monstersShape));
                        Thread.Sleep(120);
                        VoidNorArg.ClearConsoleLineFrom(3);
                        //Console.WriteLine(monstersShape);
                        timeToReact = timeToReact * mutliplier;
                        monstersHealth = monstersHealth - dmgToMonster;
                        m = m - 1;
                        score = score + 13 + pktMod - monstersHealth + playersHealth;
                        Thread.Sleep(500);
                    }
                    else //gracz wcisnął nie własciwa kontrolkę
                    {
                        VoidNorArg.dmgDealtToPlayer();
                        Thread.Sleep(200);
                        playersHealth = playersHealth - 1;
                        timeToReact = timeToReact / mutliplier;
                        m = m - 1;
                    }
                }  
                // wArgs.ShowHealthBars(monstersName, nickname, score, playersHealth, monstersHealth);   
                VoidNorArg.ClearCurrentConsoleLine(2);


                if (playersHealth == 0)
                {
                    for (int t=0;t< 10 ;t++) VoidNorArg.gameOver();
                    for (int l=0;l< 10 ;l++) wArgs.endAnimation(monstersName);
                
                    
                        
                    Console.WriteLine("Write AGAIN to start again or QUIT to quit.\n_________________________________________________________________");
                    Console.WriteLine("           ~~~~~~~~~~                  " + "\n" + "       ## /  \\  /   \\ #     " + "\n" + "        #&|  o'^^o'  |$#         " + "\n" + "           \\  ,__, //             " + "\n" + "           /#\\## / _#__                " + "\n" + "      (;c)/\\\\ E&# \\##\\          " + "\n" + "          ?  |##|\\## |#|       " + "\n" + "          *   \\#/#\\###/       " + "\n" + "         |     #oo##---       " + "\n" + "         |   ### ' ##         " + "\n" + "          ####      ###,     " + "\n \n \n");
                   
                        Thread.Sleep(3000);
                    if (score <= 500) VoidNorArg.LowScoreNotification();
                    
                    else if(score <=1000) VoidNorArg.MediumScoreNotification();
                     
                    else
                    {
                        VoidNorArg.HighScoreNotification();
                        wArgs.SaveToFile(monstersName, nickname, score); 
                    }

                    //_____________________
                    VoidNorArg.readFile();
                    string userEndDecision = Console.ReadLine();
                    if (userEndDecision.ToLower().Contains("again")) Main();
                    else
                    {
                        VoidNorArg.animationIntro();
                        Console.SetCursorPosition(30,30);
                        System.Console.WriteLine("Thanks for playing!");
                        Thread.Sleep(3400);
                        Environment.Exit(0);
                    }
                        
                    
                }
            }
        }
    }
}

