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
    
    public void AddCardToDeck(CardData cardData)
    {
        GameManager.Instance.heroDataRuntime.deck.Add(cardData);
    }

    public void OnRewardSelected()
    {
        HideRewardSelect();
        Debug.Log("Reward Selected!");
        SceneController.Instance.NewTransition()
            .Load(SceneDatabase.Slots.SessionContent, SceneDatabase.Scenes.Map, setActive: true)
            .WithOverlay()
            .Perform();
    }
}