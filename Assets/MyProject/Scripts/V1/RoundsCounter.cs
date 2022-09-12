using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsCounter : MonoBehaviour
{

    public int counter;

    public event EventHandler OnTurnEnded;

    private void Start()
    {
        OnTurnEnded += RoundsCounter_OnTurnEnded;
    }

    public void EndRound()
    {
        
        OnTurnEnded?.Invoke(this, EventArgs.Empty);
        
    }

    private void RoundsCounter_OnTurnEnded(object sender, EventArgs e)
    {
        
        counter++;
    }

    private void OnDestroy()
    {
        OnTurnEnded -= RoundsCounter_OnTurnEnded;
    }
}
