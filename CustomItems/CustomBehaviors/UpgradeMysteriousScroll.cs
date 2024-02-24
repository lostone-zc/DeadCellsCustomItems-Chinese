using System;
using Characters.Gear.Items;
using GameResources;
using Services;
using Singletons;
using UnityEngine;

[Serializable]
public sealed class UpgradeMysteriousScroll : MonoBehaviour
{

    [SerializeField]
    private Item _item = null;

    private void Awake()
    {
        Singleton<Service>.Instance.levelManager.player.playerComponents.inventory.onUpdatedKeywordCounts += CheckUpdateCondition;
    }

    private void OnDestroy()
    {
        Singleton<Service>.Instance.levelManager.player.playerComponents.inventory.onUpdatedKeywordCounts -= CheckUpdateCondition;
    }

    private void CheckUpdateCondition()
    {

        if (_item.keyword2 == Characters.Gear.Synergy.Inscriptions.Inscription.Key.Brave)
        {
            ItemReference itemRef;
            if (GearResource.instance.TryGetItemReferenceByName(_item.name + "_1", out itemRef))
            {

                ItemRequest request = itemRef.LoadAsync();
                request.WaitForCompletion();

                if (_item.state == Characters.Gear.Gear.State.Equipped)
                {
                    Item newItem = Singleton<Service>.Instance.levelManager.DropItem(request, Vector3.zero);
                    newItem.keyword1 = _item.keyword1;
                    newItem.keyword2 = _item.keyword2;
                    _item.ChangeOnInventory(newItem);
                }
            }
        }
        if (_item.keyword2 == Characters.Gear.Synergy.Inscriptions.Inscription.Key.ManaCycle)
        {
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
                    _item.ChangeOnInventory(newItem);
                }
            }
        }
        if (_item.keyword2 == Characters.Gear.Synergy.Inscriptions.Inscription.Key.Revenge)
        {
            ItemReference itemRef;
            if (GearResource.instance.TryGetItemReferenceByName(_item.name + "_3", out itemRef))
            {

                ItemRequest request = itemRef.LoadAsync();
                request.WaitForCompletion();

                if (_item.state == Characters.Gear.Gear.State.Equipped)
                {
                    Item newItem = Singleton<Service>.Instance.levelManager.DropItem(request, Vector3.zero);
                    newItem.keyword1 = _item.keyword1;
                    newItem.keyword2 = _item.keyword2;
                    _item.ChangeOnInventory(newItem);
                }
            }
        }
        if (_item.keyword2 == Characters.Gear.Synergy.Inscriptions.Inscription.Key.Mystery)
        {
            ItemReference itemRef;
            if (GearResource.instance.TryGetItemReferenceByName(_item.name + "_4", out itemRef))
            {

                ItemRequest request = itemRef.LoadAsync();
                request.WaitForCompletion();

                if (_item.state == Characters.Gear.Gear.State.Equipped)
                {
                    Item newItem = Singleton<Service>.Instance.levelManager.DropItem(request, Vector3.zero);
                    newItem.keyword1 = _item.keyword1;
                    newItem.keyword2 = _item.keyword2;
                    _item.ChangeOnInventory(newItem);
                }
            }
        }
    }

}