using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid Instance;

    Dictionary<Vector2, Tile> TileTracker;

    [SerializeField] int gridWidth, gridHeight;
    [SerializeField] Tile tilePrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void GenerateGrid()
    {
        TileTracker = new Dictionary<Vector2, Tile>();
      
        for(int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                TileTracker[new Vector2(x, y)] = spawnedTile;
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                Debug.Log(isOffset);
                spawnedTile.Init(isOffset);


            }
        }

        GameManager.Instance.UpdateGameState(GameManager.GameState.PlayerTurn);

    }

    public Tile GetTileOfUnit()
    {
        return null;
    }


    public Tile GetTileAtPosition(Vector2 pos)
    {
        if(TileTracker.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }
}
