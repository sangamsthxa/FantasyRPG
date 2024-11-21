using System;

namespace FantasyRPG;

public class Creature
{
    protected IRandom _random;
    protected Damage _damage;

    public Creature()
    {
        _random = new RandomGenerator();
        _damage = new();
    }

    public Creature(IRandom random, Damage damage)
    {
        _random = random;
        _damage = damage;
    }

    public virtual string Race { get; protected set; } = "Unknown";
    public virtual int Strength { get; set; }
    public virtual int HitPoints { get; set; }

    public int Attack(Creature creature)
    {

        return creature.TakeDamage(InflictDamage().Total);
    }

    public virtual Damage InflictDamage()
    {
        _damage.Base = _random.Get(1,Strength);
        return _damage;
    }

    public virtual int TakeDamage(int damage)
    {
        // All creatures have a 1% chance of dodging the damage
        if (_random.Get(1,100) < 2)
        {
            damage = 0;
        }
        HitPoints -= damage;
        return damage;
    }
}
