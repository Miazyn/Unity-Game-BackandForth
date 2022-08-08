using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CommandProcessor))]
public class PlayerController : MonoBehaviour, IActor
{
    private CommandProcessor _commandProcessor;

    public float moveSpeed = 5f;
    public Transform movePoint;

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
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f || Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
                Debug.Log(direction);
                if (direction != Vector3.zero)
                {
                    var moveCommand = new MoveCommand(this, direction, movePoint);
                    _commandProcessor.ExecuteCommand(moveCommand);
                }
            }
        }

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Input.GetKey(KeyCode.Backspace))
            {
                _commandProcessor.Undo();
            }
        }

        
    }

    public void MoveFromTo(Vector3 startPos, Vector3 endPos)
    {
        throw new System.NotImplementedException();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "_itemToCollect")
        {
            collision.gameObject.SetActive(false);
        }
    }
}


