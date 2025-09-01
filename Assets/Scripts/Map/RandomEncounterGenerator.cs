using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class RandomEncounterGenerator : MonoBehaviour
{
    public TMP_Text encounterText;
    private EncounterType encounter;

    private void OnEnable()
    {
        generateRandomEncounter();
    }
    public enum EncounterType
    {
        None,
        Shop,
        Enemy,
        Elite,
        Occurrence,
        Boss
    }

    public EncounterType getRandomEncounterType()
    {
        return (EncounterType)Random.Range(0, System.Enum.GetValues(typeof(EncounterType)).Length);
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
        if (encounter == EncounterType.None){
            return;
        }
        SceneManager.LoadScene(getEncounterTypeName(encounter));
    }
}
