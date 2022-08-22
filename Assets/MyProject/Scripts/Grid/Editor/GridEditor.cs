using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
public class GridEditor : Editor
{
    int height = 9;
    int width = 16;

    
    

    public void OnSceneGUI()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                Handles.DrawLine(new Vector3(x, y), new Vector3(x, y + 1));
                Handles.DrawLine(new Vector3(x, y), new Vector3(x+ 1, y ));

            }
        }

        Handles.DrawLine(new Vector3(0, height), new Vector3(width, height));
        Handles.DrawLine(new Vector3(width, 0), new Vector3(width, height));

    }

    
}
