﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal class Config
    {
        //max rounds
        const int ROUNDS = 8;
        //properties
        public int Rounds
        {
            get { return ROUNDS; }
        }

        //Welcome method
        public static void Welcome()
        {
            Console.WriteLine("Welcome to MASTERMIND!");
        }

        //Rules method
        public static void Rules()
        {
            Console.WriteLine("In this game you must guess the correct order 4 colors in a set generated by the computer\nYou will have 8 rounds to do this, and if you can't guess it then you lose\nJust enter the four colors in the order you think is right and you will know if you're right or not\nYou must enter (R)ed, (B)lue, (G)reen, or (Y)ellow");
        }

        //ends game
        public static void EndGame()
        {
            Console.WriteLine("You Lose! Better luck next time\nPress enter to quit");
            Console.ReadLine();
        }

    }
}
