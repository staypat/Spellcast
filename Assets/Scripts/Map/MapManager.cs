using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int currentAct = 1;
    public int currentEncounterIndex = 0;

    // 1-5 is an encounter of type: enemy, elite, occurrence
    // 6 is a shop
    // 7 is a boss
    // We instantiate path button prefabs at runtime; there can only be one NONE path at any point AKA the player has at LEAST 2 paths to choose from and 3 paths at most
    
}
