using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*Name: HW6 - The Getaway
 *Creator: Alex Gayne
 *Date: 11/17/2022
 *Purpose: Make a text based adventure game
 *Modifications: 9/12 - Fixed issue with Y/N response at start, added more story, created steps puzzle and all responses 9/24- started adding content for HW2 assignment (random, nested ifs, switch, loops) 9/27-HW2 mostly finished 10/14-HW3 started
 */
//The monster is created when you fail the second basement room
//Git repository link: https://github.com/spoopyboi3/igme-105.git
namespace Getaway
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Animals animals = new Animals();
            Setup setup = new Setup();
            Basement basement = new Basement();
            Building building = new Building();
            Yard yard = new Yard();
            BlackRat blackRat = new BlackRat();



            //welcome player
            Setup.Welcome();

            Setup.DifficultyChoice(setup.Difficulty, building.Crows);

            //Get player name
            setup.PlayerName = Setup.GetPlayer(setup.PlayerName);

            //gather user data
            Setup.GatherData(setup.Numbers, animals.Legs, setup.Letter);

            //get second name
            setup.Character = Setup.GetCharacter(setup.Character);
            

            //story
            Setup.Intro(setup.PlayerName, setup.Character, setup.Letter);

            //yard method
            Yard.Walking(setup.Character, yard.Steps_Needed);
            
            //Front door is locked, use method
            Building.FrontDoor(setup.PlayerName, building.Dice, building.Dice2, building.Total);

            //challenge once door is unlocked
            Building.FrontDoorChallenge(setup.Letter, animals.Eyes, animals.Toes, animals.Names, animals.Legs, setup.Difficulty, animals.ISConsumed);

            //Make it into the house, start in lower hallway, connects to living room and study
            Building.ColorObject(building.My_Colors);

            //Player moves through house untill reaching basement
            Building.BldgRooms(setup.Letter, setup.Character, setup.PlayerName, setup.FoodList);

            //in basement, move through obstacles to generator
            Basement.BasementRooms(basement.BaseMove, setup.Letter, blackRat.AttackSkill);

            //ending sequence
            Setup.Ending(setup.PlayerName, setup.Character);


        }


    }
}
