using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateView : MonoBehaviour
{
    private List<GameAction> stack = new(); // stack of actions to perform when plate is triggered
    public EnemyView target;
    public bool serving = false;

    public void Setup(EnemyView target)
    {
        this.target = target;
    }

    public void AddAction(GameAction action) // add GameAction to stack
    {
        stack.Add(action);
    }

    public IEnumerator Serve() // perform all actions in stack and reset stack; this should also trigger when End Turn button is pressed
    {
        serving = true;
        foreach (var action in stack)
        {
            if (target != null)
            {
                ActionSystem.Instance.Perform(action);
                yield return new WaitWhile(() => ActionSystem.Instance.IsPerforming);
            }
            
        }
        serving = false;
        stack.Clear();
    }
}
