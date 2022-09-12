using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Color baseColor, offsetColor;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject highlight;

    public BaseUnit occupiedUnit;
    private bool _isWalkable;

    public bool Walkable => _isWalkable && occupiedUnit == null;
    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState state)
    {
        if(state == GameManager.GameState.PlayerTurn)
        {
            Debug.Log("Player can move now.");
        }
    }

    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseDown()
    { 
        
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
