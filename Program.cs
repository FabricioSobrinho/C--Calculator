using System;
namespace Calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            bool enterCalc = true;

            while (enterCalc)
            {
                try
                {
                    int option = Menu();
                    switch (option)
                    {
                        case 1: Sum(); break;
                        case 2: Subtract(); break;
                        case 3: Multiply(); break;
                        case 4: Division(); break;
                        case 5: ExitCalculator(); break;
                        default: Console.WriteLine("You have inserted an invalid option."); break;
                    }

                    enterCalc = ContinueInCalculator();
                }
                catch
                {
                    ShowMessages(EMessageType.Error);
                }
            }

            static void Sum()
            {
                try
                {
                    Console.Clear();

                    ShowMessages(EMessageType.Insert);
                    double n1 = Convert.ToDouble(Console.ReadLine());
                    ShowMessages(EMessageType.Insert);
                    double n2 = Convert.ToDouble(Console.ReadLine());

                    double sumResult = n1 + n2;
                    ShowResult(Math.Round(sumResult, 2));
                }
                catch
                {
                    ShowMessages(EMessageType.Error);
                }
            }
        }
        static void Subtract()
        {
            try
            {
                Console.Clear();

                Console.WriteLine();
                ShowMessages(EMessageType.Insert);
                double n1 = Convert.ToDouble(Console.ReadLine());
                ShowMessages(EMessageType.Insert);
                double n2 = Convert.ToDouble(Console.ReadLine());

                double subtractResult = n1 - n2;
                ShowResult(subtractResult);
            }
            catch
            {
                ShowMessages(EMessageType.Error);
            }
        }
        static void Multiply()
        {
            try
            {
                Console.Clear();

                ShowMessages(EMessageType.Insert);
                double n1 = Convert.ToDouble(Console.ReadLine());
                ShowMessages(EMessageType.Insert);
                double n2 = Convert.ToDouble(Console.ReadLine());

                double multiplyResult = n1 * n2;
                ShowResult(multiplyResult);
            }
            catch
            {
                ShowMessages(EMessageType.Error);
            }
        }

        static void Division()
        {
            try
            {
                Console.Clear();

                ShowMessages(EMessageType.Insert);
                double n1 = Convert.ToDouble(Console.ReadLine());
                ShowMessages(EMessageType.Insert);
                double n2 = Convert.ToDouble(Console.ReadLine());

                double divisionResult = n1 / n2;
                ShowResult(divisionResult);
            }
            catch
            {
                ShowMessages(EMessageType.Error);
            }
        }

        static int Menu()
        {
            Console.WriteLine(
                """
                |-----------------------------|
                | Choice an operation, please.|
                |=============================|
                |           1- Sum            |
                |=============================|
                |       2- Subtraction        |
                |=============================|
                |      3- Multiplication      |
                |=============================|
                |         4- Division         |
                |_____________________________|
                |-----------------------------|
                |          5- Exit            |
                |-----------------------------|
                """
            );

            var option = Convert.ToInt32(Console.ReadLine());

            return option;
        }

        static bool ContinueInCalculator()
        {
            Console.WriteLine(
                """
                |--------------------------------------|
                | Do you wanna continue in Calculator? |
                |======================================|
                |               1- Yes                 |
                |======================================|
                |            Other key- No             |
                |--------------------------------------|
                """
            );
            var continueOption = Console.ReadLine();

            return continueOption == "1" ? true : false;
        }
        static void ExitCalculator()
        {
            Console.WriteLine("Bye!");
            Environment.Exit(0);
        }

        struct Messages
        {
            public Messages(string errorText, string insertNumberText)
            {
                ErrorText = errorText;
                InsertNumberText = insertNumberText;
            }

            string InsertNumberText = "";
            string ErrorText = "";

            public string ReturnErrorMessage()
            {
                return ErrorText;
            }
            public string ReturnInsertMessage()
            {
                return InsertNumberText;
            }
        }

        public static void ShowMessages(EMessageType messageType)
        {

            var textError = new Messages(
                $"""
                |------------------------------------|
                |The program has an unexpected error.|
                |------------------------------------|
                """,
                $"""
                |------------------------|
                |Insert a number please: |
                |------------------------|
                """
            );

            if (messageType == EMessageType.Error)
            {
                string ErrorMessage = textError.ReturnErrorMessage();
                Console.WriteLine(ErrorMessage);
            }
            if (messageType == EMessageType.Insert)
            {
                string InsertMessage = textError.ReturnInsertMessage();
                Console.WriteLine(InsertMessage);
            }
        }

        public static void ShowResult(double result)
        {
            Console.WriteLine(
                $"""
                |------------------------------|
                |The operation result is: {String.Format("{0:0.00}", result)}|
                |------------------------------|
                """
            );
        }

        public enum EMessageType
        {
            Error = 1,
            Insert = 2
        }

    }
}