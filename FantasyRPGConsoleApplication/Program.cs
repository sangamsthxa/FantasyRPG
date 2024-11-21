using System;
using FantasyRPG;

class FantasyRPGConsoleApplication
{

    // Main Method
    public static void Main(String[] args)
    {
        int totalDuel =0;
        int totalHumanWon =0;
        int totalBalrogWon =0;

        Console.WriteLine("Results of a Human dueling a Balrog");
        for (int i = 0; i < 100; i++)
        {
            Creature creature1 = new Human()
            {
                Strength = 50,
                HitPoints = 100
            };
            Creature creature2 = new Balrogs()
            {
                Strength = 50,
                HitPoints = 100
            };

            Battle battle = new Battle();
            int battleWon = battle.Duel(creature1, creature2);
            List<String> messages = battle.Messages;
            for (int j = 0; j < messages.Count; j++)
            {
                Console.WriteLine(messages[j]);
            }
            if(battleWon==0){
                totalDuel++;
            }
            else if(battleWon == 1){
                totalHumanWon ++;
            }
            else{
                totalBalrogWon ++;
            }          

        }
        Console.WriteLine();
        Console.WriteLine("Final Report");
        Console.WriteLine("The total number of time that duel is tie is "+totalDuel);
        Console.WriteLine("The total number of time that Human won is "+totalHumanWon);
        Console.WriteLine("The total number of time that Balrog won is "+totalBalrogWon);

    }
}