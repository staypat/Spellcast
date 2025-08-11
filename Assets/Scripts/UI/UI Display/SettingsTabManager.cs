using UnityEngine;

public class SettingsTabManager : MonoBehaviour
{
    public enum TabType
    {
        Gameplay,
        Graphics,
        Audio,
        Controls,
        Extra
    }

    [System.Serializable]
    public struct Tab
    {
        public TabType type;
        public GameObject tabUI;
    }

    public Tab[] tabs;

    public void ShowTab(TabType type)
    {
        foreach (var tab in tabs)
        {
            tab.tabUI.SetActive(tab.type == type);
        }
    }

    // Wrapper methods for UnityEvent
    public void ShowGameplayTab() => ShowTab(TabType.Gameplay);
    public void ShowGraphicsTab() => ShowTab(TabType.Graphics);
    public void ShowAudioTab()    => ShowTab(TabType.Audio);
    public void ShowControlsTab() => ShowTab(TabType.Controls);
    public void ShowExtrasTab()    => ShowTab(TabType.Extra);
}
