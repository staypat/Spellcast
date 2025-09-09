using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class RandomEncounterGenerator : MonoBehaviour
{
    [SerializeField] private Transform pathButtonParent;
    [SerializeField] private GameObject pathButtonPrefab;

    private void Start()
    {
        SpawnPaths();
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
            return (EncounterType)Random.Range(1, 4);
        }
    }

    public string encounterTypeToString(EncounterType type)
    {
        return type.ToString();
    }

    public void goToEncounter(EncounterType encounterType)
    {
        if (encounterType == EncounterType.None)
        {
            return;
        }

        MapManager.instance.currentEncounterIndex++;
        SceneManager.LoadScene(encounterTypeToString(encounterType));
    }

    private void SpawnPaths()
    {
        int numPaths = (MapManager.instance.currentEncounterIndex == 6 || MapManager.instance.currentEncounterIndex == 7) ? 1 : Random.Range(2, 4);

        float verticalSpacing = -60f;
        float horizontalOffset = 55f;
        float verticalOffset = 80f;

        for (int i = 0; i < numPaths; i++)
        {
            // Make the path button and its position
            GameObject pathButton = Instantiate(pathButtonPrefab, pathButtonParent);
            float x = (i % 2 == 0) ? horizontalOffset : -horizontalOffset;
            float y = i * verticalSpacing + verticalOffset;
            pathButton.transform.localPosition = new Vector3(x, y, 0);

            // Randomly assign encounter type
            EncounterType encounter = getRandomEncounterType();

            // Add onClick listener
            Button button = pathButton.GetComponent<Button>();
            button.onClick.AddListener(() => goToEncounter(encounter));
        }
    }
}
