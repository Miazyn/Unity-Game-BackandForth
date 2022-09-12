using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.PlayerTurn);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            case GameState.GenerateGrid:
                Grid.Instance.GenerateGrid();
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandlePlayerTurn()
    {
        Debug.Log("Player is there.");
    }

    public enum GameState
    {
        GenerateGrid,
        PlayerTurn,
        EnemyTurn,
        Win,
        Lose
    }
}
