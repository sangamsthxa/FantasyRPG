using System;

namespace FantasyRPG;

public class Demons:Creature
{
    public Demons():base()
    {
    }

    public Demons(IRandom random, Damage damage) : base(random, damage)
    {
    }

    public override string Race { get; protected set; } = "Demon";


     public override Damage InflictDamage()
    {
        _ = base.InflictDamage();
        //A human has 25% chance of inflicting additional 10 damage
        if(_random.Get(1,100) <= 25)
        {
          _damage.Additional = 10;
        }
        else {
          _damage.Additional = 0;
        }
        return _damage;
    }

}
