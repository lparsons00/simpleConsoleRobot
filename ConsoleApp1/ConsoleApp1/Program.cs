using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            int direction = -1;
            string input = "", trimmedInput;

            while(input != "exit")
            {
                switch (input)
                {
                    case "place":
                        placementDecision(ref x, ref y);
                        if (direction == -1)
                            directionDecision(ref direction);
                        break;
                    case "move":
                        if (direction == -1)
                            break;
                        moveRobot(ref x, ref y, direction);
                        break;
                    case "report":
                        if (direction == -1)
                            break;
                        Console.WriteLine("Robot Location:" + x + ", " + y);
                        break;
                    case "left":
                        if (direction == -1)
                            break;
                        changeDirection("left", ref direction);
                        break;
                    case "right":
                        if (direction == -1)
                            break;
                        changeDirection("right", ref direction);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Please type a command: PLACE, MOVE, REPORT, LEFT, RIGHT" +
                    "\nEXIT to close app.");
                input = Console.ReadLine();
                trimmedInput = String.Concat(input.Where(c => !Char.IsWhiteSpace(c)));
                trimmedInput = trimmedInput.ToLower();
            }
        }


        private static void placementDecision(ref int x, ref int y)
        {
            string input, trimmedInput;
            bool successfulPlacement = false;

            while (!successfulPlacement)
            {
                Console.WriteLine("Please type a location for the robot placement. " +
                "\nShould be in x,y form.");

                input = Console.ReadLine();
                trimmedInput = String.Concat(input.Where(c => !Char.IsWhiteSpace(c)));
                trimmedInput = trimmedInput.Replace(",", "");
                if (trimmedInput.Length == 2)
                {
                    Console.WriteLine(trimmedInput);
                    if ((Int32.TryParse(trimmedInput.Substring(0, 1), out x)) &&
                        (Int32.TryParse(trimmedInput.Substring(trimmedInput.Length - 1), out y)))
                    {
                        //check within bounds 
                        if ((-1 < x) && (x < 7) && (-1 < y) && (y < 7))
                        {
                            successfulPlacement = true;
                        }
                    }
                }
            }
        }

        private static void directionDecision(ref int direction)
        {
            string input, trimmedInput;
            bool successfulDirection = false;

            while (!successfulDirection)
            {
                Console.WriteLine("Please type a direction for the robot. " +
                "\nShould be either 'north', 'south', 'east' or 'west'");
                input = Console.ReadLine();
                trimmedInput = String.Concat(input.Where(c => !Char.IsWhiteSpace(c)));
                trimmedInput = trimmedInput.ToLower();

                switch (trimmedInput)
                {
                    case "north":
                        direction = 0;
                        successfulDirection = true;
                        break;
                    case "south":
                        direction = 2;
                        successfulDirection = true;
                        break;
                    case "east":
                        direction = 1;
                        successfulDirection = true;
                        break;
                    case "west":
                        direction = 3;
                        successfulDirection = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void moveRobot(ref int x, ref int y, int direction)
        {
            if (((x == 0) && (direction == 3)) ||
                    ((x == 5) && (direction == 1)) ||
                    ((y == 0) && (direction == 0)) ||
                    ((y == 5) && (direction == 2)))
            {
                Console.WriteLine("Warning: this move would push the robot off the table.");
            }
            else
            {
                //valid
                switch (direction)
                {
                    case 0:
                        y++;
                        break;
                    case 1:
                        x++;
                        break;
                    case 2:
                        y--;
                        break;
                    case 3:
                        x--;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void changeDirection( string directionChange, ref int direction)
        {
            if(directionChange == "left")
            {
                direction--;
            } else if(directionChange == "right")
            {
                direction++;
            }

            if(direction > 3)
            {
                direction = direction - 4;
            } else if (direction < 0)
            {
                direction = direction + 4;
            }

        }
    }
}
