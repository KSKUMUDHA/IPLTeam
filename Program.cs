using System;
using System.Collections.Generic;
using System.Linq;

namespace New_folder
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Listing the teams names
            string teams = "GT,LSG,RR,DC,RCB,KKR,PBKS,SRH,CSK,MI";
            Dictionary<string, List<int>> teamsResult = new Dictionary<string, List<int>>();
            //adding team win and losses using the below method
            TeamsResultEntry(teams, ref teamsResult);
            
            
            Console.WriteLine("Are you looking for Win/losses \n Enter either W or N ");
            string winOrLosses = Console.ReadLine();

 
            Console.WriteLine("Enter no.of consecutive win/losses for the team");
            int ConsecutiveWorL = int.Parse(Console.ReadLine());


            //Method will get  no.of consecutive win/losses for the team 
            GetConsecutiveWinOrLossesOfTeam(teamsResult, teams, winOrLosses.ToUpper() == "W"  ? 1 : 0 , ConsecutiveWorL);
            Console.ReadKey();

        }

        public static void GetConsecutiveWinOrLossesOfTeam(Dictionary<string, List<int>> teamsResult, string teams, int result , int ConsecutiveWorL)
        {
            foreach (var item in teams.Split(','))
            {
                //Team wise traversing to see the consecutive win/loss
                bool bWinOrLost = false;
                var value = teamsResult[item];
                int counter = 0;
                foreach (var WorL in value)
                {
                    //comparing the win/loss of team with the given input
                    //clearing the counter in case not a consecutive win/loss
                    //counter nothing but Consecutive win / loss of team
                    if (WorL == result)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }
                    //checking the counter with ConsecutiveWorL
                    //if both match that specific team has Consecutive win/loss
                    if (counter == ConsecutiveWorL)
                    {
                        bWinOrLost = true;
                        break;
                    }
                        
                }
                if (bWinOrLost)
                {
                    float avgOfTeam = (value.Sum() * 2) / 5;
                    Console.WriteLine($"Consecutive win or lossess by {item} \t and AVG = {avgOfTeam}");
                }
                
               
            }
            

        }


        public static void TeamsResultEntry(string teams , ref Dictionary<string,List<int>> teamsResult)
        {
            //in case of any new team add we can do the changes over here
            //consider 1 as Win , 0 as loss 
            //This Team win and loss configured as per the document 
            foreach (var item in teams.Split(','))
            {
                switch (item)
                {
                    case "GT" : 
                        teamsResult.Add(item, new List<int>() { 1,1,0,0,1 });
                        break;
                    case "LSG":
                        teamsResult.Add(item, new List<int>() { 1, 0, 0, 1, 1 });
                        break;
                    case "RR":
                        teamsResult.Add(item, new List<int>() { 1, 0, 1, 0, 0 });
                        break;
                    case "DC":
                        teamsResult.Add(item, new List<int>() { 1, 1, 0, 1, 0 });
                        break;
                    case "RCB":
                        teamsResult.Add(item, new List<int>() { 0, 1, 1, 0, 0 });
                        break;
                    case "KKR":
                        teamsResult.Add(item, new List<int>() { 0, 1, 1, 0, 1 });
                        break;
                    case "PBKS":
                        teamsResult.Add(item, new List<int>() { 0, 1, 0, 1, 0 });
                        break;
                    case "SRH":
                        teamsResult.Add(item, new List<int>() { 1, 0, 0, 0, 0 });
                        break;
                    case "CSK":
                        teamsResult.Add(item, new List<int>() { 0, 0, 1, 0, 1 });
                        break;
                    case "MI":
                        teamsResult.Add(item, new List<int>() { 0, 1, 0, 1, 1 });
                        break;
                    default:
                        Console.WriteLine("Please enter the valid team");
                        break;
                }
            }
        }
       
       
    }

}
