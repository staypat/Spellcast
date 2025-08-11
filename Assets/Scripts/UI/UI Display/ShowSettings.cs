using UnityEngine;

public class ShowSettings : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    public void ShowSettingsPanel()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }
    }
}
