using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBoardView : MonoBehaviour
{
    [SerializeField] private List<Transform> slots;
    public List<PlateView> plateViews { get; private set; } = new();

    public void AddPlate(EnemyView target)
    {
        Transform slot = slots[plateViews.Count];
        PlateView plateView = PlateViewCreator.Instance.CreatePlateView(target, slot.position, slot.rotation);
        plateView.transform.parent = slot;
        plateViews.Add(plateView);
    }

    public IEnumerator RemovePlate(PlateView plateView)
    {
        plateViews.Remove(plateView);
        Tween tween = plateView.transform.DOScale(Vector3.zero, 0.25f);
        yield return tween.WaitForCompletion();
        Destroy(plateView.gameObject);
    }
}
