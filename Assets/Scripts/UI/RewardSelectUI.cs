using UnityEngine;

public class RewardSelectUI : MonoBehaviour
{
    [SerializeField] private GameObject rewardSelectPanel;

    public void ShowRewardSelect()
    {
        rewardSelectPanel.SetActive(true);
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