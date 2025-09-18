using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;

public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private HeroData heroData;
    [SerializeField] private RelicData relicData;
    [SerializeField] private List<EnemyData> enemyDatas;

    private void Start()
    {
        HeroSystem.Instance.Setup(GameManager.Instance.heroDataRuntime);
        EnemySystem.Instance.Setup(enemyDatas);
        PlateSystem.Instance.Setup(EnemySystem.Instance.enemies);
        CardSystem.Instance.Setup(GameManager.Instance.heroDataRuntime.deck);
        RelicSystem.Instance.AddRelic(new Relic(relicData));

        RefillManaGA refillManaGA = new();
        ActionSystem.Instance.Perform(refillManaGA, () =>
        {
            DrawCardsGA drawCardsGA = new(5);
            ActionSystem.Instance.Perform(drawCardsGA);
        });
    }
}
