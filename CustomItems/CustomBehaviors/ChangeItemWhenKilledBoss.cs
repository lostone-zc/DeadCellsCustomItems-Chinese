using System;
using Characters;
using Characters.Gear.Items;
using GameResources;
using Services;
using Singletons;
using UnityEngine;

[Serializable]
public sealed class ChangeItemWhenKilledBoss : MonoBehaviour
{

    [SerializeField]
    private Item _item = null;

    private void Awake()
    {
        Singleton<Service>.Instance.levelManager.player.onKilled += CheckUpdateCondition;
    }

    private void OnDestroy()
    {
        Singleton<Service>.Instance.levelManager.player.onKilled -= CheckUpdateCondition;
    }

    private void CheckUpdateCondition(ITarget target, ref Damage damage)
    {
        Characters.Character character = target.character;
        if (character.type != Characters.Character.Type.Boss) return;
        ItemReference itemRef;
        if (GearResource.instance.TryGetItemReferenceByName(_item.name.Substring(0, _item.name.Length - 2), out itemRef))
        {
            ItemRequest request = itemRef.LoadAsync();
            request.WaitForCompletion();

            if (_item.state == Characters.Gear.Gear.State.Equipped)
            {
                Item newItem = Singleton<Service>.Instance.levelManager.DropItem(request, Vector3.zero);
                newItem.keyword1 = _item.keyword1;
                newItem.keyword2 = _item.keyword2;
                newItem._gearTag = _item._gearTag;
                _item.ChangeOnInventory(newItem);
            }
        }
    }
}
