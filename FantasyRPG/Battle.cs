using System;

namespace FantasyRPG;

public class Battle
{

     public List<String> Messages { get; set;} = new List<string>();



    public int Duel(Creature creature1, Creature creature2){

            while(creature1.HitPoints>0 && creature2.HitPoints>0){
                if(creature1.Strength > 0){
                    int damage1 = creature1.Attack(creature2);
                    Messages.Add($"The {creature1.Race} deals {damage1} damage to the {creature2.Race}.");
                }
                if(creature2.Strength > 0){
                   int damage2= creature2.Attack(creature1);
                     Messages.Add($"The {creature2.Race} deals {damage2} damage to the {creature1.Race}.");
                }

            }

            if(creature2.HitPoints < 1 && creature1.HitPoints < 1 ){
                Messages.Add("The duel is a tie");
                return 0;
            }
            else if(creature1.HitPoints < 1)
            {
                Messages.Add($"The {creature2.Race} won the duel");
                return 2;
            }
            else{
                Messages.Add($"The {creature1.Race} won the duel");
                return 1;
            }

    }

}
