using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, ISelectHandler
{
    public UnityEvent onTabSelected;

    public void OnSelect(BaseEventData eventData)
    {
        onTabSelected?.Invoke();
    }
}
