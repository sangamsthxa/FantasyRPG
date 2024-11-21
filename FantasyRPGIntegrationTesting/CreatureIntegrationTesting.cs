using System;
using FantasyRPG;

namespace FantasyRPGIntegrationTesting;

[Category("Integration Tests")]
public class ACreature
{

[Test]
 public void CanInflictBaseDamage(){
    Creature sut = new(){
        Strength = 30
    };

    for(int i=0; i<100; i++)
    {
        var actual = sut.InflictDamage();
        Assert.That(actual.Base, Is.InRange(1,30));
    }
 }

   [Test]
    public void Has99PercentChanceOfTakingDamage(){
        Creature sut = new()
        {
            Strength =1, 
            HitPoints = 100
        };
        int damageTakenCount = 0;
        const decimal MAX = 10000;
        for (int i = 0; i < MAX; i++)
        {
            int damageTaken = sut.TakeDamage(1);
            if(damageTaken > 0){
                damageTakenCount++;
            }
        }       
        decimal percent  = damageTakenCount/MAX;
        Assert.That(percent, Is.EqualTo(.99).Within(0.002));

    }

     [Test]
    public void Has1PercentChanceOfNotTakingDamage(){
  
        Creature sut = new()
        {
            Strength =1, 
            HitPoints = 100
        };
        int noDamageCount = 0;
        const decimal MAX = 10000;
        for (int i = 0; i < MAX; i++)
        {
            int damageTaken = sut.TakeDamage(1);
            if(damageTaken == 0){
                noDamageCount++;
            }
        }       
        decimal percent  = noDamageCount/MAX;
        Assert.That(percent, Is.EqualTo(.01).Within(0.002));

    }
}
