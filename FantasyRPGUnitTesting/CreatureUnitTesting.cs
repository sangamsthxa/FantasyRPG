using System;
using System.Security.Cryptography;
using FantasyRPG;
using NSubstitute;
using NUnit.Framework.Internal;

namespace FantasyRPGUnitTesting;

 [Category("Unit Tests")]
public class ACreature
{


 [Test]
    public void ReportsItsRaceAsUnknown(){
        Creature sut = new();
        string race = sut.Race;
        Assert.That(race, Is.EqualTo("Unknown"));
    }

    [Test]
    public void CanInflictABaseDamage(){
        IRandom mockRandom = Substitute.For<IRandom>();
        mockRandom.Get(1,30).Returns(25);
        Damage mockDamage = Substitute.For<Damage>();
        Creature sut = new(mockRandom, mockDamage)
        {
            Strength = 30
        };
        Damage baseDamage = sut.InflictDamage();
        Assert.That(baseDamage.Base, Is.EqualTo(25));
            }

    [Test]
    public void Has99PercentChanceOfTakingDamage(){
        IRandom randomMock = Substitute.For<IRandom>();
        randomMock.Get(1,100).Returns(89);
        Damage mockDamage = Substitute.For<Damage>();
        Creature sut = new(randomMock, mockDamage)
        {
            Strength =1, 
            HitPoints = 100
        };
        int damage = 10;
        
        _ = sut.TakeDamage(damage);
        Assert.That(sut.HitPoints, Is.EqualTo(90));

    }

     [Test]
    public void Has1PercentChanceOfNotTakingDamage(){
        IRandom randomMock = Substitute.For<IRandom>();
        randomMock.Get(1,100).Returns(1);
        Damage mockDamage = Substitute.For<Damage>();
        Creature sut = new(randomMock,mockDamage)
        {
            Strength =1, 
            HitPoints = 100
        };
        int damage = 10;
        
        _ = sut.TakeDamage(damage);
        Assert.That(sut.HitPoints, Is.EqualTo(100));

    }

    [Test]
    public void CanAttackAnotherCreature(){
        IRandom randomMock = Substitute.For<IRandom>();
        randomMock.Get(1,Arg.Any<int>()).Returns(1);
        Damage mockDamage = Substitute.For<Damage>();
        Creature sut = new(randomMock,mockDamage)
        {
            Strength =1, 
            HitPoints = 100
        };
        Creature mockCreature = Substitute.For<Creature>();
        _ = sut.Attack(mockCreature);
        mockCreature.Received().TakeDamage(Arg.Any<int>());
    }

    
    
}
