using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace IndianaJonesGame
{
    
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
                "Do you have what it takes to make it to the end and find the Holy Grail and make it out alive?!\n" +
                "You are at the entrance to the Venetian Catacomb. There are 3 passageways in front of you \n" +
                "to the left is the Queen's Ruby Room, on the right is the Prince's Golden Room and straight ahead \n " +
                "is the Silver King's Room. Choose carefully!\n\n" +
                "Please enter the direction of the passageway you wish to try");
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
                    Console.WriteLine("Oh No! A trap door brought you back to the entrance\n\n" +
                        "Ouch, 'that's usually when the ground falls beneath your feet'.\n" +
                        "Try again 'Junior', Do you wish to go left to the Queen's Ruby Room, right to the Prince's Golden Room, or straight to the Silver King's Room?");
                }
                else if (command.Contains("straight") && currentCatacomb == entrance)
                {
                    Console.Clear();
                    currentCatacomb = entrance;
                    Console.WriteLine("Hahaha, you fell down the pit and are now back at the entrance\n\n" +
                        "You have chosen..... Poorly. \n" +
                        "Do you wish to go left to the Queen's Ruby Room, right to the Prince's Golden Room, or straight to the Silver King's Room?");
                }
                else if (command.Contains("right") && currentCatacomb == entrance)
                {
                    Console.Clear();
                    currentCatacomb = goldRoom;
                    Console.WriteLine("Welcome to the Prince's Golden Room\n\n" +
                        "You have chosen.... Wisely. \n" +
                        "There are now 2 passageways in front of you. Prove your worthiness by choosing the correct way: \n" +
                        "left to the Puzzle Room or straight to the Jigsaw Room. Which will you choose?");
                }
                else if (command.Contains("straight") && currentCatacomb == goldRoom)
                {
                    Console.Clear();
                    currentCatacomb = entrance;
                    Console.WriteLine("You walked through a hidden stone wall that sent you back to the entrance of the catacomb...... Dummy\n\n" +
                        "'You lost today kid, But that doesn't mean you have to like it'! \n" +
                        "Do you wish to go to the left to the Queen's Ruby Room, right to the Prince's Golden Room, or straight to the Silver King's Room?");
                }
                else if (command.Contains("left") && currentCatacomb == goldRoom)
                {
                    Console.Clear();
                    currentCatacomb = puzzleRoom;
                    Console.WriteLine("'We are only one step away now', do you want to go left to the King's Treasure Vault or right to the Prince's Coffers?");
                }
                else if (command.Contains("left") && currentCatacomb == puzzleRoom)
                {
                    Console.Clear();
                    currentCatacomb = entrance;
                    BoulderDrop();
                    Console.WriteLine("You set off the boulder trap. A massive boulder chases you all the way back to the catacomb entrance\n\n" +
                        "'And in this sort of race, there's no silver medal for finishing second'. you certainly went the wrong way!\n\n" +
                        "Welcome back, do you remember which way to go? Left to the Queen's Ruby Room, right to the Prince's Golden Room, or straight to the Silver King's Room?");
                }
                else if (command.Contains("right") && currentCatacomb == puzzleRoom)
                {
                    Console.Clear();
                    currentCatacomb = treasureRoom;
                    Console.WriteLine("You see an empty room with a wooden cup filled with water. Drink and be granted eternal life.\n\n\n" +
                        "The only exit is straight ahead where you can see the sunlight beaming down and hear birds chirping.");
                }
                else if (command.Contains("straight") && currentCatacomb == treasureRoom)
                {
                    Console.Clear();
                    currentCatacomb = exit;
                    Console.WriteLine("Congrautlations kid, you not only have immortality but you found your way out of the dangerous catacomb and won the game! \n" +
                        "Thanks for coming on this adventure.\n\n\n" +
                        "Do you want to play again? (yes or no)");
                }
                else if (command.Contains("yes") && currentCatacomb == exit)
                {
                    Console.Clear();
                    currentCatacomb = entrance;
                    Console.WriteLine("Welcome to Indiana Jones and the Last Temple of the Lost Arc Crusade maze game. " +
                "Do you have what it takes to make it to the end and find the Holy Grail and make it out alive?!\n" +
                "You are at the entrance to the Venetian Catacomb. There are 3 passageways in front of you \n" +
                "to the left is the Queen's Ruby Room, on the right is the Prince's Golden Room and straight ahead \n " +
                "is the Silver King's Room. Choose carefully!\n\n" +
                "Please enter the direction of the passageway you wish to try");
                }
                else if (command.Contains("no") && currentCatacomb == exit)
                {
                    Console.Clear();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ooooops you must have slipped and hit your head. Hope you remember which way you wanted to go? (left, right, or straight)?");
                }
            }
        }



        public void BoulderDrop()
        {
            Console.WriteLine("                                                                            0/\n" +
                   "                                                                            /\n" +
                   "                                                                           /\n" +
                   "                                                                          /\n" +
                   "                                                                         /\n" +
                   "                                                                        /\n" +
                   "                                                                       /\n" +
                   "                                                                      /\n" +
                   "                                                                      |\n" +
                   "                                                                      |\n" +
                   "                                                                      |\n" +
                   "                                                                      |\n");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("                                                                             /\n" +
                            "                                                                           0/\n" +
                            "                                                                           /\n" +
                            "                                                                          /\n" +
                            "                                                                         /\n" +
                            "                                                                        /\n" +
                            "                                                                       /\n" +
                            "                                                                      /\n" +
                            "                                                                      |\n" +
                            "                                                                      |\n" +
                            "                                                                      |\n" +
                            "                                                                      |\n");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("                                                                             /\n" +
                           "                                                                            /\n" +
                           "                                                                          0/\n" +
                           "                                                                          /\n" +
                           "                                                                         /\n" +
                           "                                                                        /\n" +
                           "                                                                       /\n" +
                           "                                                                      /\n" +
                           "                                                                      |\n" +
                           "                                                                      |\n" +
                           "                                                                      |\n" +
                           "                                                                      |\n");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("                                                                             /\n" +
                            "                                                                            /\n" +
                            "                                                                           /\n" +
                            "                                                                         0/\n" +
                            "                                                                         /\n" +
                            "                                                                        /\n" +
                            "                                                                       /\n" +
                            "                                                                      /\n" +
                            "                                                                      |\n" +
                            "                                                                      |\n" +
                            "                                                                      |\n" +
                            "                                                                      |\n");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("                                                                             /\n" +
                                "                                                                            /\n" +
                                "                                                                           /\n" +
                                "                                                                          /\n" +
                                "                                                                        0/\n" +
                                "                                                                        /\n" +
                                "                                                                       /\n" +
                                "                                                                      /\n" +
                                "                                                                      |\n" +
                                "                                                                      |\n" +
                                "                                                                      |\n" +
                                "                                                                      |\n");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("                                                                             /\n" +
                            "                                                                            /\n" +
                            "                                                                           /\n" +
                            "                                                                          /\n" +
                            "                                                                         /\n" +
                            "                                                                       0/\n" +
                            "                                                                       /\n" +
                            "                                                                      /\n" +
                            "                                                                      |\n" +
                            "                                                                      |\n" +
                            "                                                                      |\n" +
                            "                                                                      |\n");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("                                                                             /\n" +
                                "                                                                            /\n" +
                                "                                                                           /\n" +
                                "                                                                          /\n" +
                                "                                                                         /\n" +
                                "                                                                        /\n" +
                                "                                                                      0/\n" +
                                "                                                                      /\n" +
                                "                                                                      |\n" +
                                "                                                                      |\n" +
                                "                                                                      |\n" +
                                "                                                                      |\n");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("                                                                             /\n" +
                               "                                                                            /\n" +
                               "                                                                           /\n" +
                               "                                                                          /\n" +
                               "                                                                         /\n" +
                               "                                                                        /\n" +
                               "                                                                       /\n" +
                               "                                                                     0/\n" +
                               "                                                                      |\n" +
                               "                                                                      |\n" +
                               "                                                                      |\n" +
                               "                                                                      |\n");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("                                                                             /\n" +
                               "                                                                            /\n" +
                               "                                                                           /\n" +
                               "                                                                          /\n" +
                               "                                                                         /\n" +
                               "                                                                        /\n" +
                               "                                                                       /\n" +
                               "                                                                  \\ //\n" +
                               "                                                                    0 |\n" +
                               "                                                                      |\n" +
                               "                                                                      |\n" +
                               "                                                                      |\n");
            Thread.Sleep(1000);
            Console.Clear();
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