using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject tutorialPanel;

    public void ToggleTutorial()
    {
        tutorialPanel.SetActive(!tutorialPanel.activeSelf);
    }
}
