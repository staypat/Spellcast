using System.Collections;
using UnityEngine;
using static DG.Tweening.DOTweenCYInstruction;

public class EndTurnButtonUI : MonoBehaviour
{
    [SerializeField] private PlateBoardView plateBoardView;

    public void OnClick()
    {
        StartCoroutine(EndTurn());
    }

    private IEnumerator EndTurn()
    {
        foreach (var plate in plateBoardView.plateViews)
        {
            StartCoroutine(plate.Serve());
            yield return new WaitWhile(() => plate.serving);
        }

        plateBoardView.UpdatePlates();

        EnemyTurnGA enemyTurnGA = new();
        ActionSystem.Instance.Perform(enemyTurnGA);
        //yield return new WaitWhile(() => ActionSystem.Instance.IsPerforming);

        //plateBoardView.UpdatePlates();
    }
}
