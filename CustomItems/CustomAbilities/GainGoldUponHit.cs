using System;
using Characters;
using Characters.Abilities;
using Level;
using Services;
using Singletons;
using UnityEngine;

namespace CustomItems.CustomAbilities;

[Serializable]
public class GainGoldUponHit : Ability, ICloneable
{
    public class Instance : AbilityInstance<GainGoldUponHit>
    {
        int _stacks;
        public override int iconStacks => _stacks;

        public override Sprite icon
        {
            get
            {
                if (_stacks == 0)
                {
                    return null;
                }
                return ability._defaultIcon;
            }
        }

        public Instance(Character owner, GainGoldUponHit ability) : base(owner, ability)
        {
            this._levelManager = Singleton<Service>.Instance.levelManager;
        }

        public override void OnAttach()
        {
            owner.health.onTakeDamage.Add(100000, new TakeDamageDelegate(this.HandleOnTakeDamage));
            this._levelManager.onMapLoadedAndFadedIn += this.ResetStack;
            _stacks = 5;
        }

        public override void OnDetach()
        {
            owner.health.onTakeDamage.Remove(new TakeDamageDelegate(this.HandleOnTakeDamage));
            this._levelManager.onMapLoadedAndFadedIn -= this.ResetStack;
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
            if (_stacks <= 0)
            {
                return false;
            }
            _stacks --;
            Singleton<Service>.Instance.levelManager.DropGold(15, 5, this.owner.transform.position);
            return false;
        }

        private void ResetStack()
        {
            _stacks = 5;
        }

        private LevelManager _levelManager;
    }

    public override IAbilityInstance CreateInstance(Character owner)
    {
        return new Instance(owner, this);
    }

    public object Clone()
    {
        return new GainGoldUponHit()
        {
            _defaultIcon = _defaultIcon,
        };
    }
}
