using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public enum Scene
    {
        MainMenu,
        Map,
        Game
    }

    [SerializeField] private Scene sceneToLoad;
    public void Load()
    {
        SceneManager.LoadScene(sceneToLoad.ToString());
    }
}
