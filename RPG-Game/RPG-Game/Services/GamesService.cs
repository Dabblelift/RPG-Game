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

        public Character BuffCharacter(Character character)
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

            return character;

        }

        public void StartGame(Character character)
        {

            var field = new char[10, 10];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = '▒';
                }
            }

            field[1, 1] = character.FieldSymbol;
            character.CoordinateX = 1;
            character.CoordinateY = 1;

            var monsters = new List<Monster>();
            monsters.Add(SpawnMonster(field));

            while (true)
            {
                Console.WriteLine($"Health: {character.Health}  Mana: {character.Mana}");

                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        Console.Write(field[i, j]);
                    }
                    Console.WriteLine();
                }


                Console.WriteLine("Choose action");
                Console.WriteLine("1) Attack");
                Console.WriteLine("2) Move");

                int actionInput = 0;
                bool inputIsValid;

                do
                {
                    try
                    {
                        actionInput = int.Parse(Console.ReadLine());

                        if (actionInput != 1 && actionInput != 2)
                        {
                            throw new Exception();
                        }
                        inputIsValid = true;

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You should choose a number between 1 and 2!");
                        inputIsValid = false;
                    }

                } while (!inputIsValid);


                if (actionInput == 1)
                {
                    var monstersInRangeIndexes = new List<int>();

                    for (int i = 0; i < monsters.Count; i++)
                    {
                        if (Math.Abs(monsters[i].CoordinateX - character.CoordinateX) <= character.Range &&
                            Math.Abs(monsters[i].CoordinateY - character.CoordinateY) <= character.Range)
                        {
                            Console.WriteLine($"{i}) target with remaining blood {monsters[i].Health}");
                            monstersInRangeIndexes.Add(i);
                        }
                    }

                    if (monstersInRangeIndexes.Count > 0)
                    {

                        Console.WriteLine("Which one to Attack:");

                        do
                        {
                            try
                            {
                                actionInput = int.Parse(Console.ReadLine());

                                if (!monstersInRangeIndexes.Contains(actionInput))
                                {
                                    throw new Exception();
                                }
                                inputIsValid = true;

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("You should choose one of the monsters above!");
                                inputIsValid = false;
                            }

                        } while (!inputIsValid);

                        monsters[actionInput].Health -= character.Damage;
                        if (monsters[actionInput].Health <= 0)
                        {
                            Console.WriteLine("You killed the monster!");
                            field[monsters[actionInput].CoordinateY, monsters[actionInput].CoordinateX] = '▒';
                            monsters.RemoveAt(actionInput);
                        }
                        else
                        {
                            Console.WriteLine($"You attacked the monster! Monster's Health: {monsters[actionInput].Health}");
                        }

                        monsters.Add(SpawnMonster(field));

                    }
                    else
                    {
                        Console.WriteLine("No available targets in your range.");
                    }
                }
                else
                {
                    Console.WriteLine("Choose your direction of movement.");
                    Console.WriteLine("Your Input: ");

                    var movementInput = "";
                    bool movementInputIsValid = false;

                    do
                    {
                        movementInput = Console.ReadLine().ToUpper();

                        var characterCoordinates = new int[] { character.CoordinateY, character.CoordinateX };

                        field[character.CoordinateY, character.CoordinateX] = '▒';

                        switch (movementInput)
                        {
                            case "W":
                                character.CoordinateY--;
                                movementInputIsValid = true;
                                break;
                            case "S":
                                character.CoordinateY++;
                                movementInputIsValid = true;
                                break;
                            case "D":
                                character.CoordinateX++;
                                movementInputIsValid = true;
                                break;
                            case "A":
                                character.CoordinateX--;
                                movementInputIsValid = true;
                                break;
                            case "E":
                                character.CoordinateY--;
                                character.CoordinateX++;
                                movementInputIsValid = true;
                                break;
                            case "X":
                                character.CoordinateY++;
                                character.CoordinateX++;
                                movementInputIsValid = true;
                                break;
                            case "Q":
                                character.CoordinateY--;
                                character.CoordinateX--;
                                movementInputIsValid = true;
                                break;
                            case "Z":
                                character.CoordinateY++;
                                character.CoordinateX--;
                                movementInputIsValid = true;
                                break;
                            default:
                                Console.WriteLine("You can only use W, A, S, D, Q, E, Z, X");
                                break;
                        }


                        if (character.CoordinateY < 0 || character.CoordinateX < 0)
                        {
                            Console.WriteLine("This move is not possible.");
                            character.CoordinateY = characterCoordinates[0];
                            character.CoordinateX = characterCoordinates[1];
                        }
                        else if (field[character.CoordinateY, character.CoordinateX] != '▒')
                        {
                            Console.WriteLine("This move is not possible.");
                            character.CoordinateY = characterCoordinates[0];
                            character.CoordinateX = characterCoordinates[1];
                        }

                        field[character.CoordinateY, character.CoordinateX] = character.FieldSymbol;


                    } while (!movementInputIsValid);

                    monsters.Add(SpawnMonster(field));

                }

                foreach (var monster in monsters)
                {
                    var monsterCoordinates = new int[] { monster.CoordinateY, monster.CoordinateX };


                    if (Math.Abs(monster.CoordinateX - character.CoordinateX) <= 1 &&
                        Math.Abs(monster.CoordinateY - character.CoordinateY) <= 1)
                    {
                        Console.WriteLine($"A monster attacked you! You lost {monster.Damage} health!");
                        character.Health -= monster.Damage;
                        if (character.Health <= 0)
                        {
                            Console.WriteLine("You have been slain!");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        field[monster.CoordinateY, monster.CoordinateX] = '▒';

                        if (monster.CoordinateX > character.CoordinateX)
                        {
                            monster.CoordinateX--;
                        }

                        if (monster.CoordinateY > character.CoordinateY)
                        {
                            monster.CoordinateY--;
                        }

                        if (monster.CoordinateX < character.CoordinateX)
                        {
                            monster.CoordinateX++;
                        }

                        if (monster.CoordinateY < character.CoordinateY)
                        {
                            monster.CoordinateY++;

                        }

                        if (field[monster.CoordinateY, monster.CoordinateX] != '▒')
                        {
                            monster.CoordinateY = monsterCoordinates[0];
                            monster.CoordinateX = monsterCoordinates[1];
                        }

                        field[monster.CoordinateY, monster.CoordinateX] = monster.FieldSymbol;
                    }
                }
            }
        }

        public Monster SpawnMonster(char[,] field)
        {

            var random = new Random();

            var monster = new Monster();

            do
            {
                monster.CoordinateX = random.Next(0, 10);
                monster.CoordinateY = random.Next(0, 10);

            } while (field[monster.CoordinateY, monster.CoordinateX] != '▒');

            field[monster.CoordinateY, monster.CoordinateX] = monster.FieldSymbol;


            return monster;
        }
    }
}
