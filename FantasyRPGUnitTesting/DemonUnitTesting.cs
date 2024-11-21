using System;
using FantasyRPG;
using NSubstitute;

namespace FantasyRPGUnitTesting;

[Category("Unit Tests")]
public class ADemon
{

[Test]
    public void ReportsItsRaceAsDemon(){
        Demons sut = new();
        string race = sut.Race;
        Assert.That(race, Is.EqualTo("Demon"));
    }

[Test]
    public void Has25PercentChanceInflictingAdditional10Damage()
    {
        int baseDamage =25;
        IRandom mockRandom = Substitute.For<IRandom>();
        Damage mockDamage = Substitute.For<Damage>();
        mockRandom.Get(1,30).Returns(baseDamage); //damage
        mockRandom.Get(1,100).Returns(25); //25% chance
        Demons sut = new(mockRandom,mockDamage)
        {
            Strength = 30
        };
        sut.InflictDamage();
        mockDamage.Received().Base = 25;
        mockDamage.Received().Additional = 10;
    
        }

    [Test]
    public void Has75PercentChanceInflictingBaseDamage()
    {
        int baseDamage =25;
        IRandom mockRandom = Substitute.For<IRandom>();
        Damage mockDamage = Substitute.For<Damage>();
        mockRandom.Get(1,30).Returns(baseDamage); //damage
        mockRandom.Get(1,100).Returns(75); //75% chance
        Demons sut = new(mockRandom,mockDamage)
        {
            Strength = 30
        };
        sut.InflictDamage();
        mockDamage.Received().Base = 25;
        mockDamage.Received().Additional = 0;
    
        }

}
