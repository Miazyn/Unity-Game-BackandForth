using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public event EventHandler<int> MoveNumChanged;

    public RoundsCounter rounds;
    public int whosTurnIsIt;

    [Header("My Header")]
    public TextMeshProUGUI whosTurnText;
    public TextMeshProUGUI moveCounterText;

    private void Start()
    {
        rounds = GetComponent<RoundsCounter>();
        rounds.OnTurnEnded += ChangeUI;
    }


    private void ChangeUI(object sender, System.EventArgs e)
    {
        whosTurnIsIt = rounds.counter%2;
        Debug.Log(whosTurnIsIt);
        if (whosTurnIsIt == 0)
        {
            whosTurnText.text = "Player";
        }
        else
        {
            whosTurnText.text = "Aliens";
        }

    }

    public void MoveChangedText(int moves)
    {
        moveCounterText.text = moves.ToString();
    }


    private void OnDestroy()
    {
        rounds.OnTurnEnded -= ChangeUI;
    }
}
