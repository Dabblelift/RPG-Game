using RPG_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Services
{
    public class GamesService : IGamesService
    {
        public ApplicationDbContext db { get; }

        public GamesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Press any key to play.");
            Console.ReadKey();
            Console.WriteLine();
        }

        public Character SelectCharacter()
        {
            var input = 0;
            var inputIsValid = true;

            Console.WriteLine("Choose character type:");
            Console.WriteLine("Options:");
            Console.WriteLine("1) Warrior");
            Console.WriteLine("2) Archer");
            Console.WriteLine("3) Mage");
            Console.Write("Your pick: ");
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());

                    if (input < 1 || input > 3)
                    {
                        throw new Exception();
                    }
                    inputIsValid = true;

                }
                catch (Exception)
                {
                    Console.WriteLine("You should choose a number between 1 and 3!");
                    inputIsValid = false;
                }

            } while (!inputIsValid);

            if (input == 1)
            {
                return new Warrior();
            }
            else if (input == 2)
            {
                return new Archer();
            }
            else
            {
                return new Mage();
            }
        }

        public void BuffCharacter(Character character)
        {
            var buffInput = "";
            var buffInputIsValid = true;

            Console.WriteLine("Would you like to buff up your stats before starting?    (Limit: 3 points total)");
            Console.Write("Response (Y/N): ");
            do
            {
                try
                {
                    buffInput = Console.ReadLine().ToUpper();

                    if (buffInput != "Y" && buffInput != "N")
                    {
                        throw new Exception();
                    }
                    buffInputIsValid = true;

                }
                catch (Exception)
                {
                    Console.WriteLine("You should select \"Y\" or \"N\"!");
                    buffInputIsValid = false;
                }

            } while (!buffInputIsValid);

            if (buffInput == "Y")
            {
                var points = 3;
                var pointsInput = 0;
                var pointsInputIsValid = true;

                Console.WriteLine("Remaining Points: " + points);
                Console.Write("Add To Strength: ");
                do
                {
                    try
                    {
                        pointsInput = int.Parse(Console.ReadLine());

                        if (pointsInput < 0 || pointsInput > points)
                        {
                            throw new Exception();
                        }
                        pointsInputIsValid = true;

                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"You should choose a number between 0 and {points}!");
                        pointsInputIsValid = false;
                    }

                } while (!pointsInputIsValid);

                character.Strength += pointsInput;
                points -= pointsInput;

                if (points != 0)
                {

                    Console.WriteLine("Remaining Points: " + points);
                    Console.Write("Add To Agility: ");
                    do
                    {
                        try
                        {
                            pointsInput = int.Parse(Console.ReadLine());

                            if (pointsInput < 0 || pointsInput > points)
                            {
                                throw new Exception();
                            }
                            pointsInputIsValid = true;

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"You should choose a number between 0 and {points}!");
                            pointsInputIsValid = false;
                        }

                    } while (!pointsInputIsValid);

                    character.Agility += pointsInput;
                    points -= pointsInput;
                }

                if (points != 0)
                {

                    Console.WriteLine("Remaining Points: " + points);
                    Console.Write("Add To Intelligence: ");
                    do
                    {
                        try
                        {
                            pointsInput = int.Parse(Console.ReadLine());

                            if (pointsInput < 0 || pointsInput > points)
                            {
                                throw new Exception();
                            }
                            pointsInputIsValid = true;

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"You should choose a number between 0 and {points}!");
                            pointsInputIsValid = false;
                        }

                    } while (!pointsInputIsValid);

                    character.Intelligence += pointsInput;
                }

            }

            character.Setup();
            db.Characters.Add(character);
            db.SaveChanges();

        }

    }
}
