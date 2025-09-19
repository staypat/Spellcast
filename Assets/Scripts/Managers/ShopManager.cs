using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public void EndSession()
    {
        SceneController.Instance.NewTransition()
            .Load(SceneDatabase.Slots.Menu, SceneDatabase.Scenes.MainMenu, setActive: true)
            .Unload(SceneDatabase.Slots.Session)
            .Unload(SceneDatabase.Slots.SessionContent)
            .WithClearUnusedAssets()
            .WithOverlay()
            .Perform();
    }

    public void SwitchToMap()
    {
        SceneController.Instance.NewTransition()
            .Load(SceneDatabase.Slots.SessionContent, SceneDatabase.Scenes.Map, setActive: true)
            .WithOverlay()
            .Perform();
    }
}
