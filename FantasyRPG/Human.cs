using System;

namespace FantasyRPG;

public class Human: Creature
{
      public override string Race { get; protected set; } = "Human";

      public Human():base(){

      }

    public Human(IRandom random, Damage damage) : base(random, damage)
    {
    }

    public override Damage InflictDamage()
    {
        _ = base.InflictDamage();
        //A human has 10% chance of inflicting double damage
        if(_random.Get(1,100) <= 10)
        {
          _damage.Additional = _damage.Base;
        }
        else{
          _damage.Additional = 0;
        }
        return _damage;
    }
}
