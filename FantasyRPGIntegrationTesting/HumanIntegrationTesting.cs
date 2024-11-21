using System;
using FantasyRPG;

namespace FantasyRPGIntegrationTesting;

[Category("Integration Tests")]
public class AHuman
{
    // [Integration] A human has a 10% chance of inflicting double damage.
    [Test]
    public void Has10PercentChanceInflictingDoubleDamage(){
        Human sut = new (){
            Strength = 30
        };
        int doubleDamageCount = 0;
        for (int i=0; i<20000; i++)
        {
            Damage damage = sut.InflictDamage();
            if(damage.Total == damage.Base * 2)
            {
                doubleDamageCount++;
            }

        }
        decimal percent = doubleDamageCount/20000m;
        Assert.That(percent, Is.EqualTo(0.1).Within(0.02));

    }


}
