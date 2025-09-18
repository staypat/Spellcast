using System;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private HeroData heroData;
    public HeroData heroDataRuntime;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        heroDataRuntime = heroData.DeepCopy();
    }

    public enum GameState
    {
        MainMenu,
        InBattle,
        Paused,
        GameOver
    }

    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;
    public GameState CurrentState { get; private set; }

    private void Start()
    {
        ChangeGameState(GameState.MainMenu);
    }
    public void ChangeGameState(GameState newState)
    {
        if (newState == CurrentState)
        {
            return;
        }
        OnBeforeStateChanged?.Invoke(newState);
        switch (newState)
        {
            case GameState.MainMenu:
                break;
            case GameState.InBattle:
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        CurrentState = newState;
        OnAfterStateChanged?.Invoke(newState);
        Debug.Log("Game State changed to: " + CurrentState);
    }
}
