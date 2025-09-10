using System.Collections.Generic;
using UnityEngine;

public class PlateSystem : MonoBehaviour
{
    public List<Plate> plates { get; private set; } = new();

    public void SetupPlates(List<CombatantView> enemies) // initialize plates for each enemy at start of combat
    {
        plates.Clear();
        foreach (var enemy in enemies)
        {
            plates.Add(new Plate(enemy));
            // also initialize a plate drop area prefab here?
        }
    }
}
