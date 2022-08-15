using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tileprefab;
    [SerializeField] Transform cam;
    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for(int x = 0; x< _width; x++)
        {
            for(int y = 0; y < _height; y++)
            {
                var spawnTile = Instantiate(_tileprefab, new Vector3(x, y), Quaternion.identity);
                spawnTile.name = $"Tile: {x} {y}";
            }
        }
        cam.transform.position = new Vector3((float)_width / 2 -0.5f, (float)_height / 2 - 0.5f, -10);
    }


}
