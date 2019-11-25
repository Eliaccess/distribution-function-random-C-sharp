using System;

namespace Fonction_de_repartition_fonction_random
{
    internal class Program
    {
        const int ELEMENTS_SET = 15;
        const int DISPLAY_SIZE = 500;
        const int NUMBER_TESTS = 10000;
        const int DISPLAY_SIZE_LOADING = 50;
        
        public static void Main(string[] args)
        {
            int[] results = new int[ELEMENTS_SET + 1];

            initialize(results);
            
            for (int i = 0; i < NUMBER_TESTS+1; i++)
            {
                addToArray(results, generateNumber());

                if (loading(i))
                {
                    display(results);
                }
            }
        }

        public static void initialize(int[] array)
        {
            for (int i = 0; i < ELEMENTS_SET+1; i++)
            {
                array[i] = 0;
            }
        }
        
        public static void display(int[] array)
        {
            float number_tests_done = 0;
            
            for (int i = 0; i < ELEMENTS_SET+1; i++)
            {
                number_tests_done = number_tests_done + array[i];
            }
            Console.Clear();

            for (int i = 0; i < ELEMENTS_SET; i++)
            {
                Console.Write(i+" = ");
                
                int number_display_size = (int)(array[i] * DISPLAY_SIZE/number_tests_done);
                
                //Console.WriteLine(number_display_size);
                
                for (int j = 1; j <= number_display_size; j++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("("+array[i]+")");
            }
            
        }

        public static int generateNumber()
        {
            System.Random rand = new System.Random();
            int number = rand.Next(0, ELEMENTS_SET);
            return number;
        }

        public static void addToArray(int[] array, int number)
        {
            array[number]++;
        }

        public static bool loading(int number)
        {
            bool finished = false;
            string displayed = "";
            
            //Console.Clear();
            displayed="[";
            float done = DISPLAY_SIZE_LOADING * number / NUMBER_TESTS;
            for (int i = 0; i < DISPLAY_SIZE_LOADING; i++)
            {
                if (i<=done)
                {
                    displayed = displayed +"=";
                }
                else
                {
                    displayed = displayed +" ";
                }
            }
            displayed = displayed + "](" + number + "/" + NUMBER_TESTS + ")";
            Console.WriteLine(displayed);
            if (number == NUMBER_TESTS)
            {
                finished = true;
            }
            
            return finished;
        }
    }
}