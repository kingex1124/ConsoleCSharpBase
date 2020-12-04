using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCSharpBase
{
    public class ActRes
    {
        public ActRes()
        {
            Example();
        }

        private void Example()
        {
            #region Action

            #region EX1

            EX1_1();

            EX1_2();

            EX1_3();

            EX1_4();

            #endregion

            #endregion

            #region Action<T>

            #region EX2

            EX2_1();

            #endregion

            #endregion

            #region Action<T1,T2>

            #region EX3

            EX3_1();

            #endregion

            #endregion

            #region Action<T1,T2,T3>

            #region EX4

            EX4_1();

            EX4_2();

            EX4_3();

            EX4_4();

            #endregion

            #endregion

            #region Action<T1,T2,T3,T4>

            #region EX5

            EX5_1();

            EX5_2();

            EX5_3();

            EX5_4();

            #endregion

            #endregion
        }

        #region Action

        #region EX1

        public delegate void ShowValue();

        public void EX1_1()
        {
            Name testName = new Name("Koani");
            ShowValue showMethod = testName.DisplayToConsole;
            showMethod();
        }

        public class Name
        {
            private string instanceName;

            public Name(string name)
            {
                this.instanceName = name;
            }

            public void DisplayToConsole()
            {
                Console.WriteLine(this.instanceName);
            }
        }

        public void EX1_2()
        {
            Name testName = new Name("Koani");
            Action showMethod = testName.DisplayToConsole;
            showMethod();
        }

        public void EX1_3()
        {
            Name testName = new Name("Koani");
            Action showMethod = delegate () { testName.DisplayToConsole(); };
            showMethod();
        }

        public void EX1_4()
        {
            Name testName = new Name("Koani");
            Action showMethod = () => testName.DisplayToConsole();
            showMethod();
        }

        #endregion

        #endregion

        #region Action<T>

        #region EX2

        public void EX2_1()
        {
            List<String> names = new List<String>();
            names.Add("Bruce");
            names.Add("Alfred");
            names.Add("Tim");
            names.Add("Richard");

            // Display the contents of the list using the Print method.
             names.ForEach(Print);

            // The following demonstrates the anonymous method feature of C#
            // to display the contents of the list to the console.
            names.ForEach(delegate (String name)
            {
                Console.WriteLine(name);
            });
        }
        public void Print(string s)
        {
            Console.WriteLine(s);
        }

        delegate void DisplayMessage(string message);

        public void EX2_2()
        {
            DisplayMessage messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = ShowWindowsMessage;
            else
                messageTarget = Console.WriteLine;

            messageTarget("Hello, World!");
        }

        public void ShowWindowsMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void EX2_3()
        {
            Action<string> messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = ShowWindowsMessage;
            else
                messageTarget = Console.WriteLine;

            messageTarget("Hello, World!");
        }

        public void EX2_4()
        {
            Action<string> messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = delegate (string s) { ShowWindowsMessage(s); };
            else
                messageTarget = delegate (string s) { Console.WriteLine(s); };

            messageTarget("Hello, World!");
        }

        public void EX2_5()
        {
            Action<string> messageTarget;

            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = s => ShowWindowsMessage(s);
            else
                messageTarget = s => Console.WriteLine(s);

            messageTarget("Hello, World!");
        }

        #endregion

        #endregion

        #region Action<T1,T2>

        #region EX3

        delegate void ConcatStrings(string string1, string string2);

        public void EX3_1()
        {
            string message1 = "The first line of a message.";
            string message2 = "The second line of a message.";
            ConcatStrings concat;

            if (Environment.GetCommandLineArgs().Length > 1)
                concat = WriteToFile;
            else
                concat = WriteToConsole;

            concat(message1, message2);
        }

        public void WriteToConsole(string string1, string string2)
        {
            Console.WriteLine("{0}\n{1}", string1, string2);
        }

        public void WriteToFile(string string1, string string2)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(Environment.GetCommandLineArgs()[1], false);
                writer.WriteLine("{0}\n{1}", string1, string2);
            }
            catch
            {
                Console.WriteLine("File write operation failed...");
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        public void EX3_2()
        {
            string message1 = "The first line of a message.";
            string message2 = "The second line of a message.";
            Action<string, string> concat;

            if (Environment.GetCommandLineArgs().Length > 1)
                concat = WriteToFile;
            else
                concat = WriteToConsole;

            concat(message1, message2);
        }

        public void EX3_3()
        {
            string message1 = "The first line of a message.";
            string message2 = "The second line of a message.";
            Action<string, string> concat;

            if (Environment.GetCommandLineArgs().Length > 1)
                concat = delegate (string s1, string s2) { WriteToFile(s1, s2); };
            else
                concat = delegate (string s1, string s2) { WriteToConsole(s1, s2); };

            concat(message1, message2);
        }

        public void EX3_4()
        {
            string message1 = "The first line of a message.";
            string message2 = "The second line of a message.";
            Action<string, string> concat;

            if (Environment.GetCommandLineArgs().Length > 1)
                concat = (s1, s2) => WriteToFile(s1, s2);
            else
                concat = (s1, s2) => WriteToConsole(s1, s2);

            concat(message1, message2);
        }

        #endregion

        #endregion

        #region Action<T1,T2,T3>

        #region EX4

        delegate void StringCopy(string[] stringArray1, string[] stringArray2, int indexToStart);

        public void EX4_1()
        {
            string[] ordinals = { "First", "Second", "Third", "Fourth", "Fifth" };
            string[] copiedOrdinals = new string[ordinals.Length];
            StringCopy copyOperation = CopyStrings;
            copyOperation(ordinals, copiedOrdinals, 3);
            foreach (string ordinal in copiedOrdinals)
                Console.WriteLine(String.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);
        }

        public void CopyStrings(string[] source, string[] target, int startPos)
        {
            if (source.Length != target.Length)
                throw new IndexOutOfRangeException("The source and target arrays must have the same number of elements.");

            for (int ctr = startPos; ctr <= source.Length - 1; ctr++)
                target[ctr] = String.Copy(source[ctr]);
        }

        public void EX4_2()
        {
            string[] ordinals = { "First", "Second", "Third", "Fourth", "Fifth" };
            string[] copiedOrdinals = new string[ordinals.Length];
            Action<string[], string[], int> copyOperation = CopyStrings;
            copyOperation(ordinals, copiedOrdinals, 3);
            foreach (string ordinal in copiedOrdinals)
                Console.WriteLine(String.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);
        }

        public void EX4_3()
        {
            string[] ordinals = { "First", "Second", "Third", "Fourth", "Fifth" };
            string[] copiedOrdinals = new string[ordinals.Length];
            Action<string[], string[], int> copyOperation = delegate (string[] s1, string[] s2, int pos) { CopyStrings(s1, s2, pos); };

            copyOperation(ordinals, copiedOrdinals, 3);
            foreach (string ordinal in copiedOrdinals)
                Console.WriteLine(String.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);
        }

        public void EX4_4()
        {
            string[] ordinals = { "First", "Second", "Third", "Fourth", "Fifth" };
            string[] copiedOrdinals = new string[ordinals.Length];
            Action<string[], string[], int> copyOperation = (s1, s2, pos) => CopyStrings(s1, s2, pos);

            copyOperation(ordinals, copiedOrdinals, 3);
            foreach (string ordinal in copiedOrdinals)
                Console.WriteLine(ordinal == string.Empty ? "<None>" : ordinal);
        }

        #endregion

        #endregion

        #region Action<T1,T2,T3,T4>

        #region EX5

        delegate void StringCopy1(string[] stringArray1, string[] stringArray2, int indexToStart, int numberToCopy);

        public void EX5_1()
        {
            string[] ordinals = {"First", "Second", "Third", "Fourth", "Fifth",
                           "Sixth", "Seventh", "Eighth", "Ninth", "Tenth"};
            string[] copiedOrdinals = new string[ordinals.Length];
            StringCopy1 copyOperation = CopyStrings;

            copyOperation(ordinals, copiedOrdinals, 3, 5);
            foreach (string ordinal in copiedOrdinals)
                Console.WriteLine(String.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);
        }

        public void CopyStrings(string[] source, string[] target, int startPos, int number)
        {
            if (source.Length != target.Length)
                throw new IndexOutOfRangeException("The source and target arrays must have the same number of elements.");

            for (int ctr = startPos; ctr <= startPos + number - 1; ctr++)
                target[ctr] = String.Copy(source[ctr]);
        }

        public void EX5_2()
        {
            string[] ordinals = {"First", "Second", "Third", "Fourth", "Fifth",
                           "Sixth", "Seventh", "Eighth", "Ninth", "Tenth"};
            string[] copiedOrdinals = new string[ordinals.Length];
            Action<string[], string[], int, int> copyOperation = CopyStrings;

            copyOperation(ordinals, copiedOrdinals, 3, 5);
            foreach (string ordinal in copiedOrdinals)
                Console.WriteLine(String.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);
        }

        public void EX5_3()
        {
            string[] ordinals = {"First", "Second", "Third", "Fourth", "Fifth",
                           "Sixth", "Seventh", "Eighth", "Ninth", "Tenth"};
            string[] copiedOrdinals = new string[ordinals.Length];
            Action<string[], string[], int, int> copyOperation = delegate (string[] s1, string[] s2, int pos, int num) { CopyStrings(s1, s2, pos, num); };

            copyOperation(ordinals, copiedOrdinals, 3, 5);
            foreach (string ordinal in copiedOrdinals)
                Console.WriteLine(String.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);
        }

        public void EX5_4()
        {
            string[] ordinals = {"First", "Second", "Third", "Fourth", "Fifth",
                           "Sixth", "Seventh", "Eighth", "Ninth", "Tenth"};
            string[] copiedOrdinals = new string[ordinals.Length];
            Action<string[], string[], int, int> copyOperation = (s1, s2, pos, num) => CopyStrings(s1, s2, pos, num);

            copyOperation(ordinals, copiedOrdinals, 3, 5);
            foreach (string ordinal in copiedOrdinals)
                Console.WriteLine(String.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);
        }

        #endregion

        #endregion
    }
}
