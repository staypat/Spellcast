using UnityEngine;
using UnityEngine.EventSystems;

public class SetSelectedElement : MonoBehaviour
{
    public void SelectElement(GameObject elementToSelect)
    {
        if (elementToSelect != null && elementToSelect.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(elementToSelect);
        }
    }
}
