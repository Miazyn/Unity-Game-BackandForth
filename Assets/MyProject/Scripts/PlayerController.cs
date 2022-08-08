using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CommandProcessor))]
public class PlayerController : MonoBehaviour, IActor
{
    private CommandProcessor _commandProcessor;

    public float moveSpeed = 5f;
    public Transform movePoint;

    public RoundsCounter rounds;
    int possibleMoves = 2;
    int moveCounter = 0;
    public UIController ui;

    //public LayerMask whatStopsMovementLayer;
    public Vector3 direction;
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
        Debug.Log(moveCounter + "Other" + possibleMoves);
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (rounds.counter % 2 == 0)
        {
            ui.MoveChangedText(possibleMoves - moveCounter);

            if (moveCounter == possibleMoves)
            {
                ui.MoveChangedText(possibleMoves - moveCounter);
                //rounds.EndRound();
                //ADD FUNCTION TO MAKE MOVES POSSIBLE WHILE HAVING MOVES LEFT
                //-> BACK AND FORTH
            }
            else if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                if (possibleMoves - moveCounter != 0)
                {
                    DirectionCheck();
                }
            }
            if (moveCounter != 0)
            {
                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    _commandProcessor.Undo();
                    moveCounter--;
                }
            }
        }
        else
        {
            moveCounter = 0;
        }

    }

    private void DirectionCheck()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f || Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
            
            if (direction != Vector3.zero)
            {
                var moveCommand = new MoveCommand(this, direction, movePoint);
                _commandProcessor.ExecuteCommand(moveCommand);
                moveCounter++;
            }
        }
    }

    public void MoveFromTo(Vector3 startPos, Vector3 endPos)
    {
        throw new System.NotImplementedException();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "_itemToCollect")
        {
            collision.gameObject.SetActive(false);
        }
    }
}


