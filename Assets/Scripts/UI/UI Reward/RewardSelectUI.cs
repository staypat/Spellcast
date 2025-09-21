using UnityEngine;

public class RewardSelectUI : MonoBehaviour
{
    [SerializeField] private GameObject rewardSelectPanel;
    [SerializeField] private RewardGenerator rewardGenerator;

    public void ShowRewardSelect()
    {
        rewardSelectPanel.SetActive(true);
        rewardGenerator.GenerateCardReward();
    }

    public void HideRewardSelect()
    {
        rewardSelectPanel.SetActive(false);
        SceneController.Instance.NewTransition()
            .Load(SceneDatabase.Slots.SessionContent, SceneDatabase.Scenes.Map, setActive: true)
            .WithOverlay()
            .Perform();
    }

    public void OnRewardSelected()
    {
        HideRewardSelect();
        rewardGenerator.AddCardToDeck();
        Debug.Log("Reward Selected!");
    }
}