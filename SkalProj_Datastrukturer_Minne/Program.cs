using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>

        /*Har lagt nedstående över respektive metod - är det bättre att ha de i starten?*/
        //public static List<string> theList = new List<string>();
        //public static Queue<string> theQueue = new Queue<string>();
        //public static Stack<string> theStack = new Stack<string>();

        /* Mina validate input är lite inkonsekventa, mycket upprepning av kod, 
        kan troligen förenklas med en metod som kan anropas på flera ställen ist.
        
        Jag har inte heller listat ut hur jag ska hantera varningar om null, 11 stycken.

        Fick inte till att hantera användare som bara skriver text UTAN aranteser i Övning 4 
        men koden testar paranteser både i matchande par och i sekvens. 
        
        */
        
        /* FRÅGOR:

        1. Det är två olika former av minnesallokering som båda är aktiva under körning av programet.
        Heapen lagrar som har en variabel livslängd och storlek. Typiskt som initieras under körning och håller de aktiva så länge inte Garbage Collector 
        då och då "städar" bort dem som saknar referens (pointers) om jag har förstått rätt (?).
        Det påminner om en hög där objekt är utspridda på olika platser (under "huven").
        Saker på heapen hittas alltså genom att de skapats och fortfarande har en referens, sen ligger de kvar men är svåra att nå utan referens. 
        Det tar generellt sätt längre tid att hitta, men mer flexibelt. Behöver användas om livslängden är okänd och storleken dynamisk.

        Stacken lagrar data som har en känd livslängd och en fast storlek, men bara så länge som de används, sen tas de bort automatiskt i den ordning de körs färdigt.
        Stacken är snabbare och effektivare för att komma åt den typen av värden. 

            Ex. List<int> intLista = new List<int> 

            Datatypen int kommer vara allokerad på stacken när den används som en del av en lista, 
            men listans inre datastruktur kommer vara allokerad på heapen eftersom den hanterar en 
            dynamisk samling av objekt. 
        
        2. Value Types (15 st bl.a. bool och struct) ärver från System.ValueType.
           Lagras där de deklareras. Lagras som en del av varje instans på heapen, men deklarerade den som en lokal variabel i en metod lagras den på stacken.

           Reference Types (5 st, bl.a string och class) ärver från System.Object.
           Referenserna och "instansparametrar" lagras på stacken, men själva objektet ligger på heapen.

        3. ReturnValue skapar value type int x och value type int y, x och y innehåller båda värde 3 men är fortfarande två olika  
           ReturnValue2 instanser MyInt som är reference type, x och y refererar till samma objekt (instans) som har värde 4 

        */

        static void Main()
        {
            while (true)
            {
                Console.WriteLine(":::::::::::::::: MAIN MENU :::::::::::::::::");
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application\n");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!\n");
                    continue;
                }
                switch (input)
                {
                    case '1':
                        Console.Clear();
                        ExamineList();
                        break;
                    case '2':
                        Console.Clear();
                        ExamineQueue();
                        break;
                    case '3':
                        Console.Clear();
                        ExamineStack();
                        break;
                    case '4':
                        Console.Clear();
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
                        Console.Clear();
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)\n");
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

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            while (true)
            {
                Console.WriteLine(":::::::::::::::: Welcome to The List :::::::::::::::::");
                Console.WriteLine("Please navigate through the menu by inputting the character \n(+, -, 4, 5, 0) of your choice \n"
                    + "\n+ Add things to The List"
                    + "\n- Remove things from The List"
                    + "\n4 View The List"
                    + "\n5 Get back to the main menu"
                    + "\n0 Exit the application\n");
                char input2 = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input2 = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!\n");
                    continue;
                }
                switch (input2)
                {
                    case '+':
                        Console.Clear();
                        AddToList();
                        break;
                    case '-':
                        Console.Clear();
                        RemoveFromList();
                        break;
                    case '4':
                        Console.Clear();
                        ShowContentOfList();
                        break;
                    case '5':
                        Console.Clear();
                        return;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter some valid input (+, -, 4, 5, 0)\n");
                        break;
                }
            }
        }
        public static List<string> theList = new List<string>();
        public static void AddToList()
        {
            /*
            
            Frågor: 

            1. Se koden.

            2. Den ökar när ett det inte finns mer plats, alltså dynamiskt.

            3. Den ökar med 4

            4. Det behövs inte. Den ökar när 4 platser fyllts och en ytterligare läggs till.

            5. Nej. När den väl skapat plats så kan den inte minska (iaf inte med den kod jag har skrivit). 

            6. När man vet storleken på förhand. 

            */

            Console.WriteLine(":::::::::::::::: ADDING TO THE LIST :::::::::::::::::");
            Console.WriteLine("Please enter + and then write item titel and enter.");
            Console.WriteLine("Example a name, Anna. Then write +Anna\n");
            try
            {
                string input = Console.ReadLine();
                char nav = input[0];
                string itemToAdd = input.Substring(1);
                if (itemToAdd.Length >= 2)
                {
                    theList.Add(itemToAdd);
                    Console.WriteLine($"{itemToAdd} added to The List!");
                    Console.WriteLine($"Current capacity: {theList.Capacity}!");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Item needs to be at least two characters! {input} was NOT added. Please restart.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.WriteLine("Input cannot be empty. Please restart!\n");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void RemoveFromList()
        {
            Console.WriteLine(":::::::::::::::: REMOVING FROM THE LIST :::::::::::::::::");
            Console.WriteLine("Please enter - and then write item titel you want to remove and enter.");
            Console.WriteLine("Example a name, Anna. Then write -Anna\n");
            try
            {
                string input = Console.ReadLine();
                char nav = input[0];
                string itemToRemove = input.Substring(1);
                if (itemToRemove.Length >= 1)
                {
                    if (theList.Remove(itemToRemove))
                    {
                        Console.WriteLine($"{itemToRemove} removed from The List!");
                        Console.WriteLine($"Current capacity: {theList.Capacity}!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine($"{itemToRemove} is not in The List, please try again.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine($"Item to remove needs to be at least one character! {input} was NOT removed. Please restart.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.WriteLine("Input cannot be empty. Please restart!\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void ShowContentOfList()
        {
            Console.WriteLine(":::::::::::::::: Contents of The List! :::::::::::::::::");
            int count = 0;
            foreach (string item in theList)
            {
                Console.WriteLine(item);
                count++;

            }
            Console.WriteLine($"\nCurrent number of items: {count}!");
            Console.WriteLine($"Current capacity: {theList.Capacity}!");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        public static void ExamineQueue()
        {

            /*

            Uppfattar inte att det fanns några frågor att besvara i denna uppgif.. bara att testa! 

            */

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            while (true)
            {
                Console.WriteLine(":::::::::::::::: Welcome to The Queue :::::::::::::::::");
                Console.WriteLine("Please navigate through the menu by inputting the character \n(+, -, 2, 4, 5, 0) of your choice \n"
                    + "\n+ Add things to The Queue (enqueue)"
                    + "\n- Remove things from The Queue (dequeue)"
                    + "\n2 Remove specific thing from The Queue"
                    + "\n4 View The Queue"
                    + "\n5 Get back to the main menu"
                    + "\n0 Exit the application\n");
                char input3 = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input3 = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!\n");
                    continue;
                }
                switch (input3)
                {
                    case '+':
                        Console.Clear();
                        Enqueue();
                        break;
                    case '-':
                        Console.Clear();
                        Dequeue();
                        break;
                    case '2':
                        Console.Clear();
                        RemoveSpecificItemFromQueue();
                        break;
                    case '4':
                        Console.Clear();
                        ShowContentOfQueue();
                        break;
                    case '5':
                        Console.Clear();
                        return;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter some valid input (+, -, 2, 4, 5, 0)\n");
                        break;
                }
            }
        }

        public static Queue<string> theQueue = new Queue<string>();
        public static void Enqueue()
        {
            Console.WriteLine(":::::::::::::::: ADDING TO THE QUEUE :::::::::::::::::");
            Console.WriteLine("Please write item titel and enter to enqueue. At least one character.\n");

            string itemToQueue = Console.ReadLine();

            if (!string.IsNullOrEmpty(itemToQueue))
            {
                theQueue.Enqueue(itemToQueue);
                Console.WriteLine($"{itemToQueue} added to The Queue!");
                ShowContentOfQueue();
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Input cannot be empty. Please restart!\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void Dequeue()
        {
            Console.WriteLine(":::::::::::::::: REMOVING FROM THE QUEUE :::::::::::::::::");
            Console.WriteLine("Press any key.\n");
            Console.ReadKey();
            if (theQueue.Count > 0)
            {
                string dequedItem = theQueue.Dequeue();
                Console.WriteLine($"{dequedItem} removed from The Queue!");
                ShowContentOfQueue();
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"The Queue is currently empty.\nPlease enqueue something, before attempt to dequeu!");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void RemoveSpecificItemFromQueue()
        {
            Console.WriteLine(":::::::::::::::: REMOVING SPECIFIC ITEM FROM THE QUEUE :::::::::::::::::");
            //Console.WriteLine("Please write full item titel and enter to dequeue.\n");

            if (theQueue.Count == 0)
            {
                Console.WriteLine($"The Queue is currently empty.\nPlease enqueue something, before attempt to dequeu!");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.WriteLine("Please write full item titel and enter to dequeue.\n");
            string itemFromQueue = Console.ReadLine();
            if (string.IsNullOrEmpty(itemFromQueue))
            {
                Console.WriteLine("Input cannot be empty. Please restart!\n");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            if (theQueue.Contains(itemFromQueue))
            {
                theQueue = new Queue<string>(theQueue.Where(item => item != itemFromQueue));
                Console.WriteLine($"{itemFromQueue} removed from The Queue!");
                ShowContentOfQueue();
                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                Console.WriteLine($"{itemFromQueue} is not in The Queque, please restart.");
                ShowContentOfQueue();
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void ShowContentOfQueue()
        {
            Console.WriteLine($"\nCurrently queuing: {theQueue.Count}!");
            foreach (string item in theQueue)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        public static void ExamineStack()
        {
            /*

            Uppfattar inte att det fanns några frågor att besvara i denna uppgif.. bara att testa! 

            */

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            while (true)
            {
                Console.WriteLine(":::::::::::::::: Welcome to The Stack :::::::::::::::::");
                Console.WriteLine("Please navigate through the menu by inputting the character \n(+, -, 2, 3, 4, 5, 0) of your choice \n"
                    + "\n+ Add things to The Stack (push)"
                    + "\n- Remove things from The Stack (pop)"
                    + "\n2 Remove specific thing from The Stack"
                    + "\n3 Reverse text using stack"
                    + "\n4 View The Stack"
                    + "\n5 Get back to the main menu"
                    + "\n0 Exit the application\n");
                char input4 = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input4 = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!\n");
                    continue;
                }
                switch (input4)
                {
                    case '+':
                        Console.Clear();
                        Push();
                        break;
                    case '-':
                        Console.Clear();
                        Pop();
                        break;
                    case '2':
                        Console.Clear();
                        RemoveSpecificItemFromStack();
                        break;
                    case '3':
                        Console.Clear();
                        ReverseTextWithStack();
                        break;
                    case '4':
                        Console.Clear();
                        ShowContentOfStack();
                        break;
                    case '5':
                        Console.Clear();
                        return;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter some valid input (+, -, 2, 3, 4, 5, 0)\n");
                        break;
                }
            }
        }
        public static Stack<string> theStack = new Stack<string>();
        public static void Push()
        {
            Console.WriteLine(":::::::::::::::: ADDING TO THE STACK :::::::::::::::::");
            Console.WriteLine("Please write item titel and enter to push. At least one character.\n");
            try
            {
                string itemToPush = Console.ReadLine();
                if (itemToPush.Length >= 1)
                {
                    theStack.Push(itemToPush);
                    Console.WriteLine($"{itemToPush} added to The Stack!");
                    ShowContentOfStack();
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Item needs to be at least one character! Please restart.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.WriteLine("Input cannot be empty. Please restart!\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void Pop()
        {
            Console.WriteLine(":::::::::::::::: REMOVING FROM THE STACK :::::::::::::::::");
            Console.WriteLine("Press any key.\n");
            Console.ReadKey();
            if (theStack.Count > 0)
            {
                string itemToPop = theStack.Pop();
                Console.WriteLine($"{itemToPop} removed from The Stack!");
                ShowContentOfStack();
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"The Stack is currently empty.\nPlease push something, before attempt to pop!");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void RemoveSpecificItemFromStack()
        {
            Console.WriteLine(":::::::::::::::: REMOVING SPECIFIC ITEM FROM THE STACK :::::::::::::::::");
            //Console.WriteLine("Please write full item titel and enter to pop from stack.\n");

            if (theStack.Count == 0)
            {
                Console.WriteLine($"The Stack is currently empty.\nPlease push something, before attempt to pop!");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.WriteLine("Please write full item titel and enter to pop from stack.\n");
            string itemFromStack = Console.ReadLine();
            if (string.IsNullOrEmpty(itemFromStack))
            {
                Console.WriteLine("Input cannot be empty. Please restart!\n");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            if (theStack.Contains(itemFromStack))
            {
                theStack = new Stack<string>(theStack.Where(item => item != itemFromStack));
                Console.WriteLine($"{itemFromStack} removed from The Queue!");
                ShowContentOfStack();
                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                Console.WriteLine($"{itemFromStack} is not in The Stack, please restart.");
                ShowContentOfStack();
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void ReverseTextWithStack()
        {
            Console.WriteLine(":::::::::::::::: REVERSE TEXT :::::::::::::::::");
            Console.WriteLine("Please write a text input - minimum two characters\n");

            string textToReverse = Console.ReadLine();
            if (string.IsNullOrEmpty(textToReverse))
            {
                Console.WriteLine("Input cannot be empty. Please restart!");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            if (textToReverse.Length >= 2)
            {
                char[] charArray = textToReverse.ToCharArray();
                theStack.Clear();
                foreach (char item in charArray)
                {
                    theStack.Push(item.ToString());
                }

                Console.WriteLine("\nReversed text is: ");
                foreach (string item in theStack)
                {
                    Console.Write(item);
                }
                Console.WriteLine($"\nCurrently in stack: {theStack.Count}!");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else
            {
                Console.WriteLine($"Text needs to be at least two character! Please restart.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }
        public static void ShowContentOfStack()
        {
            Console.WriteLine($"\nCurrently in stack: {theStack.Count}!");
            foreach (string item in theStack)
            {
                Console.WriteLine(item);
            }
        }
        public static void CheckParanthesis()
        {

            /*

            1. Nyfiken på Dictonary!
            Och tror stack passar bra så slipper man om jag har förstått saken rätt 
            loopa igenom ett index och spara undan data, stack känns mer direkt?
            
            2. Se nedan.

            */


            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            while (true)
            {
                Console.WriteLine(":::::::::::::::: CHECK PARANTHESIS :::::::::::::::::");
                Console.WriteLine("Please navigate through the menu by inputting the number \n(4, 5, 0) of your choice"
                    + "\n4 Enter text with paranthesis to test if used correct"
                    + "\n5 Get back to the main menu"
                    + "\n0 Exit the application\n");
                char input5 = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input5 = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!\n");
                    continue;
                }
                switch (input5)
                {
                    case '4':
                        Console.Clear();
                        TestParanthesis();
                        break;
                    case '5':
                        Console.Clear();
                        return;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter some valid input (4, 5, 0)\n");
                        break;
                }
            }
        }
        public static void TestParanthesis()
        {
            Console.WriteLine(":::::::::::::::: CHECK PARANTHESIS :::::::::::::::::");
            Console.WriteLine("Please write a text input with paranthesis - minimum two characters\n");
            Console.WriteLine("There are 4 different kinds: "
                + "\n Round brackets '()'"
                + "\n Square brackets '[]'"
                + "\n Curly brackets '{}'"
                + "\n Angel brackets '<>'\n");

            string inputToTest = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputToTest))
            {
                Console.WriteLine($"Text needs to be at least two characters! Please restart.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if(IsValidSequence(inputToTest))
            {
                Console.WriteLine("Your input contains a valid sequence of paranthesis!");
                Console.WriteLine("..or no paranthesis at all.."); // Har inte löst att man får denna även om man bara skriver abc ännu
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else
            {
                Console.WriteLine("Sorry, your input does not contain a pairing or sequence of paranthesis!");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }
        public static bool IsValidSequence(string inputToTest2)
        {
            Dictionary<char, char> paranthesisPairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
                { '<', '>' }
            };
            Stack<char> stack = new Stack<char>();
            Stack<char> sequenceStack = new Stack<char>();

            foreach (char c in inputToTest2)
            {
                if (paranthesisPairs.ContainsKey(c))
                {
                    stack.Push(c);
                    sequenceStack.Push(c);
                }
                else if (paranthesisPairs.ContainsValue(c))
                {
                    if (stack.Count == 0 || paranthesisPairs[stack.Pop()] != c)
                    {
                        return false;
                    }
                    sequenceStack.Pop();
                }
            }
            return sequenceStack.Count == 0 && stack.Count == 0;
        }
    }
}

