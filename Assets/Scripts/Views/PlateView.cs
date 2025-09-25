using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateView : MonoBehaviour
{
    public List<(GameAction action, string cardClass)> stack = new(); // stack of actions to perform when plate is triggered
    public EnemyView target;
    public bool serving = false;
    public string lastPlayedCardClass;

    public void Setup(EnemyView target)
    {
        this.target = target;
    }

    public void AddAction(GameAction action, string cardClass) // add GameAction to stack
    {
        stack.Add((action, cardClass));
    }

    public IEnumerator Serve() // perform all actions in stack and reset stack; this should also trigger when End Turn button is pressed
    {
        serving = true;
        foreach (var action in stack)
        {
            if (target != null)
            {
                Debug.Log($"Performing action from card class {action.cardClass}");
                ActionSystem.Instance.Perform(action.action);
                yield return new WaitWhile(() => ActionSystem.Instance.IsPerforming);
                lastPlayedCardClass = action.cardClass;
            }

        }
        serving = false;
        stack.Clear();
        lastPlayedCardClass = null;
    }
}
