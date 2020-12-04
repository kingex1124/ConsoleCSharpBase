using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCSharpBase
{
    public class FuncRes
    {
        public FuncRes()
        {
            Example();
        }

        public void Example()
        {
            #region Func<TResult>

            #region EX1

            EX1();

            #endregion

            #region EX2

            EX2_1();

            EX2_2();

            EX2_3();

            EX2_4();

            #endregion

            #endregion

            #region Func<T,TResult>

            #region EX3

            EX3_1();

            EX3_2();

            EX3_3();

            EX3_4();

            EX3_5();

            #endregion

            #endregion

            #region Func<T1,T2,TResult>

            #region EX4

            EX4_1();

            EX4_2();

            EX4_3();

            EX4_4();

            EX4_5();

            EX4_6();

            #endregion

            #endregion

            #region Func<T1,T2,T3,TResult>

            #region EX5

            EX5_1();

            EX5_2();

            EX5_3();

            EX5_4();

            #endregion

            #endregion

            #region Func<T1,T2,T3,T4,TResult>

            #region EX6

            EX6_1();

            EX6_2();

            EX6_3();

            EX6_4();

            #endregion

            #endregion
        }

        #region Func<TResult>

        #region EX1

        public void EX1()
        {
            LazyValue<int> lazyOne = new LazyValue<int>(() => ExpensiveOne());
            LazyValue<long> lazyTwo = new LazyValue<long>(() => ExpensiveTwo("apple"));

            var result = lazyOne.Value;
        }

        public int ExpensiveOne()
        {
            Console.WriteLine("\nExpensiveOne() is executing.");
            return 1;
        }

        public long ExpensiveTwo(string input)
        {
            Console.WriteLine("\nExpensiveTwo() is executing.");
            return (long)input.Length;
        }

        public class LazyValue<T> where T : struct
        {
            private Nullable<T> val;
            private Func<T> getValue;

            // Constructor.
            public LazyValue(Func<T> func)
            {
                val = null;
                getValue = func;
            }

            public T Value
            {
                get
                {
                    if (val == null)
                        // Execute the delegate.
                        val = getValue();
                    return (T)val;
                }
            }
        }

        #endregion

        #region EX2

        delegate bool WriteMethod();

        public void EX2_1()
        {
            WriteMethod methodCall = SendToFile;

            if (methodCall())
                Console.WriteLine("Success!");
            else
                Console.WriteLine("File write operation failed.");
        }

        public void EX2_2()
        {
            Func<bool> methodCall = SendToFile;

            if (methodCall())
                Console.WriteLine("Success!");
            else
                Console.WriteLine("File write operation failed.");
        }

        public void EX2_3()
        {
            Func<bool> methodCall = delegate () { return SendToFile(); };
            if (methodCall())
                Console.WriteLine("Success!");
            else
                Console.WriteLine("File write operation failed.");
        }

        public void EX2_4()
        {
            // 因為沒有傳入參數 所以只能用 () 如果有 可以自訂義參數
            Func<bool> methodCall = () => SendToFile();
            if (methodCall())
                Console.WriteLine("Success!");
            else
                Console.WriteLine("File write operation failed.");
        }

        public bool SendToFile()
        {
            try
            {
                string fn = Path.GetTempFileName();
                StreamWriter sw = new StreamWriter(fn);
                sw.WriteLine("Hello, World!");
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #endregion

        #region Func<T,TResult>

        #region EX3

        public void EX3_1()
        {
            // Declare a Func variable and assign a lambda expression to the
            // variable. The method takes a string and converts it to uppercase.
            Func<string, string> selector = str => str.ToUpper();

            // Create an array of strings.
            string[] words = { "orange", "apple", "Article", "elephant" };
            // Query the array and select strings according to the selector method.
            IEnumerable<String> aWords = words.Select(selector);

            // Output the results to the console.
            foreach (String word in aWords)
                Console.WriteLine(word);
        }

        delegate string ConvertMethod(string inString);

        public void EX3_2()
        {
            // Instantiate delegate to reference UppercaseString method
            ConvertMethod convertMeth = UppercaseString;
            string name = "Dakota";
            // Use delegate instance to call UppercaseString method
            Console.WriteLine(convertMeth(name));
        }

        public string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }

        public void EX3_3()
        {
            // Instantiate delegate to reference UppercaseString method
            Func<string, string> convertMethod = UppercaseString;

            string name = "Dakota";
            // Use delegate instance to call UppercaseString method
            Console.WriteLine(convertMethod(name));
        }

        public void EX3_4()
        {
            Func<string, string> convertMethod = str => UppercaseString(str);

            string name = "Dakota";
            // Use delegate instance to call UppercaseString method
            Console.WriteLine(convertMethod(name));
        }

        public void EX3_5()
        {
            Func<string, string> convert = delegate (string s) { return s.ToUpper(); };

            string name = "Dakota";
            Console.WriteLine(convert(name));
        }

        #endregion

        #endregion

        #region Func<T1,T2,TResult>

        #region EX4

        public void EX4_1()
        {
            Func<String, int, bool> predicate = (str, index) => str.Length == index;

            String[] words = { "orange", "apple", "Article", "elephant", "star", "and" };

            IEnumerable<String> aWords = words.Where(predicate).Select(str => str);

            foreach (String word in aWords)
                Console.WriteLine(word);
        }

        delegate string[] ExtractMethod(string stringToManipulate, int maximum);

        public void EX4_2()
        {
            // Instantiate delegate to reference ExtractWords method
            ExtractMethod extractMeth = ExtractWords;
            string title = "The Scarlet Letter a b c d";
            // Use delegate instance to call ExtractWords method and display result
            foreach (string word in extractMeth(title, 5))
                Console.WriteLine(word);
        }

        public string[] ExtractWords(string phrase, int limit)
        {
            char[] delimiters = new char[] { ' ' };
            if (limit > 0)
                return phrase.Split(delimiters, limit);
            else
                return phrase.Split(delimiters);
        }

        public void EX4_3()
        {
            // Instantiate delegate to reference ExtractWords method
            Func<string, int, string[]> extractMethod = ExtractWords;
            string title = "The Scarlet Letter";
            // Use delegate instance to call ExtractWords method and display result
            foreach (string word in extractMethod(title, 5))
                Console.WriteLine(word);
        }

        public void EX4_4()
        {
            Func<string, int, string[]> extractMeth = delegate (string s, int i)
            {
                char[] delimiters = new char[] { ' ' };
                return i > 0 ? s.Split(delimiters, i) : s.Split(delimiters);
            };

            string title = "The Scarlet Letter";
            // Use Func instance to call ExtractWords method and display result
            foreach (string word in extractMeth(title, 5))
                Console.WriteLine(word);
        }

        public void EX4_5()
        {
            char[] separators = new char[] { ' ' };
            Func<string, int, string[]> extract = (s, i) =>
                 i > 0 ? s.Split(separators, i) : s.Split(separators);

            string title = "The Scarlet Letter";
            // Use Func instance to call ExtractWords method and display result
            foreach (string word in extract(title, 5))
                Console.WriteLine(word);
        }

        public void EX4_6()
        {
            Func<string, int, string[]> extract = (s, i) => ExtractWords(s, i);

            string title = "The Scarlet Letter";
            // Use Func instance to call ExtractWords method and display result
            foreach (string word in extract(title, 5))
                Console.WriteLine(word);
        }

        #endregion

        #endregion

        #region Func<T1,T2,T3,TResult>

        #region EX5

        delegate T ParseNumber<T>(string input, NumberStyles styles, IFormatProvider provider);

        public void EX5_1()
        {
            string numericString = "-1,234";
            ParseNumber<int> parser = int.Parse;
            Console.WriteLine(parser(numericString,
                              NumberStyles.Integer | NumberStyles.AllowThousands,
                              CultureInfo.InvariantCulture));
        }

        public void EX5_2()
        {
            string numericString = "-1,234";
            Func<string, NumberStyles, IFormatProvider, int> parser = int.Parse;
            Console.WriteLine(parser(numericString,
                              NumberStyles.Integer | NumberStyles.AllowThousands,
                              CultureInfo.InvariantCulture));
        }

        public void EX5_3()
        {
            string numericString = "-1,234";
            Func<string, NumberStyles, IFormatProvider, int> parser =
                 delegate (string s, NumberStyles sty, IFormatProvider p)
                 { return int.Parse(s, sty, p); };
            Console.WriteLine(parser(numericString,
                              NumberStyles.Integer | NumberStyles.AllowThousands,
                              CultureInfo.InvariantCulture));
        }

        public void EX5_4()
        {
            string numericString = "-1,234";
            Func<string, NumberStyles, IFormatProvider, int> parser = (s, sty, p) => int.Parse(s, sty, p);

            Console.WriteLine(parser(numericString,
                              NumberStyles.Integer | NumberStyles.AllowThousands,
                              CultureInfo.InvariantCulture));
        }

        #endregion

        #endregion

        #region Func<T1,T2,T3,T4,TResult>

        #region EX6

        delegate int Searcher(string searchString, int start, int count, StringComparison type);

        public void EX6_1()
        {
            string title = "The House of the Seven Gables";
            int position = 0;
            Searcher finder = title.IndexOf;
            do
            {
                int characters = title.Length - position;
                position = finder("the", position, characters,
                                StringComparison.InvariantCultureIgnoreCase);
                if (position >= 0)
                {
                    position++;
                    Console.WriteLine("'The' found at position {0} in {1}.",
                                      position, title);
                }
            } while (position > 0);
        }

        public void EX6_2()
        {
            string title = "The House of the Seven Gables";
            int position = 0;
            Func<string, int, int, StringComparison, int> finder = title.IndexOf;
            do
            {
                int characters = title.Length - position;
                position = finder("the", position, characters,
                                StringComparison.InvariantCultureIgnoreCase);
                if (position >= 0)
                {
                    position++;
                    Console.WriteLine("'The' found at position {0} in {1}.",
                                      position, title);
                }
            } while (position > 0);
        }

        public void EX6_3()
        {
            string title = "The House of the Seven Gables";
            int position = 0;
            Func<string, int, int, StringComparison, int> finder = delegate (string s, int pos, int chars, StringComparison type)
                 { return title.IndexOf(s, pos, chars, type); };
            do
            {
                int characters = title.Length - position;
                position = finder("the", position, characters,
                                StringComparison.InvariantCultureIgnoreCase);
                if (position >= 0)
                {
                    position++;
                    Console.WriteLine("'The' found at position {0} in {1}.",
                                      position, title);
                }
            } while (position > 0);
        }

        public void EX6_4()
        {
            string title = "The House of the Seven Gables";
            int position = 0;
            Func<string, int, int, StringComparison, int> finder = (s, pos, chars, type) => title.IndexOf(s, pos, chars, type);
            do
            {
                int characters = title.Length - position;
                position = finder("the", position, characters,
                                StringComparison.InvariantCultureIgnoreCase);
                if (position >= 0)
                {
                    position++;
                    Console.WriteLine("'The' found at position {0} in {1}.",
                                      position, title);
                }
            } while (position > 0);
        }

        #endregion

        #endregion
    }


}
