using System.Collections.Generic;
using System.Linq;
using Characters;
using Characters.Abilities;
using Characters.Gear.Synergy.Inscriptions;
using CustomItems.CustomAbilities;
using UnityEngine.AddressableAssets;

namespace CustomItems;

public class CustomItems
{
    public static readonly List<CustomItemReference> Items = InitializeItems();

    /**
     * TODO
     * 
     */

    private static List<CustomItemReference> InitializeItems()
    {
        List<CustomItemReference> items = new();
        {
            var item = new CustomItemReference();
            item.name = "CursedSword";
            item.rarity = Rarity.Legendary;

            // EN: Cursed Sword
            // KR: 저주받은 검
            // ZH: 诅咒之刃
            item.itemName = "诅咒之刃";

            // EN: Increases <color=#F25D1C>Physical Attack</color> by 1000%, and amplifies <color=#F25D1C>Physical Attack</color> by 500%.\nInstant death when hit, negating damage nullification except for invincibility and parrying.
            // KR: <color=#F25D1C>물리공격력</color>이 1000% 증가 및 500% 증폭됩니다.\n피격 시 무적과 패링을 제외한 모든 피해 무효화 수단을 무시하고 즉사합니다.
            // ZH: 增加1000%<color=#F25D1C>物理攻击力</color>，增幅500%<color=#F25D1C>物理攻击力</color>。\n一击即死，除了格挡或无敌或疾驰闪避。
            item.itemDescription = "增加1000%<color=#F25D1C>物理攻击力</color>，增幅500%<color=#F25D1C>物理攻击力</color>。\n一击即死，除了格挡或无敌或疾驰闪避。";

            // EN: Kill before you get killed. Simple, right?
            // KR: 자, 죽기 전에 죽이면 돼. 간단하지?
            // ZH: 菜就多练练！
            item.itemLore = "菜就多练练！";

            item.prefabKeyword1 = Inscription.Key.Execution;
            item.prefabKeyword2 = Inscription.Key.Arms;

            item.stats = new Stat.Values(new Stat.Value[] {
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 10.0),
                new Stat.Value(Stat.Category.Percent, Stat.Kind.PhysicalAttackDamage, 5.0),
            });

            item.abilities = new Ability[] {
                new InstaKillIgnoringNegation(),
            };

            items.Add(item);
        }

        {
            var item = new CustomItemReference();
            item.name = "MysteriousScroll";
            item.rarity = Rarity.Unique;

            // EN: Mysterious Scroll
            // KR: 미지의 두루마리
            // ZH: 未知卷轴
            item.itemName = "未知卷轴";

            // EN: Increases <color=#F25D1C>Physical Attack</color> by 25%.\nIncreases skill cooldown speed by 25%.\nDecreases incoming damage by 10%.\nIncreases Max HP by 20\nThe second inscription of this item is randomly chosen between Courage, Mana Cycle, Revenge, and Mystery.\nThe improved version of this item changes depending on its second inscription.
            // KR: <color=#F25D1C>물리공격력</color>이 25% 증가합니다.\n스킬 쿨다운 속도가 25% 증가합니다.\n받는 데미지가 10% 감소합니다.\n최대체력이 20 증가합니다\n이 아이템의 두번째 각인은 임의로 용기, 마나 순환, 복수, 그리고 신비중 하나로 지정됩니다.\n이 아이템의 강화된 버전은 두번째 각인에 따라 바뀝니다.
            // ZH: 增加25%<color=#F25D1C>物理攻击力</color>，\n增加技能冷却速度25%，\n减少收到伤害10%，\n增加最大生命值20。\n该物品第二个刻印在勇气，复仇，魔力循环，神秘四个刻印中随机出现一个。\n该物品升级效果根据第二个刻印发生变化。
            item.itemDescription = "增加25%<color=#F25D1C>物理攻击力</color>，\n增加技能冷却速度25%，\n减少收到伤害10%，\n增加最大生命值20。\n该物品第二个刻印在勇气，复仇，魔力循环，神秘四个刻印中随机出现一个。\n该物品升级效果根据第二个刻印发生变化。";

            // EN: Not knowing what is inside makes it valuable.
            // KR: 안에 뭐가 들었는지 모르니까 가치가 있는 법이다.
            // ZH: 神秘使其神秘。
            item.itemLore = "神秘使其神秘。";

            item.prefabKeyword1 = Inscription.Key.Masterpiece;
            item.prefabKeyword2 = Inscription.Key.None;

            item.stats = new Stat.Values(new Stat.Value[] {
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.25),
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.SkillCooldownSpeed, 0.25),
                new Stat.Value(Stat.Category.Percent, Stat.Kind.TakingDamage, 0.9),
                new Stat.Value(Stat.Category.Fixed, Stat.Kind.Health, 20),
            });

            item.extraComponents = new[] {
                typeof(MysteriousScrollKeyWordRandomizer),
            };

            items.Add(item);
        }

        {
            var item = new CustomItemReference();
            item.name = "MysteriousScroll_2";
            item.obtainable = false;
            item.rarity = Rarity.Unique;

            // EN: Scroll of Power: Evolution
            // KR: 권능의 두루마리: 진화체
            // ZH: Missing translation
            item.itemName = "Scroll of Power: Evolution";

            // EN: If this item was found unintentionally, please report to me ASAP!
            // KR: 만약 예기치 않게 이 아이템을 발견하셨다면, 저한테 바로 신고해주세요!
            // ZH: 你不应该获得这个物品。如果你的确获得了，那就是bug。
            item.itemDescription = "你不应该获得这个物品。如果你的确获得了，那就是bug。";

            // EN: W-Where did you get this from...?
            // KR: 뭐야... 이거 어디서 가져온거야..?
            // ZH: Missing translation
            item.itemLore = "W-Where did you get this from...?";

            item.prefabKeyword1 = Inscription.Key.Masterpiece;
            item.prefabKeyword2 = Inscription.Key.None;

            item.forbiddenDrops = new[] { "MysteriousScroll" };

            item.extraComponents = new[] {
                typeof(UpgradeMysteriousScroll),
            };

            items.Add(item);
        }

        {
            var item = new CustomItemReference();
            item.name = "MysteriousScroll_2_1";
            item.obtainable = false;
            item.rarity = Rarity.Unique;

            // EN: Scroll of Power: Brutality
            // KR: 권능의 두루마리: 잔혹성
            // ZH: 暴虐卷轴
            item.itemName = "暴虐卷轴";

            // EN: Increases <color=#F25D1C>Physical Attack</color> by 75%.\nIncreases Max HP by 55.
            // KR: <color=#F25D1C>물리공격력</color>이 75% 증가합니다.\n최대체력이 55 증가합니다.
            // ZH: 增加<color=#F25D1C>物理攻击力</color>75%，\n增加最大生命值55。
            item.itemDescription = "增加<color=#F25D1C>物理攻击力</color>75%，\n增加最大生命值55。";

            // EN: The scroll of power representing brutality.\nOnly true fighters can learn how to use this scroll.
            // KR: 잔혹성을 대표하는 권능의 두루마리.\n진정한 싸움꾼들만이 이 두루마리를 응용할 수 있다.
            // ZH: 代表暴虐力量的卷轴，\n只有真正的斗士会理解此卷轴的用法。
            item.itemLore = "代表暴虐力量的卷轴，\n只有真正的斗士会理解此卷轴的用法。";

            item.prefabKeyword1 = Inscription.Key.None;
            item.prefabKeyword2 = Inscription.Key.None;

            item.forbiddenDrops = new[] { "MysteriousScroll" };

            item.stats = new Stat.Values(new Stat.Value[] {
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.75),
                new Stat.Value(Stat.Category.Fixed, Stat.Kind.Health, 55),
            });

            items.Add(item);
        }

        {
            var item = new CustomItemReference();
            item.name = "MysteriousScroll_2_2";
            item.obtainable = false;
            item.rarity = Rarity.Unique;

            // EN: Scroll of Power: Tactics
            // KR: 권능의 두루마리: 전략가
            // ZH: 战术卷轴
            item.itemName = "战术卷轴";

            // EN: Increases skill cooldown speed by 75%.\nIncreases Max HP by 40.
            // KR: 스킬 쿨다운 속도가 75% 증가합니다.\n최대체력이 40 증가합니다.
            // ZH: 增加技能冷却速度75%，\n增加最大生命值40。
            item.itemDescription = "增加技能冷却速度75%，\n增加最大生命值40。";

            // EN: The scroll of power representing tactics.\nAlways remember that patience is the key to victory.
            // KR: 전략가를 대표하는 권능의 두루마리.\n침착함이야말로 승리를 향한 길임을 명심하자.
            // ZH: 代表战术力量的卷轴，\n记住，耐心是克敌之道。
            item.itemLore = "代表战术力量的卷轴，\n记住，耐心是克敌之道。";

            item.prefabKeyword1 = Inscription.Key.None;
            item.prefabKeyword2 = Inscription.Key.None;

            item.forbiddenDrops = new[] { "MysteriousScroll" };

            item.stats = new Stat.Values(new Stat.Value[] {
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.SkillCooldownSpeed, 0.75),
                new Stat.Value(Stat.Category.Fixed, Stat.Kind.Health, 40),
            });

            items.Add(item);
        }

        {
            var item = new CustomItemReference();
            item.name = "MysteriousScroll_2_3";
            item.obtainable = false;
            item.rarity = Rarity.Unique;

            // EN: Scroll of Power: Survival
            // KR: 권능의 두루마리: 생존술
            // ZH: 生存卷轴
            item.itemName = "生存卷轴";

            // EN: Decreases incoming damage by 30%.\nIncreases Max HP by 60.
            // KR: 받는 데미지가 30% 감소합니다.\n최대체력이 60 증가합니다.
            // ZH: 减少受到伤害30%，\n增加最大生命值60。
            item.itemDescription = "减少受到伤害30%，\n增加最大生命值60。";

            // EN: The scroll of power representing survival.\nIt isn't the strongest that survives, it's the survived who is the strongest.
            // KR: 생존술을 대표하는 권능의 두루마리.\n강한 자가 살아남는 것이 아니라, 살아남는 자가 강한 것이다.
            // ZH: 代表生存力量的卷轴，\n不是最强的才能活下来，活下来的才称得上最强。
            item.itemLore = "代表生存力量的卷轴，\n不是最强的才能活下来，活下来的才称得上最强。";

            item.prefabKeyword1 = Inscription.Key.None;
            item.prefabKeyword2 = Inscription.Key.None;

            item.forbiddenDrops = new[] { "MysteriousScroll" };

            item.stats = new Stat.Values(new Stat.Value[] {
                new Stat.Value(Stat.Category.Percent, Stat.Kind.TakingDamage, 0.7),
                new Stat.Value(Stat.Category.Fixed, Stat.Kind.Health, 60),
            });

            items.Add(item);
        }

        {
            var item = new CustomItemReference();
            item.name = "MysteriousScroll_2_4";
            item.obtainable = false;
            item.rarity = Rarity.Unique;

            // EN: Epic Scroll of Power
            // KR: 전능의 두루마리
            // ZH: 传奇卷轴
            item.itemName = "传奇卷轴";

            // EN: Increases <color=#F25D1C>Physical Attack</color> by 40%.\nIncreases skill cooldown speed by 40%.\nDecreases incoming damage by 20%.\nIncreases Max HP by 45.
            // KR: <color=#F25D1C>물리공격력</color>이 40% 증가합니다.\n스킬 쿨다운 속도가 40% 증가합니다.\n받는 데미지가 20% 감소합니다.\n최대체력이 45 증가합니다.
            // ZH: 增加<color=#F25D1C>物理攻击力</color>40%，\n增加技能冷却速度40%，\n减少受到伤害20%。\n增加最大生命值45。
            item.itemDescription = "增加<color=#F25D1C>物理攻击力</color>40%，\n增加技能冷却速度40%，\n减少受到伤害20%。\n增加最大生命值45。";

            // EN: This will make training at least 3 times more efficient!
            // KR: 이걸로 수련의 능률이 3배는 오르겠군!
            // ZH: 这训练效率一下拉了三倍！
            item.itemLore = "这训练效率一下拉了三倍！";

            item.prefabKeyword1 = Inscription.Key.None;
            item.prefabKeyword2 = Inscription.Key.None;

            item.forbiddenDrops = new[] { "MysteriousScroll" };

            item.stats = new Stat.Values(new Stat.Value[] {
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.PhysicalAttackDamage, 0.4),
                new Stat.Value(Stat.Category.PercentPoint, Stat.Kind.SkillCooldownSpeed, 0.4),
                new Stat.Value(Stat.Category.Percent, Stat.Kind.TakingDamage, 0.8),
                new Stat.Value(Stat.Category.Fixed, Stat.Kind.Health, 45),
            });

            items.Add(item);
        }

        {
            var item = new CustomItemReference();
            item.name = "ShieldOfGreed";
            item.rarity = Rarity.Common;

            // EN: Shield of Greed
            // KR: 탐욕의 방패
            // ZH: 贪婪盾
            item.itemName = "贪婪盾";

            // EN: Upon being hit, you gain 15 gold (5 times maximum per room).
            // KR: 피격 시 15 금화가 떨어집니다 (방마다 5회 제한).
            // ZH: 每次受击获得15金币（每个房间最多获得5次）。
            item.itemDescription = "每次受击获得15金币（每个房间最多获得5次）。";

            // EN: Seriously, who would ever make money out of getting hit?\nLet's do it.
            // KR: 맞으면서 돈을 벌다니, 그것 참 한심한 생각이군.\n당장 하자.
            // ZH: 讲真吼，谁会想到挨打来挣钱？走起。
            item.itemLore = "讲真吼，谁会想到挨打来挣钱？走起。";

            item.prefabKeyword1 = Inscription.Key.Fortress;
            item.prefabKeyword2 = Inscription.Key.Treasure;

            item.abilities = new Ability[] {
                new GainGoldUponHit(),
            };

            items.Add(item);
        }

        {
            var item = new CustomItemReference();
            item.name = "EmergencyHealthFlask";
            item.rarity = Rarity.Rare;

            // EN: Emergency Health Flask
            // KR: 비상용 회복약
            // ZH: 小血瓶
            item.itemName = "小血瓶";

            // EN: When having less than 20% of your health, empties the Health Flask and heals 40% of your health.
            // KR: 현재 체력이 20% 미만일 시 회복약을 비우며 현재 체력의 40%를 회복합니다.
            // ZH: 当你生命值低于20%以下时，消耗小血瓶回复40%血量。
            item.itemDescription = "当你生命值低于20%以下时，消耗小血瓶回复40%血量。";

            // EN: It is disposable, so please handle with care.
            // KR: 일회용이니 취급에 주의해주세요.
            // ZH: 这玩意是一次性的，你小心点使。
            item.itemLore = "这玩意是一次性的，你小心点使。";

            item.prefabKeyword1 = Inscription.Key.Antique;
            item.prefabKeyword2 = Inscription.Key.Relic;

            item.extraComponents = new[] {
                typeof(ChangeItemWhenLowHealth),
            };

            items.Add(item);
        }

        {
            var item = new CustomItemReference();
            item.name = "EmergencyHealthFlask_2";
            item.obtainable = false;
            item.rarity = Rarity.Rare;

            // EN: Empty Flask
            // KR: 빈 유리관
            // ZH: 空血瓶
            item.itemName = "空血瓶";

            // EN: When a boss is defeated, refills the Empty Flask.
            // KR: 보스 처치 시 회복약이 다시 채워집니다.
            // ZH: 每击败一个boss，回满血瓶。
            item.itemDescription = "每击败一个boss，回满血瓶。";

            // EN: You're not supposed to... chug that...
            // KR: 아니... 그걸 한입에 쳐 마시면... 하...
            // ZH: 不是哥们，你喝那么快干啥...
            item.itemLore = "不是哥们，你喝那么快干啥...";

            item.prefabKeyword1 = Inscription.Key.Antique;
            item.prefabKeyword2 = Inscription.Key.Relic;

            item.extraComponents = new[] {
                typeof(ChangeItemWhenKilledBoss),
            };

            items.Add(item);
        }

        return items;
    }

    internal static void LoadSprites()
    {
        Items.ForEach(item => item.LoadSprites());
    }

    internal static Dictionary<string, string> MakeStringDictionary()
    {
        Dictionary<string, string> strings = new(Items.Count * 8);

        foreach (var item in Items)
        {
            strings.Add("item/" + item.name + "/name", item.itemName);
            strings.Add("item/" + item.name + "/desc", item.itemDescription);
            strings.Add("item/" + item.name + "/flavor", item.itemLore);
        }

        return strings;
    }

    internal static List<Masterpiece.EnhancementMap> ListMasterpieces()
    {
        var masterpieces = Items.Where(i => (i.prefabKeyword1 == Inscription.Key.Masterpiece) || (i.prefabKeyword2 == Inscription.Key.Masterpiece))
                                .ToDictionary(i => i.name);

        return masterpieces.Where(item => masterpieces.ContainsKey(item.Key + "_2"))
                           .Select(item => new Masterpiece.EnhancementMap()
                           {
                               _from = new AssetReference(item.Value.guid),
                               _to = new AssetReference(masterpieces[item.Key + "_2"].guid),
                           })
                           .ToList();
    }
}
