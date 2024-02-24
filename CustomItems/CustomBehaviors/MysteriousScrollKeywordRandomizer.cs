using System;
using Characters.Gear.Items;

[Serializable]
public sealed class MysteriousScrollKeyWordRandomizer : KeywordRandomizer
{
    private new void Awake()
    {
        base.Awake();
        _item.keyword1 = Characters.Gear.Synergy.Inscriptions.Inscription.Key.Masterpiece;
        SecondInscriptionRandomizer();
    }

    private void SecondInscriptionRandomizer()
    {
        Random random = new Random();
        int randomNumber = random.Next(0, 4);
        if (randomNumber >= 0 && randomNumber < 1)
        {
            _item.keyword2 = Characters.Gear.Synergy.Inscriptions.Inscription.Key.Brave;
        }
        if (randomNumber >= 1 && randomNumber < 2)
        {
            _item.keyword2 = Characters.Gear.Synergy.Inscriptions.Inscription.Key.ManaCycle;
        }
        if (randomNumber >= 2 && randomNumber < 3)
        {
            _item.keyword2 = Characters.Gear.Synergy.Inscriptions.Inscription.Key.Revenge;
        }
        if (randomNumber == 3 )
        {
            _item.keyword2 = Characters.Gear.Synergy.Inscriptions.Inscription.Key.Mystery;
        }
    }
}
