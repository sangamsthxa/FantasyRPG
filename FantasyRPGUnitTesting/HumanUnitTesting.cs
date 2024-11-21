using System;
using FantasyRPG;
using NSubstitute;

namespace FantasyRPGUnitTesting;

public class AHuman
{
    [Test]
    public void ReportsItsRaceAsHuman(){
        Human sut = new();
        string race = sut.Race;
        Assert.That(race, Is.EqualTo("Human"));
    }

//[Unit] A human has a 10% chance of inflicting double damamge
     [Test]
    public void Has10PercentChanceInflictingDoubleDamage()
    {
        int baseDamage =25;
        IRandom mockRandom = Substitute.For<IRandom>();
        Damage mockDamage = Substitute.For<Damage>();
        mockRandom.Get(1,30).Returns(baseDamage); //damage
        mockRandom.Get(1,100).Returns(10); //10% chance
        Human sut = new(mockRandom,mockDamage)
        {
            Strength = 30
        };
        sut.InflictDamage();
        mockDamage.Received().Additional = baseDamage;
    
        }


}
