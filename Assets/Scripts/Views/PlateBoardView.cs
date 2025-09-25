using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBoardView : MonoBehaviour
{
    [SerializeField] private List<Transform> slots;
    public List<PlateView> plateViews { get; private set; } = new();
    [SerializeField] private GameObject breadPrefab;
    [SerializeField] private GameObject jamPrefab;

    public void AddPlate(EnemyView target)
    {
        Transform slot = slots[plateViews.Count];
        PlateView plateView = PlateViewCreator.Instance.CreatePlateView(target, slot.position, slot.rotation);
        plateView.transform.parent = slot;
        plateViews.Add(plateView);
    }

    public IEnumerator RemovePlate(PlateView plateView)
    {
        plateView.serving = false;
        plateViews.Remove(plateView);
        Tween tween = plateView.transform.DOScale(Vector3.zero, 0.25f);
        yield return tween.WaitForCompletion();
        Destroy(plateView.gameObject);
    }

    public void UpdatePlates()
    {
        List<PlateView> platesToRemove = new();
        foreach (var plate in plateViews)
        {
            if (plate.target == null)
                platesToRemove.Add(plate);
        }
        foreach (var plate in platesToRemove)
            StartCoroutine(RemovePlate(plate));
    }

    public void SpawnIngredientAbovePlate(string cardClass, PlateView plateView)
    {
        GameObject prefabToSpawn;
        switch (cardClass)
        {
            case "Bread":
                prefabToSpawn = breadPrefab;
                break;
            case "Jam":
                prefabToSpawn = jamPrefab;
                break;
            default:
                prefabToSpawn = null;
                break;
        }
        if (prefabToSpawn != null)
        {
            float heightOffset = 0.5f;
            int stackCount = plateView.spawnedIngredients.Count;
            Vector3 spawnPosition = plateView.transform.position + Vector3.up * (2f + heightOffset * stackCount);
            GameObject ingredient = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            plateView.TrackIngredient(ingredient);
            Vector3 targetPosition = plateView.transform.position + Vector3.up * (0.5f + heightOffset * stackCount);
            ingredient.transform.DOMove(targetPosition, 0.5f).SetEase(Ease.OutQuad);
        }
    }
}
