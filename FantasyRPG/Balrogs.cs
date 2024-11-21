using System;

namespace FantasyRPG;

public class Balrogs: Demons
{
    public Balrogs():base()
    {
    }

    public Balrogs(IRandom random, Damage damage) : base(random, damage)
    {
    }

    public override string Race { get; protected set; } = "Balrog";

     public override Damage InflictDamage()
    {
        _ = base.InflictDamage();     
        _damage.Additional += _damage.Base;
        return _damage;
    }

}
