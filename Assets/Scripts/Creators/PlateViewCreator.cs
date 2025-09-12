using UnityEngine;

public class PlateViewCreator : Singleton<PlateViewCreator>
{
    [SerializeField] private PlateView plateViewPrefab;

    public PlateView CreatePlateView(EnemyView target, Vector3 position, Quaternion rotation)
    {
        PlateView plateView = Instantiate(plateViewPrefab, position, rotation);
        plateView.Setup(target);
        return plateView;
    }
}
