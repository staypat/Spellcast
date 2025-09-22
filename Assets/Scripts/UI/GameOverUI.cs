using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private void OnEnable()
    {
        GameManager.OnAfterStateChanged += HandleGameStateChanged;
    }
    private void OnDisable()
    {
        GameManager.OnAfterStateChanged -= HandleGameStateChanged;
    }
    private void HandleGameStateChanged(GameManager.GameState newState)
    {
        if (newState == GameManager.GameState.GameOver)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void RestartGame()
    {
        GameManager.Instance.ResetRunData();
        SceneController.Instance.NewTransition()
            .Load(SceneDatabase.Slots.Menu, SceneDatabase.Scenes.MainMenu)
            .Unload(SceneDatabase.Slots.SessionContent)
            .WithOverlay()
            .WithClearUnusedAssets()
            .Perform();
        GameManager.Instance.ChangeGameState(GameManager.GameState.MainMenu);
    }
}
