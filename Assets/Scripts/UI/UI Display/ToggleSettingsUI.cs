using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleSettingsUI : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private SetSelectedElement setSelectedElement;
    [SerializeField] private GameObject playFirstSelectedGO;
    [SerializeField] private GameObject settingsFirstSelectedGO;
    [SerializeField] private TMP_Dropdown[] settingsDropdowns;
    private void OnEnable()
    {
        UIInputHandler.OnCancelPressed += OnCancel;
    }

    private void OnDisable()
    {
        UIInputHandler.OnCancelPressed -= OnCancel;
    }

    public void ToggleSettingsPanel()
    {
        if (settingsPanel != null)
        {
            bool isActive = settingsPanel.activeSelf;
            settingsPanel.SetActive(!isActive);

            if (!isActive)
            {
                setSelectedElement.SelectElement(settingsFirstSelectedGO);
            }
            else
            {
                setSelectedElement.SelectElement(playFirstSelectedGO);
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
        setSelectedElement.SelectElement(playFirstSelectedGO);
    }
}
