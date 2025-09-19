using System.Collections.Generic;
using UnityEngine;

public class RelicSystem : Singleton<RelicSystem>
{
    [SerializeField] private RelicsUI relicsUI;
    private readonly List<Relic> relics = new();

    private void OnDisable()
    {
        foreach (var relic in relics)
        {
            relic.OnRemove();
        }
    }

    public void AddRelic(Relic relic)
    {
        relics.Add(relic);
        relicsUI.AddRelicUI(relic);
        relic.OnAdd();
    }

    public void RemoveRelic(Relic relic)
    {
        relics.Remove(relic);
        relicsUI.RemoveRelicUI(relic);
        relic.OnRemove();
    }
    
    public void ClearRelics()
    {
        foreach (Relic relic in relics)
        {
            relic.OnRemove();
        }
    }
}
