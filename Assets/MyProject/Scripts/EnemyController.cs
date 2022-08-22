using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CommandProcessor))]
public class EnemyController : MonoBehaviour, IActor
{
    public Transform player;
    public Vector3 direction;
    public Transform movePoint;

    private CommandProcessor _commandProcessor;
    private float moveSpeed = 5f;

    public int attackRange;
    public int possibleMoves = 2;
    int moveCounter = 0;

    public RoundsCounter rounds;
    public UIController ui;


    private void Awake()
    {
        _commandProcessor = GetComponent<CommandProcessor>();
    }

    private void Start()
    {
        movePoint.parent = null;
    }

    private void Update()
    {
        

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (rounds.counter % 2 == 1)
        {
            ui.MoveChangedText(possibleMoves - moveCounter);
            if (Vector3.Distance(transform.position, movePoint.position) <= 0f)
            {
                if (moveCounter == possibleMoves)
                {
                    ui.MoveChangedText(possibleMoves - moveCounter);
                    rounds.EndRound();
                    moveCounter = 0;
                }
                else
                {
                    #region[Direction Check]
                    directionCheck();
                    #endregion
                }
            }
        }
        else
        {
            moveCounter = 0;
        }
    }

    private void directionCheck()
    {
        #region[X Check]
        if (player.position.x < transform.position.x)
        {
            if (player.position == new Vector3(transform.position.x - 1, transform.position.y, 0))
            {
                direction = Vector3.zero;
            }
            else
            {
                direction = new Vector3(-1, 0, 0);
            }


        }
        else if (player.position.x > transform.position.x)
        {
            if (player.position == new Vector3(transform.position.x + 1, transform.position.y, 0))
            {
                direction = Vector3.zero;
            }
            else
            {
                direction = new Vector3(1, 0, 0);
            }
        }
        #endregion
        else if (player.position.x == transform.position.x || player.position.x == transform.position.x)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////
            #region[Y Check]
            if (player.position.y < transform.position.y)
            {
                if (player.position.y == transform.position.y - 1)
                {
                    direction = Vector3.zero;
                }
                else
                {
                    direction = new Vector3(0, -1, 0);
                }

            }
            else if (player.position.y > transform.position.y)
            {
                if (player.position.y == transform.position.y + 1)
                {
                    direction = Vector3.zero;
                }
                else
                {
                    direction = new Vector3(0, 1, 0);
                }
            }
            #endregion
        }
        /////////////////////////////////////////////////////////////////////////////////
        if (direction != Vector3.zero)
        {
            movePoint.transform.position += direction;
            moveCounter++;
        }

    }

    public void MoveFromTo(Vector3 startPos, Vector3 endPos)
    {
        throw new NotImplementedException();
    }

    public void RotateMe()
    {
        transform.Rotate(new Vector3(0, 0, 90));
    }
}
