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
    }

    public void OnRewardSelected()
    {
        HideRewardSelect();
        Debug.Log("Reward Selected!");
    }
}