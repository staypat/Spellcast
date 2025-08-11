using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetSelectedElement : MonoBehaviour
{
    [SerializeField] private Selectable elementToSelect;

    public void SelectElement()
    {
        if (elementToSelect != null && elementToSelect.gameObject.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(elementToSelect.gameObject);
        }
    }
}
