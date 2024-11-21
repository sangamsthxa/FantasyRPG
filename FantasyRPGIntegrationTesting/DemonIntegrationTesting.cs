using System;
using FantasyRPG;

namespace FantasyRPGIntegrationTesting;


[Category("Integration Tests")]
public class ADemon
{

    [Test]
    public void Has25PercentChanceInflictingAdditional10Damage()
    {
        Demons sut = new()
        {
            Strength = 30
        };
        int additionalDamageCount = 0;
         for (int i=0; i<20000; i++)
        {
            Damage damage = sut.InflictDamage();
            if(damage.Total == damage.Base + 10)
            {
                additionalDamageCount++;
            }

        }
        decimal percent = additionalDamageCount/20000m;
        Assert.That(percent, Is.EqualTo(0.25).Within(0.02));
    
        }

    [Test]
    public void Has75PercentChanceInflictingBaseDamage()
    {
        Demons sut = new()
        {
            Strength = 30
        };
        int baseDamageCount = 0;
         for (int i=0; i<20000; i++)
        {
            Damage damage = sut.InflictDamage();
            if(damage.Total == damage.Base)
            {
                baseDamageCount++;
            }

        }
        decimal percent = baseDamageCount/20000m;
        Assert.That(percent, Is.EqualTo(0.75).Within(0.02));
    
        }

}
