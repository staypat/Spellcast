using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class RandomEncounterGenerator : MonoBehaviour
{
    public TMP_Text encounterText;
    private EncounterType encounter;

    private void Start()
    {
        generateRandomEncounter(); // remove line if you move functionality to MapManager.cs
    }
    public enum EncounterType
    {
        None,
        Enemy,
        Elite,
        Occurrence,
        Shop,
        Boss
    }

    public EncounterType getRandomEncounterType()
    {
        if (MapManager.instance.currentEncounterIndex == 6)
        {
            return EncounterType.Shop;
        }
        else if (MapManager.instance.currentEncounterIndex == 7)
        {
            return EncounterType.Boss;
        }
        else
        {
            return (EncounterType)Random.Range(0, 4);
        }
    }

    public string getEncounterTypeName(EncounterType type)
    {
        return type.ToString();
    }

    public void generateRandomEncounter()
    {
        encounter = getRandomEncounterType();
        encounterText.text = getEncounterTypeName(encounter);
    }

    public void goToEncounter()
    {
        if (encounter == EncounterType.None)
        {
            return;
        }

        MapManager.instance.currentEncounterIndex++;
        SceneManager.LoadScene(getEncounterTypeName(encounter));
    }
}
