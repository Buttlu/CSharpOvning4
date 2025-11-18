using System;
using System.Diagnostics;
using System.Text;

/*
 * Frågor:
 * 1. Stacken följer Last In First Out (LIFO) och lagrar lådor (metoder). 
 *    De lådorna innehåller alla lokala variabler. 
 *    Ifall en ny metod kallas så läggs den som en ny låda på stacken, 
 *    och ifall en annan låda ska användas måste alla lådor över den tas bort först. 
 *    När en låda tas bort så tas också alla lokala variabler bort från stacken.
 *
 *    Heapen innehåller referens objekt och har ingen speciell access-ordning. 
 *    När en Reference Type skapas så läggs objektet på heapen medan en pointer till det objektet läggs på stacken. 
 *    Objekt på heapen raderas inte direkt till skillnad från stacken, 
 *    så då och då körs garbage collectorn som letar efter objekt på heapen 
 *    som inte har en pointer till sig, och i så fall raderar det.
 *
 * 2. Value Types innehåller värden medan Reference Types innehåller referenser till värden. 
 *
 * 3. ReturnValue arbetar med ints vilket är Value Types, så vid "y = x" så får y värdet 3 eftersom x = 3. Så när y ändras så ändras inte x
 *   ReturnValue2 arbetar med klasser vilket är Reference Types, så vid "y = x" så referar y till samma objekt som x, så när y ändrar värder till 4 så ändras det också på x.
 */

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>();

            do {
                Console.WriteLine($"The list currently holds {theList.Count} elements with a capacity of {theList.Capacity}");
                Console.WriteLine($"Prefix with '+' to add and with '-' to remove elements. {Environment.NewLine}Type 'r' to return");
                string? input = Console.ReadLine();
                // try catch in case the user inputs an empty string
                try {
                    char nav = input[0];
                    string value = input.Substring(1);
                    
                    switch (nav) {
                        case '+':
                            theList.Add(value);
                            Console.WriteLine($"Added {value}");
                            break;
                        case '-':
                            theList.Remove(value);
                            Console.WriteLine($"Removed {value}");
                            break;
                        case 'r':
                            return;
                        default:
                            Console.WriteLine("Invalid input, try again");
                            break;
                    }
                } catch (IndexOutOfRangeException) {
                    Console.WriteLine("Invalid input, try again");
                }                
            } while (true);

            /*
             * 1. Se ovan^.
             * 
             * 2. Kapaciteten ökar när Add() gör att List.Count > List.Capacity. 
             * T.ex. Om det är en kapacitet på 4 och användaren försöker lägga till ett 5:e element så hoppar kapaciteten till 8.
             * 
             * 3. Kapaciteten ökar (ungefär) med dubbla den förra ökningen: 0 -> 4 -> 8 -> 16 -> 32 -> 64 -> 128 -> 256.
             * 
             * 4. Att ändra storleken är en ganska dyr operation så C# vill ändra storleken så sällan 
             *    som möjligt men samtidigt hålla arrayen så liten som möjligt.
             * 
             * 5. Kapaciteten minskar aldrig.
             * 
             * 6. När man vet exakt hur många element som listan ska innehålla. 
             *    "Hämta alla personer som är över 40" -> Vet ej storlek: lista
             *    "Hämta de 100 rikaste personerna" -> Vet storlek: array
             * */
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueue = new Queue<string>();

            do {
                Console.WriteLine($"The queue currently holds: {{ {GetQueueString(theQueue)} }}");

                Console.WriteLine($"Prefix with '+' to enqueue an element and with '-' to dequeue. {Environment.NewLine}Type 'r' to return");
                string? input = Console.ReadLine();
                // try catch in case the user inputs an empty string
                try {
                    char nav = input[0];
                    string value = input.Substring(1);

                    switch (nav) {
                        case '+':
                            theQueue.Enqueue(value);
                            Console.WriteLine($"Added {value}");
                            break;
                        case '-':
                            theQueue.Dequeue();
                            Console.WriteLine($"Removed {value}");
                            break;
                        case 'r':
                            return;
                        default:
                            Console.WriteLine("Invalid input, try again");
                            break;
                    }
                } catch (IndexOutOfRangeException) {
                    Console.WriteLine("Invalid input, try again");
                }

            } while (true);


            // Se ReadME för Övning 2.1.
        }

        static string GetQueueString(Queue<string> theQueue)
        {
            StringBuilder builder = new();
            foreach (string item in theQueue) {
                builder.Append($"{item}, ");
            }
            string output = builder.ToString();
            int startIndex = output.Length - 2;
            if (startIndex > 0) output = output.Remove(startIndex);
            return output;
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

