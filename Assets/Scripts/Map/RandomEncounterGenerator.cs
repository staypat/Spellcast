using UnityEngine;

public class RandomEncounterGenerator : MonoBehaviour
{
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

    public void printRandomEncounter()
    {
        EncounterType randomType = getRandomEncounterType();
        Debug.Log("Random Encounter Type: " + getEncounterTypeName(randomType));
        Debug.Log("Random Encounter Index: " + (int)randomType);
    }
}
