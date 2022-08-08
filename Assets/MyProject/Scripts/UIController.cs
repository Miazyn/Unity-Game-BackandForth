using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public RoundsCounter rounds;
    private int whosTurnIsIt;

    [Header("My Header")]
    public TextMeshProUGUI whosTurnText;


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


    private void OnDestroy()
    {
        rounds.OnTurnEnded -= ChangeUI;
    }
}
