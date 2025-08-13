using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleSettingsUI : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject playFirstSelectedGO;
    [SerializeField] private GameObject settingsFirstSelectedGO;
    [SerializeField] private TMP_Dropdown[] settingsDropdowns;
    
    private void OnEnable()
    {
        UIInputManager.OnCancelPressed += OnCancel;
    }

    private void OnDisable()
    {
        UIInputManager.OnCancelPressed -= OnCancel;
    }

    public void ToggleSettingsPanel()
    {
        if (settingsPanel != null)
        {
            bool isActive = settingsPanel.activeSelf;
            settingsPanel.SetActive(!isActive);

            if (!isActive)
            {
                EventSystem.current.SetSelectedGameObject(settingsFirstSelectedGO);
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(playFirstSelectedGO);
            }
        }
    }

    public void OnCancel()
    {
        if (!settingsPanel.activeSelf)
        {
            return;
        }
        foreach (var dropdown in settingsDropdowns)
        {
            if (dropdown.IsExpanded)
            {
                dropdown.Hide();
                return;
            }
        }
        settingsPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playFirstSelectedGO);
    }
}
