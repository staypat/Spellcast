using UnityEngine;
using UnityEngine.UI;

public class RelicUI : MonoBehaviour
{
    [SerializeField] private Image image;
    public Relic relic { get; private set; }

    public void Setup(Relic relic)
    {
        this.relic = relic;
        image.sprite = relic.image;
    }

}
