using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeepCurrentSelectedObject : MonoBehaviour
{
    [SerializeField] private GameObject lastSelectedObject;

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject && lastSelectedObject != EventSystem.current.currentSelectedGameObject)
        {
            lastSelectedObject = EventSystem.current.currentSelectedGameObject;
        }

        if (EventSystem.current.currentSelectedGameObject == null && lastSelectedObject != null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelectedObject);
        }
    }
}
