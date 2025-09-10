using System.Collections.Generic;
using UnityEngine;

public class Plate
{
    public CombatantView targetEnemy { get; private set; } // the enemy this plate is assigned to
    private List<GameAction> stack = new(); // stack of actions to perform when plate is triggered

    public Plate(CombatantView targetEnemy) // constructor
    {
        this.targetEnemy = targetEnemy;
    }

    public void AddAction(GameAction action) // add GameAction to stack
    {
        stack.Add(action);
    }

    public void Serve() // perform all actions in stack and reset stack; this should also trigger when End Turn button is pressed
    {
        foreach (var action in stack)
        {
            ActionSystem.Instance.Perform(action);
        }
        stack.Clear();
    }
}
