using System.Collections.Generic;
using UnityEngine;

public class PlateSystem : Singleton<PlateSystem>
{
    [SerializeField] private PlateBoardView plateBoardView;
    public List<Plate> plates { get; private set; } = new();
    
    public void Setup(List<EnemyView> enemies) // initialize plates for each enemy at start of combat
    {
        foreach (var enemy in enemies)
        {
            plateBoardView.AddPlate(enemy);
        }
    }
    private void OnEnable()
    {
        ActionSystem.SubscribeReaction<EnemyTurnGA>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    private void OnDisable()
    {
        ActionSystem.UnsubscribeReaction<EnemyTurnGA>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    private void EnemyTurnPostReaction(EnemyTurnGA enemyTurnGA)
    {
        plateBoardView.UpdatePlates();
    }
}
