using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IndianaJonesGame
{
    //what words need to show up | attempt counter showing how many times "died"
    // Riddle/Puzzle in each room to help along correct path | anything else
    //DO we add Parchment to have for the riddle/puzzle?
    class Program_UI
    {
        public static Catacomb entrance = new Catacomb(
            "\n\n\n\n\nYou******************\n\n\n" +
            "The obvious paths are left, right and straight",
            new List<string> { "left", "right", "straight" }); //right to goldRoom
        public static Catacomb goldRoom = new Catacomb(
            "\n\n\n\n\nYou*****************\n\n\n" +
            "The obvious paths are left and straight",
            new List<string> { "left", "straight" }); //left to puzzle room
        public static Catacomb puzzleRoom = new Catacomb(
            "\n\n\n\n\nYou***************\n\n\n" +
            "The obvious paths are left and right",
            new List<string> { "left", "right" }); //right treasureroom
        public static Catacomb treasureRoom = new Catacomb(
            "\n\n\n\n\nMoney,Cash,Prizes*************\n\n\n" +
            "The*********************",
            new List<string> { "straight" });//exit
        public static Catacomb exit = new Catacomb(
            "\n\n\n\n\nYou**************" +
            "Congratus you win!",
            new List<string> { "arrive" });
        //Four bad rooms
        public static Catacomb leftTrapDoor = new Catacomb(
            "\n\n\n\n\n\n Trap Door! Ouch!",
            new List<string> { "left", "right", "straight" });
        public static Catacomb straightPitFall = new Catacomb(
            "\n\n\n\n\n\n AHHHHHHHHHHHHHHHHHHHHHH you fell down a hole that leads back to the entrance",
            new List<string> { "left", "right", "straight" });
        public static Catacomb rightPortal = new Catacomb(
            "\n\n\n\n\n Awwww drat you walked through a portal and eneded up back at the cave entrance",
            new List<string> { "left", "right", "straight" });
        public static Catacomb leftBolder = new Catacomb(
            "\n\n\n\n\n RUN!!!!!!!! You trigged the boulder trap.",
            new List<string> { "left", "right", "center" });
        public void Run()
        {
            Catacomb currentCatacomb = entrance;
            Console.Clear();
            Console.WriteLine("Welcome to Indiana Jones and the Last Temple of the Lost Arc Crusade maze game. " +
                "Do you have what it takes to make it to the end and find the Holy Grail!\n" +
                "There are 3 paths in front of you left to the Queen's Ruby Room, right to the Prince's Golden Room and straight to the Silver Kings Room. Choose carefully!\n\n" +
                "Please enter the path you wish to try");
            bool alive = true;
            while (alive)
            {
                string command = Console.ReadLine().ToLower().Trim();
                Console.Clear();
                Console.WriteLine("Direction options");
                if (command.Contains("left") && currentCatacomb == entrance)
                {
                    Console.Clear();
                    currentCatacomb = entrance;
                    Console.WriteLine("Oh No trap door brought you back to the entrance\n\n" +
                        "You chose...... Poorly.\n" +
                        "Do you wish to go to the left Queen's Ruby Room, right to the Prince's Golden Room, or straight to the Silver Kings Room?");
                }
                else if (command.Contains("straight") && currentCatacomb == entrance)
                {
                    Console.Clear();
                    currentCatacomb = entrance;
                    Console.WriteLine("HAHAHA you fell down the pit and are not back at the entrance\n\n" +
                        "You chose..... Poorly. \n" +
                        "Do you wish to go to the left Queen's Ruby Room, right to the Prince's Golden Room, or straight to the Silver Kings Room?");
                }
                else if (command.Contains("right") && currentCatacomb == entrance)
                {
                    Console.Clear();
                    currentCatacomb = goldRoom;
                    Console.WriteLine("Welcome to the Prince's Golden Room\n\n" +
                        "You chose.... Wisely\n" +
                        "There are now 2 paths in front of you left to the Puzzel Room or straight to the Jigsaw Room. Which will you choose?");
                }
                else if (command.Contains("straight") && currentCatacomb == goldRoom)
                {
                    Console.Clear();
                    currentCatacomb = entrance;
                    Console.WriteLine("You walked through a portal that sent you back to the cave entrance...... Dummy\n\n" +
                        "Lets play again. Do you wish to go to the left Queen's Ruby Room, right to the Prince's Golden Room, or straight to the Silver Kings Room?");
                }
                else if (command.Contains("left") && currentCatacomb == goldRoom)
                {
                    Console.Clear();
                    currentCatacomb = puzzleRoom;
                    Console.WriteLine("You solved the riddle...... Now do you want to go left to the King's Treasure Vault or right to the Prince's Coffers?");
                }
                else if (command.Contains("left") && currentCatacomb == puzzleRoom)
                {
                    Console.Clear();
                    currentCatacomb = entrance;
                    Console.WriteLine("You set off the bolder trap. A giant bolder chases you all the way back to the cave entrance\n\n" +
                        "Holy Crap..... You went the wrong way!\n\n" +
                        "Welcome back to the begining do you remember which way to go to the left Queen's Ruby Room, right to the Prince's Golden Room, or straight to the Silver Kings Room?");
                }
                else if (command.Contains("right") && currentCatacomb == puzzleRoom)
                {
                    Console.Clear();
                    currentCatacomb = treasureRoom;
                    Console.WriteLine("You see an empty room witha a wooden cup filled with water. Drink and have immortality inscribed above it.\n\n\n" +
                        "The only exit is straight ahead where you can see the sunlight and hear birds chirping.");
                }
                else if (command.Contains("straight") && currentCatacomb == treasureRoom)
                {
                    Console.Clear();
                    currentCatacomb = exit;
                    Console.WriteLine("Congrautlations kid you have left the cave and the game. Thanks for playing\n\n\n" +
                        "Do you want to play again? (yes or no)");
                }
                else if (command.Contains("yes") && currentCatacomb == exit)
                {
                    Console.Clear();
                    currentCatacomb = entrance;
                    Console.WriteLine("Welcome to Indiana Jones and the Last Temple of the Lost Arc Crusade maze game. " +
                "Do you have what it takes to make it to the end and find the Holy Grail!\n" +
                "There are 3 paths in front of you left to the Queen's Ruby Room, right to the Prince's Golden Room and straight to the Silver Kings Room. Choose carefully!\n\n" +
                "Please enter the path you wish to try");
                }
                else if (command.Contains("no") && currentCatacomb == exit)
                {
                    Console.Clear();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ooooops you slipped and fell down. Which way did you want to go (left, right, or straight)?");
                }
            }
        }
    }
    public class Catacomb
    {
        public string Splash { get; }
        public List<string> Paths { get; }
        public Catacomb(string splash, List<string> paths)
        {
            Splash = splash;
            Paths = paths;
        }
    }
}