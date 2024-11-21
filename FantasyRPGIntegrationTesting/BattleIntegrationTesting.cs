using System;
using FantasyRPG;

namespace FantasyRPGIntegrationTesting;

[Category("Integration Tests")]
public class ABattle
{   

[Test]
public void ReportCreatureOneWonTheBattle(){
    Creature human = new Human(){
        Strength =1,
        HitPoints=3
    };
    Creature demon = new Demons(){
        Strength =0,
        HitPoints=3
    };
    Battle sut = new Battle();
    int duel_result=sut.Duel(human,demon);
    Assert.That(duel_result, Is.EqualTo(1));


}

[Test]
public void ReportCreatureTwoWonTheBattle(){
    Creature human = new Human(){
        Strength =0,
        HitPoints=3
    };
    Creature demon = new Demons(){
        Strength =1,
        HitPoints=3
    };
    Battle sut = new Battle();
    int duel_result=sut.Duel(human,demon);
    Assert.That(duel_result, Is.EqualTo(2));

}

[Test]
public void ReportATieForTheBattle(){
    Creature creature1 = new(){
        Strength =1,
        HitPoints=3
    };
    Creature creature2 = new(){
        Strength =1,
        HitPoints=3
    };
    Battle sut = new Battle();
    int duel_result=sut.Duel(creature1,creature2);
    Assert.That(duel_result, Is.EqualTo(0));

}

[Test]
public void ReportTheDuelMessage(){
    Creature creature1 = new(){
        Strength =1,
        HitPoints=3
    };
    Creature creature2 = new(){
        Strength =1,
        HitPoints=3
    };
    Battle sut = new Battle();
    sut.Duel(creature1,creature2);
    List<String> messages= sut.Messages;
    Assert.That(messages.Count, Is.EqualTo(7));

}

}
