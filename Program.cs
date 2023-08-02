using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KidsLearning
{
    public class KidsLearningSystem
    {  
        
        public static List<string> fruits = new List<string> { "Apple", "Banana", "Orange", "Grapes", "Strawberry","\n" };
     
        private static List<string> days = new List<string> { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday","\n" };
        private static List<string> months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December","\n" };
        private static Dictionary<string, string> words = new Dictionary<string, string>
    {
        { "Apple", "A round fruit with red or green skin" },
        { "Banana", "A long curved fruit with yellow skin" },
        { "Orange", "A citrus fruit with orange skin" },
        { "Grapes", "Small, round fruit that grows in bunches" },
        { "Strawberry", "A small, sweet fruit with red skin and seeds on the outside \n" }
    };

        private static readonly object lockObject = new object();

        public static void Main(string[] args)
        {
            Console.WriteLine("----------------Welcome to :) Kids Learning------------------------- \n ");
            Console.WriteLine("Here we have seen  about NAME OF DAYS, MONTHS OF YEAR, FRUITS & THEIR MEANINGS\n");

            Thread daysThread = new Thread(DisplayDays);
            

        
            Thread monthsThread = new Thread(DisplayMonths);

            
            Thread fruitsThread = new Thread(DisplayFruits);

          
            Thread wordsThread = new Thread(DisplayWords);


            
            daysThread.Start();
            Thread.Sleep(2000); // Wait for 2 seconds before starting the next thread

           
            monthsThread.Start();
            Thread.Sleep(5000); // Wait for 5 seconds before starting the next thread

          
            fruitsThread.Start();
            wordsThread.Start();


            
            daysThread.Join();
            monthsThread.Join();
            fruitsThread.Join();
            wordsThread.Join();

        }

        private  static void DisplayDays()

        {
            
            lock (lockObject)
            {
                foreach (string day in days)
                {
                    
                    Console.WriteLine(day);
                    Thread.Sleep(2000); // Wait for 2 seconds before displaying the next day
                }
            }
        }

        private static void DisplayMonths()
        {
            lock (lockObject)
            {
                foreach (string month in months)
                {
                    Console.WriteLine(month);
                    Thread.Sleep(2000); // Wait for 2 seconds before displaying the next month
                }
            }
        }

        private static void DisplayFruits()
        {
            lock (lockObject)
            {
                foreach (string fruit in fruits)
                {
                    Console.WriteLine(fruit);
                    Thread.Sleep(1000); // Wait for 1 second before displaying the next fruit
                }
            }
        }

        private static void DisplayWords()
        {
            lock (lockObject)
            {
                foreach (KeyValuePair<string, string> word in words)
                {
                    Console.WriteLine("{0}: {1}", word.Key, word.Value);
                    Thread.Sleep(1000); // Wait for 1 second before displaying the next word

                   
                }
            }
            Console.WriteLine("-------------------THANK YOU-------------------");
        }
    }
}

