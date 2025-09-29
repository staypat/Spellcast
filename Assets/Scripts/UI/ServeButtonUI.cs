using System.Collections;
using UnityEngine;

public class ServeButtonUI : MonoBehaviour
{
    [SerializeField] private PlateView plateView;
    [SerializeField] private Canvas canvas;
    private PlateBoardView plateBoardView;

    private void Start()
    {
        plateBoardView = FindFirstObjectByType<PlateBoardView>();
    }
    public void OnClick()
    {
        StartCoroutine(ServePlate());
    }

    private IEnumerator ServePlate()
    {
        StartCoroutine(plateView.Serve());
        yield return new WaitWhile(() => plateView.serving);
        plateBoardView.UpdatePlates();
        canvas.gameObject.SetActive(false);
    }
}
