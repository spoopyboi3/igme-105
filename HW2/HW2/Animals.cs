﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Name: HW6 - The Getaway
 *Creator: Alex Gayne
 *Date: 11/17/2022
 *Purpose: Make a text based adventure game
 *Modifications: 9/12 - Fixed issue with Y/N response at start, added more story, created steps puzzle and all responses 9/24- started adding content for HW2 assignment (random, nested ifs, switch, loops) 9/27-HW2 mostly finished 10/14-HW3 started
 */
namespace Getaway
{
    internal class Animals
    {
        //animal attributes and properties
        int[] eyes = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        int[] toes = new int[10] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };

        string[] names = new string[10] { "Squawks", "Scratchy", "Roo", "Tori", "Bobo", "Meg", "Maverick", "Pecks", "Karasu", "Corvus" };

        int[] legs = new int[10];

        public int[] Legs
        {
            get { return legs; }
        }

        public string[] Names
        {
            get
            {
                return names;
            }    
        }
        
        public int[] Eyes
        {
            get { return eyes; }
        }

        public int[] Toes
        {
            get { return toes; }
        }
    }

}
