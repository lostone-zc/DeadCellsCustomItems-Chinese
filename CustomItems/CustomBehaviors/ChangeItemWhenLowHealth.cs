using System;
using Characters.Gear.Items;
using GameResources;
using Services;
using Singletons;
using UnityEngine;

[Serializable]
public sealed class ChangeItemWhenLowHealth : MonoBehaviour
{

    [SerializeField]
    private Item _item = null;

    private void Awake()
    {
        Singleton<Service>.Instance.levelManager.player.health.onChanged += CheckUpdateCondition;
    }

    private void OnDestroy()
    {
        Singleton<Service>.Instance.levelManager.player.health.onChanged -= CheckUpdateCondition;
    }

    private void CheckUpdateCondition()
    {
        var playerHealth = Singleton<Service>.Instance.levelManager.player.health;

        if (playerHealth.percent < 0.2)
        {
            playerHealth.Heal(playerHealth.maximumHealth / 10 * 4);
            ItemReference itemRef;
            if (GearResource.instance.TryGetItemReferenceByName(_item.name + "_2", out itemRef))
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
}
