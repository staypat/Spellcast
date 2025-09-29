using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateView : MonoBehaviour
{
    public List<(GameAction action, string cardClass)> stack = new(); // stack of actions to perform when plate is triggered
    public List<GameObject> spawnedIngredients = new();
    public EnemyView target;
    public bool serving = false;
    public string lastPlayedCardClass;
    [SerializeField] private Canvas serveUI;
    [SerializeField] private GameObject highlight;
    private bool uiOpen = false;

    public void Setup(EnemyView target)
    {
        this.target = target;
    }

    public void AddAction(GameAction action, string cardClass) // add GameAction to stack
    {
        stack.Add((action, cardClass));
    }

    public void TrackIngredient(GameObject ingredientPrefab)
    {
        spawnedIngredients.Add(ingredientPrefab);
    }

    public IEnumerator Serve() // perform all actions in stack and reset stack; this should also trigger when End Turn button is pressed
    {
        serving = true;
        foreach (var action in stack)
        {
            if (target != null)
            {
                ActionSystem.Instance.Perform(action.action);
                yield return new WaitWhile(() => ActionSystem.Instance.IsPerforming);
            }

        }
        serving = false;
        stack.Clear();
        lastPlayedCardClass = null;
        foreach (var ingredient in spawnedIngredients)
        {
            if (ingredient != null)
                Destroy(ingredient);
        }
        spawnedIngredients.Clear();
    }

    private void OnMouseDown()
    {
        if (!uiOpen)
        {
            uiOpen = true;
            serveUI.gameObject.SetActive(true);
        }
        else
        {
            uiOpen = false;
            serveUI.gameObject.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
