using SerializeReferenceEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Relic")]
public class RelicData : ScriptableObject
{
    [field: SerializeField] public Sprite image { get; private set; }
    [field: SerializeReference, SR] public RelicCondition condition { get; private set; }
    [field: SerializeReference, SR] public AutoTargetEffect autoTargetEffect { get; private set; }
    [field: SerializeField] public bool useAutoTarget { get; private set; } = true;
    [field: SerializeField] public bool useActionCasterAsTarget { get; private set; } = true;
}
