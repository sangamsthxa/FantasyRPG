using System;
using FantasyRPG;
using NSubstitute;

namespace FantasyRPGUnitTesting;

[Category("Unit Tests")]
public class ABalrog
{
[Test]
    public void ReportsItsRaceAsBalrog(){
        Balrogs sut = new();
        string race = sut.Race;
        Assert.That(race, Is.EqualTo("Balrog"));
    }

     [Test]
    public void CanInflictBaseDamageTwice()
    {
        int baseDamage =25;
        IRandom mockRandom = Substitute.For<IRandom>();
        Damage mockDamage = Substitute.For<Damage>();
        mockRandom.Get(1,30).Returns(baseDamage); //damage
        mockRandom.Get(1,100).Returns(75); //damage
        Balrogs sut = new(mockRandom,mockDamage)
        {
            Strength = 30
        };
        sut.InflictDamage();
        mockDamage.Received().Base = baseDamage;
        mockDamage.Received().Additional = baseDamage;
        mockDamage.Received().Additional = 0;
        }
[Test]
    public void CanInflictBaseDamageTwiceWithAdditional10()
    {
        int baseDamage =25;
        IRandom mockRandom = Substitute.For<IRandom>();
        Damage mockDamage = Substitute.For<Damage>();
        mockRandom.Get(1,30).Returns(baseDamage); //damage
        mockRandom.Get(1,100).Returns(25); //damage
        Balrogs sut = new(mockRandom,mockDamage)
        {
            Strength = 30
        };
        sut.InflictDamage();
        mockDamage.Received().Base = baseDamage;
        mockDamage.Received().Additional = baseDamage + 10;
        mockDamage.Received().Additional = 10;
    
        }
}
