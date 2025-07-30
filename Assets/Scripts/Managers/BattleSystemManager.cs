using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    CHECK,
    WIN,
    LOSE
}

public class BattleSystemManager : MonoBehaviour
{
    public BattleState _state;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBattleState(BattleState.START);

    }

    public void UpdateBattleState(BattleState newState)
    {
        _state = newState;

        switch (newState)
        {
            case BattleState.START:
                //do starting stuff
                break;
            case BattleState.PLAYERTURN:
                //deal cards to player, player takes their turn, and serves
                break;
            case BattleState.ENEMYTURN:
                //enemies attack
                break;
            case BattleState.CHECK:
                //after a player turn or enemy turn, check if all enemies are dead or if player is dead
                break;
            case BattleState.WIN:
                //player won, move to loot screen
                break;
            case BattleState.LOSE:
                //player lost, game over
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, "state not recognized");
        }
    }
}