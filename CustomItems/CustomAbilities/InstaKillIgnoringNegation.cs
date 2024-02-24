using System;
using Characters;
using Characters.Abilities;

namespace CustomItems.CustomAbilities;

[Serializable]
public class InstaKillIgnoringNegation : Ability, ICloneable
{
    public class Instance : AbilityInstance<InstaKillIgnoringNegation>
    {
        public Instance(Character owner, InstaKillIgnoringNegation ability) : base(owner, ability)
        {
        }

        public override void OnAttach()
        {
            owner.health.onTakeDamage.Add(2000, new TakeDamageDelegate(this.HandleOnTakeDamage));
        }

        public override void OnDetach()
        {
            owner.health.onTakeDamage.Remove(new TakeDamageDelegate(this.HandleOnTakeDamage));
        }

        private bool HandleOnTakeDamage(ref Characters.Damage damage)
        {
            if (owner.invulnerable.value)
            {
                return false;
            }
            if (damage.attackType.Equals(Characters.Damage.AttackType.None))
            {
                return false;
            }
            if (damage.@null)
            {
                return false;
            }
            if (damage.amount < 1.0)
            {
                return false;
            }
            owner.health.TryKill();
            return false;
        }
    }

    public override IAbilityInstance CreateInstance(Character owner)
    {
        return new Instance(owner, this);
    }

    public object Clone()
    {
        return new InstaKillIgnoringNegation()
        {
            _defaultIcon = _defaultIcon,
        };
    }
}
